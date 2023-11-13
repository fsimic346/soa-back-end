﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Explorer.Tours.API.Dtos
{
    public class ShoppingCartResponseDto
    {
        public long Id { get; set; }
        public long TouristId { get; set; }
        public double TotalPrice { get; set; }
        public bool IsPurchased { get; set; }
        public List<OrderItemResponseDto> OrderItems { get; set; }
    }
}
