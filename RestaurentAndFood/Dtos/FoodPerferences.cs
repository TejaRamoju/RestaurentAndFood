﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RestaurentAndFood.Classes
{
    public class FoodPerferences
    {
        [JsonProperty("Medium (P1)")]
        public string MediumP1 { get; set; }

        [JsonProperty("Medium (P2)")]
        public string MediumP2 { get; set; }

        [JsonProperty("Meal(P1)")]
        public string MealP1 { get; set; }

        [JsonProperty("Meal(P2)")]
        public string MealP2 { get; set; }

        [JsonProperty("Perference(P1)")]
        public string PerferenceP1 { get; set; }

        [JsonProperty("Perference(P2)")]
        public string PerferenceP2 { get; set; }
    }
}