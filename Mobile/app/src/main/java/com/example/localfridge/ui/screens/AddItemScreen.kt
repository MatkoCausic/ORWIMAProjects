package com.example.localfridge.ui.screens

import androidx.compose.foundation.layout.*
import androidx.compose.material3.*
import androidx.compose.runtime.*
import androidx.compose.ui.Modifier
import androidx.compose.ui.unit.dp
import androidx.navigation.NavController
import com.example.localfridge.data.Item
import com.example.localfridge.data.MeasurementUnit

@Composable
fun AddItemScreen(navController: NavController) {
    var itemName by remember { mutableStateOf("") }
    var amount by remember { mutableStateOf("1.0") }
    var selectedUnit by remember { mutableStateOf(MeasurementUnit.Count) }

    Column(modifier = Modifier.fillMaxSize().padding(16.dp)) {
        TextField(value = itemName, onValueChange = { itemName = it }, label = { Text("Item Name") })
        Spacer(modifier = Modifier.height(8.dp))

        DropdownMenuExample(selectedUnit) { newUnit -> selectedUnit = newUnit }
        Spacer(modifier = Modifier.height(8.dp))

        TextField(value = amount, onValueChange = { amount = it }, label = { Text("Amount") })
        Spacer(modifier = Modifier.height(16.dp))

        Button(onClick = {
            val newItem = Item(name = itemName, unit = selectedUnit.name, amount = amount.toDouble())

            navController.navigate("fridge")
        }) {
            Text("Add to Fridge")
        }
    }
}

@Composable
fun DropdownMenuExample(selectedUnit: MeasurementUnit, onUnitSelected: (MeasurementUnit) -> Unit) {
    var expanded by remember { mutableStateOf(false) }

    Box {
        Button(onClick = { expanded = true }) {
            Text(text = selectedUnit.name)
        }

        DropdownMenu(expanded = expanded, onDismissRequest = { expanded = false }) {
            MeasurementUnit.values().forEach { unit ->
                DropdownMenuItem(
                    text = { Text(unit.name) },
                    onClick = {
                        onUnitSelected(unit)
                        expanded = false
                })
            }
        }
    }
}
