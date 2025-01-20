package com.example.localfridge.data

import java.util.UUID

data class Item (
    val id: UUID = UUID.randomUUID(),
    val name: String = "Unknown",
    val unit: Unit = Unit.Count,
    val amount: Double = 0.0,
    val isFavouriteAmount: Double = 0.0,
    val isFavourite: Boolean = false
)