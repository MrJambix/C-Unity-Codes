using System;
using System.Data.SqlClient;

public class BuybackItemRepository
{
    private string _connectionString = "CONNECTION_STRING_HERE";

    public void AddItem(string itemName, decimal purchasePrice, decimal buybackPrice, DateTime buybackExpiryDate)
    {
        using (SqlConnection connection = new SqlConnection(_connectionString))
        {
            connection.Open();
            
            string query = "INSERT INTO BuybackItems (ItemName, PurchaseDate, PurchasePrice, BuybackPrice, BuybackExpiryDate) " +
                           "VALUES (@ItemName, @PurchaseDate, @PurchasePrice, @BuybackPrice, @BuybackExpiryDate)";

            using (SqlCommand cmd = new SqlCommand(query, connection))
            {
                cmd.Parameters.AddWithValue("@ItemName", itemName);
                cmd.Parameters.AddWithValue("@PurchaseDate", DateTime.Now);
                cmd.Parameters.AddWithValue("@PurchasePrice", purchasePrice);
                cmd.Parameters.AddWithValue("@BuybackPrice", buybackPrice);
                cmd.Parameters.AddWithValue("@BuybackExpiryDate", buybackExpiryDate);

                cmd.ExecuteNonQuery();
            }
        }
    }
}

