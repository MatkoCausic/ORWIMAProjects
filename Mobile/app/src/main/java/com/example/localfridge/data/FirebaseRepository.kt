package com.example.localfridge.data

import com.google.firebase.firestore.FirebaseFirestore
import com.google.firebase.firestore.ktx.toObject

class FirebaseRepository {
    private val db = FirebaseFirestore.getInstance()

    private val fridgeRef = db.collection("Fridge")
    private val toBuyRef = db.collection("toBuy")
    private val existingItemsRef = db.collection("existingItems")

    fun addToFridge(item: Item){
        fridgeRef.document(item.id).set(item)
    }

    fun addToBuy(item: Item){
        toBuyRef.document(item.id).set(item)
    }

    fun addToExistingItems(item: Item){
        existingItemsRef.document(item.id).set(item)
    }

    fun getFridgeItems(onSuccess: (List<Item>) -> Unit, onFailure: (Exception) -> Unit){
        fridgeRef.get()
            .addOnSuccessListener { documents ->
                val items = documents.mapNotNull {it.toObject<Item>() }
                onSuccess(items)
            }
            .addOnFailureListener { onFailure(it) }
    }

    fun getToBuyItems(onSuccess: (List<Item>) -> Unit, onFailure: (Exception) -> Unit){
        toBuyRef.get()
            .addOnSuccessListener { documents ->
                val items = documents.mapNotNull { it.toObject<Item>() }
                onSuccess(items)
            }
            .addOnFailureListener { onFailure(it) }
    }

    fun getExistingItems(onSuccess: (List<Item>) -> Unit, onFailure: (Exception) -> Unit){
        existingItemsRef.get()
            .addOnSuccessListener { documents ->
                val items = documents.mapNotNull { it.toObject<Item>() }
                onSuccess(items)
            }
            .addOnFailureListener { onFailure(it) }
    }

    fun buyAllItems(){
        getToBuyItems(
            onSuccess = { toBuyItems ->
                getFridgeItems(
                    onSuccess = { fridgeItems ->
                        val fridgeMap = fridgeItems.associateBy { it.name }.toMutableMap()

                        for(item in toBuyItems){
                            if(fridgeMap.containsKey(item.name)){
                                val existingItem = fridgeMap[item.name]!!
                                existingItem.amount += item.amount
                                fridgeRef.document(existingItem.id).set(existingItem)
                            } else {
                                fridgeRef.document(item.id).set(item)
                            }
                            existingItemsRef.document(item.id).set(item)
                        }
                        toBuyRef.get().addOnSuccessListener { documents ->
                            for(document in documents){
                                toBuyRef.document(document.id).delete()
                            }
                        }
                    },
                    onFailure = { println("Failed to fetch Fridge items: ${it.message}") }
                )
            },
            onFailure = { println("Failed to fetch toBuy items: ${it.message}") }
        )
    }

}