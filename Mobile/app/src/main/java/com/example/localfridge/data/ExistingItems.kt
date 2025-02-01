package com.example.localfridge.data

class ExistingItems {
    private val existingItems: MutableList<Item> = mutableListOf()

    fun createNewItem(name: String, unit: Unit, amount: Double) : Item{
        val newItem = Item(name = name.lowercase(), unit = unit, amount = amount)
        addNewItem(newItem)
        return newItem
    }

    fun getExistingItemByName(name: String) : Item?{
        existingItems.forEach{
            item ->
            if(name.lowercase() == item.name) {
                println("This item is already in the database.")
                return item
            }
        }

        println("This item doesn't exist.")
        return null
    }

    private fun addNewItem(newItem: Item){
        existingItems.add(newItem)
    }
}