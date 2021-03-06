﻿using System;
using System.ComponentModel.DataAnnotations;
using Bakery.Common.Infra.Enums;

namespace Bakery.Database.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public BakeryType Type { get; set; }
        public DateTime BakingTime { get; set; }
        public int LifeHours { get; set; }
        public int FreshHours { get; set; }
        [Range(0.1, 100)]
        public decimal Price { get; set; }
    }
}