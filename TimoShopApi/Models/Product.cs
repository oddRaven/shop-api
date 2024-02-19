﻿namespace TimoShopApi.Models
{
    public class Product
    {
        private int _cartAmount = 0;

        public Guid Guid { get; } = Guid.NewGuid();
        public string Title { get; init; }
        public string Description { get; init; }
        public decimal Price { get; init; }
        public string? ImageUrl { get; init; }
        public int StorageAmount { get; init; }

        public int CartAmount {
            get => _cartAmount; 
            set
            {
                if (value < 0)
                {
                    _cartAmount = 0;
                }
                else if (value > StorageAmount)
                {
                    _cartAmount = StorageAmount;
                }
                else
                {
                    _cartAmount = value;
                }
            } 
        }
    }
}
