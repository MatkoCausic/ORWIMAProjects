package com.example.localfridge.data

class ToBuy(private val fridge: Fridge) {
    private val toBuyItems: MutableList<Item> = mutableListOf()

    fun addItem(name: String, unit: Unit, amount: Double): String{
        val newItem = Item(name = name, unit = unit, amount = amount)
        toBuyItems.add(newItem)
        return "$newItem.name was added to your toBuy list!"
    }

    fun addFavouriteItem(item: Item){
        toBuyItems.add(item)
    }

    fun addFavourites(){
        fridge.getItems().forEach{
            fridgeItem ->
            if(fridgeItem.isFavourite){
                val amountDifference = fridgeItem.isFavouriteAmount - fridgeItem.unit.ordinal
                if(amountDifference > 0){
                    val toBuyItem = Item(
                        name = fridgeItem.name,
                        unit = fridgeItem.unit,
                        amount = fridgeItem.amount,
                        isFavouriteAmount = fridgeItem.isFavouriteAmount,
                        isFavourite = fridgeItem.isFavourite,
                    )
                    addFavouriteItem(toBuyItem)
                }
            }
        }
    }

    fun getItems(): List<Item>{
        return toBuyItems
    }
}