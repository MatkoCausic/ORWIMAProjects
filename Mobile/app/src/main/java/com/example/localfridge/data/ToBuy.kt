package com.example.localfridge.data

class ToBuy(private var fridge: Fridge) {
    var toBuyItems: MutableList<Item> = mutableListOf()

    fun addItem(name: String, unit: Unit, amount: Double): String{
        val newItem = Item(name = name, unit = unit, amount = amount)
        toBuyItems.add(newItem)
        return "$newItem.name was added to your toBuy list!"
    }

    fun addItemsToFridge(): String{


        return "All items were successfully added to the fridge!"
    }

    fun getItems(): List<Item>{
        return toBuyItems
    }
}