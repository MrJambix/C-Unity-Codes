CREATE TABLE BuybackItems
(
    ItemID INT PRIMARY KEY IDENTITY(1,1),
    MerchantID INT NOT NULL,
    ItemName NVARCHAR(255),
    PurchaseDate DATE,
    PurchasePrice DECIMAL(10, 2),
    BuybackPrice DECIMAL(10, 2),
    BuybackExpiryDate DATE,
    SoldBack BIT DEFAULT 0, -- 0 for not sold back, 1 for sold back
    -- Add foreign key constraint if you have a Merchant table
    -- FOREIGN KEY (MerchantID) REFERENCES Merchants(MerchantID)
);
