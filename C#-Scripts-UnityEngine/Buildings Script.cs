using UnityEngine;
using System.Data;
using System.Data.SqlClient; // You'll need to import the appropriate database library.

public class BuildingManager : MonoBehaviour
{
    private string connectionString = "YourDatabaseConnectionStringHere"; // Replace with your database connection string.

    // Unity UI elements for displaying building information.
    public Text buildingNameText;
    public Text buildingPriceText;

    // Current selected building.
    private string selectedBuildingName;
    private int selectedBuildingPrice;

    void Start()
    {
        // Initialize the UI elements.
        buildingNameText.text = "";
        buildingPriceText.text = "";
    }

    // Called when a player selects a building for buying.
    public void SelectBuilding(string buildingName, int buildingPrice)
    {
        selectedBuildingName = buildingName;
        selectedBuildingPrice = buildingPrice;

        // Display the selected building's information on the UI.
        buildingNameText.text = "Selected Building: " + selectedBuildingName;
        buildingPriceText.text = "Price: $" + selectedBuildingPrice;
    }

    // Called when the player attempts to buy the selected building.
    public void BuyBuilding()
    {
        if (CanAfford(selectedBuildingPrice))
        {
            // Deduct the purchase price from the player's funds (you should implement your player's fund management).
            int playerFunds = GetPlayerFunds();
            playerFunds -= selectedBuildingPrice;
            UpdatePlayerFunds(playerFunds);

            // Mark the building as owned in the database (you need to implement this).
            MarkBuildingAsOwned(selectedBuildingName);

            // Update the UI or perform any other necessary actions.
            buildingNameText.text = "Purchased: " + selectedBuildingName;
            buildingPriceText.text = "Price: $0";
        }
        else
        {
            // Display a message indicating that the player can't afford the building.
            buildingNameText.text = "Can't afford " + selectedBuildingName;
        }
    }

    // Check if the player can afford a building.
    private bool CanAfford(int price)
    {
        int playerFunds = GetPlayerFunds();
        return playerFunds >= price;
    }

    // You need to implement these functions based on your database setup.
    private int GetPlayerFunds()
    {
        // Implement this function to retrieve the player's funds from the database.
        // Return the player's current funds as an integer.
        return 0; // Placeholder value, replace with the actual implementation.
    }

    private void UpdatePlayerFunds(int funds)
    {
        // Implement this function to update the player's funds in the database.
        // Use the 'funds' parameter as the new player funds value.
    }

    private void MarkBuildingAsOwned(string buildingName)
    {
        // Implement this function to mark the selected building as owned in the database.
    }
}
