package com.example.localfridge.data

import java.util.UUID

class Fridge{
    private val items: MutableList<Item> = mutableListOf()

    fun addItem(name: String, unit: Unit, amount: Double): String{
        val newItem = Item(name = name, unit = unit, amount = amount)
        items.add(newItem)
        return "$newItem.name was added to your localFridge!"
    }

    fun getItems(): List<Item>{
        return items
    }

    /*fun setFavourite(id: UUID){
        fun
    }*/
}