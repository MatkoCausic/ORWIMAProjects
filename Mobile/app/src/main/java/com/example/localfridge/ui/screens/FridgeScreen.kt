package com.example.localfridge.ui.screens

import androidx.compose.foundation.layout.*
import androidx.compose.foundation.lazy.LazyColumn
import androidx.compose.foundation.lazy.items
import androidx.compose.material3.*
import androidx.compose.runtime.*
import androidx.compose.ui.Modifier
import androidx.compose.ui.unit.dp
import androidx.navigation.NavController
import com.example.localfridge.data.Item
import com.example.localfridge.data.MeasurementUnit

@Composable
fun FridgeScreen(navController: NavController) {
    val fridgeItems = remember { mutableStateListOf<Item>() } // Simulating stored items

    Column(modifier = Modifier.fillMaxSize().padding(16.dp)) {
        Button(onClick = { navController.navigate("addItem") }) {
            Text("Add Item")
        }

        LazyColumn(modifier = Modifier.fillMaxSize().padding(top = 16.dp)) {
            items(fridgeItems) { item ->
                FridgeItemCard(item, onAmountChanged = { newAmount ->
                    item.amount = newAmount
                })
            }
        }
    }
}

@Composable
fun FridgeItemCard(item: Item, onAmountChanged: (Double) -> Unit) {
    Card(modifier = Modifier.fillMaxWidth().padding(8.dp), elevation = CardDefaults.cardElevation(4.dp)) {
        Row(modifier = Modifier.padding(16.dp), horizontalArrangement = Arrangement.SpaceBetween) {
            Column {
                Text(text = item.name, style = MaterialTheme.typography.bodyLarge)
                Text(text = "Amount: ${item.amount} ${item.unit}", style = MaterialTheme.typography.bodyMedium)
            }

            Row {
                Button(onClick = {
                    val newAmount = when (item.getUnitEnum()) {
                        MeasurementUnit.Count -> item.amount + 1
                        MeasurementUnit.Kilograms, MeasurementUnit.Liters -> item.amount + 0.1
                    }
                    onAmountChanged(newAmount)
                }) { Text("+") }

                Spacer(modifier = Modifier.width(8.dp))

                Button(onClick = {
                    val newAmount = when (item.getUnitEnum()) {
                        MeasurementUnit.Count -> maxOf(0.0, item.amount - 1)
                        MeasurementUnit.Kilograms, MeasurementUnit.Liters -> maxOf(0.0, item.amount - 0.1)
                    }
                    onAmountChanged(newAmount)
                }) { Text("-") }
            }
        }
    }
}
