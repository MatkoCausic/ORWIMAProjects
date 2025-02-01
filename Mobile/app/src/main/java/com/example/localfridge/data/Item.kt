package com.example.localfridge.data

import com.google.firebase.firestore.PropertyName
import java.util.UUID

data class Item(
    val id: String = UUID.randomUUID().toString(),
    val name: String = "Unknown",

    @PropertyName("unit")
    val unit: String = MeasurementUnit.Count.name,

    var amount: Double = 0.0,
    val isFavourite: Boolean = false,
    val isFavouriteAmount: Double = 0.0
){
    constructor() : this("","",MeasurementUnit.Count.name, 0.0, false, 0.0)

    fun getUnitEnum(): MeasurementUnit{
        return MeasurementUnit.valueOf(unit)
    }
}