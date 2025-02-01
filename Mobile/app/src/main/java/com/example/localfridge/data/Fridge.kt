package com.example.localfridge.data

import java.util.UUID

class Fridge(val existingItems: ExistingItems){
    var items: MutableList<Item> = mutableListOf()

    fun addItem(name: String, unit: Unit, amount: Double): String{
        var newItem = existingItems.getExistingItemByName(name)

        if(newItem == null)
            newItem = existingItems.createNewItem(name,unit,amount)

        if(newItem in items)
            items[items.indexOf(newItem)].amount += newItem.amount
        else
            items.add(newItem)

        return "$newItem.name was added to your localFridge!"
    }

    fun getItems(): List<Item?>{
        return items
    }

    private fun checkIfItemIsPresent(checkItem: Item): Boolean{
        items.forEach{
            item ->
            if(checkItem.id == item.id && item.amount > 0)
                return true
        }

        return false
    }
}