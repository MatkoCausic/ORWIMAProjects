package com.example.localfridge

import android.os.Bundle
import androidx.activity.ComponentActivity
import androidx.activity.compose.setContent
import androidx.navigation.NavController
import androidx.navigation.compose.NavHost
import androidx.navigation.compose.composable
import androidx.navigation.compose.rememberNavController
import com.example.localfridge.ui.screens.AddItemScreen
import com.example.localfridge.ui.screens.FridgeScreen
import com.example.localfridge.ui.theme.LocalFridgeTheme

class MainActivity : ComponentActivity() {
    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        setContent {
            LocalFridgeTheme {
                val navController = rememberNavController()
                NavHost(navController, startDestination = "fridge"){
                    composable("fridge") { FridgeScreen(navController) }
                    composable("addItem") { AddItemScreen(navController) }
                }
            }
        }
    }
}

/*
@Composable
fun Greeting(name: String, modifier: Modifier = Modifier) {
    Text(
        text = "Hello $name!",
        modifier = modifier
    )
}

@Preview(showBackground = true)
@Composable
fun GreetingPreview() {
    LocalFridgeTheme {
        Greeting("Android")
    }
}
 */