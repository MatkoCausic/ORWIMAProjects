package com.example.localfridge.data

import java.util.UUID

data class Item (
    val id: UUID = UUID.randomUUID(),
    val name: String = "Unknown",
    val unit: Unit = Unit.Count,
    var amount: Double = 0.0,
    val isFavourite: Boolean = false,
    val isFavouriteAmount: Double = 0.0
)