using Newtonsoft.Json;
using RestaurentAndFood.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RestaurentAndFood.Classes
{
    public class CustomerDto
    {
        public PersonalInfo personalInfo { get; set; }
        public FoodPerferences foodPerferences{ get; set; }

        public OtherDetails otherDetails { get; set; }



    }
}