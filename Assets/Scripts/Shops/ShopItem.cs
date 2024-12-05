using System;
using RPG.Inventories;
using UnityEngine;

namespace RPG.Shops
{
    public class ShopItem
    {
        InventoryItem item;
        int availability;
        float price;
        int quantityTransaction;

        public ShopItem(InventoryItem item, int availability, float price, int quantityTransaction)
        {
            this.item = item;
            this.availability = availability;
            this.price = price;
            this.quantityTransaction = quantityTransaction;
        }

        public Sprite GetIcon()
        {
            return item.GetIcon();
        }

        public string GetName()
        {
            return item.GetDisplayName();
        }

        public int GetAvailability()
        {
            return availability;
        }
        public float GetPrice()
        {
            return price;
        }

        public InventoryItem GetInventoryItem()
        {
            return item;
        }

        public int GetQuantityInTransaction()
        {
            return quantityTransaction;
        }
    }
}