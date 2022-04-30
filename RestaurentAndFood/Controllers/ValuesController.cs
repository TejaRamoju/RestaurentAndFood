using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestaurentAndFood.Classes;
using RestaurentAndFood.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;


namespace RestaurentAndFood.Controllers
{
    public class ValuesController : ApiController
    {

        //get all customers
        // GET api/values
        public List<CustomerDto> Get()
        {
            //get the converted data from Operation -> ConvertToJson method.
            Operations o = new Operations();
            string data = o.ConvertToJson();

            var custs = JsonConvert.DeserializeObject<List<RestaurentModel>>(data);

            var customersList = new List<CustomerDto>();

            foreach (var item in custs)
            {
                var custoDto = new CustomerDto();
                var personalInfo = new PersonalInfo();
                var foodPerferences = new FoodPerferences();
                var otherDetails = new OtherDetails();

                personalInfo.Age = item.Age;
                personalInfo.FamilySize = item.FamilySize;
                personalInfo.Gender = item.Gender;
                personalInfo.latitude = item.latitude;
                personalInfo.longitude = item.longitude;
                personalInfo.MaritalStatus = item.MaritalStatus;
                personalInfo.MonthlyIncome = item.MonthlyIncome;
                personalInfo.Occupation = item.Occupation;
                personalInfo.PinCode = item.PinCode;
                personalInfo.EducationalQualifications = item.EducationalQualifications;

                foodPerferences.MealP1 = item.MealP1;
                foodPerferences.MealP2 = item.MealP2;
                foodPerferences.MediumP1 = item.MediumP1;
                foodPerferences.MediumP2 = item.MediumP2;
                foodPerferences.PerferenceP1 = item.PerferenceP1;
                foodPerferences.PerferenceP2 = item.PerferenceP2;

                otherDetails.BadPastExperience = item.BadPastExperience;
                otherDetails.DelayOfDeliveryPersonGettingAssigned = item.DelayOfDeliveryPersonGettingAssigned;
                otherDetails.DelayOfDeliveryPersonPickingUpFood = item.DelayOfDeliveryPersonPickingUpFood;
                otherDetails.DeliveryPersonAbility = item.DeliveryPersonAbility;
                otherDetails.EaseAndConvenient = item.EaseAndConvenient;
                otherDetails.EasyPaymentOption = item.EasyPaymentOption;
                otherDetails.Freshness = item.Freshness;
                otherDetails.GoodFoodQuality = item.GoodFoodQuality;
                otherDetails.GoodQuantity = item.GoodQuantity;
                otherDetails.GoodRoadCondition = item.GoodRoadCondition;
                otherDetails.GoodTaste = item.GoodTaste;
                otherDetails.GoodTrackingSystem = item.GoodTrackingSystem;
                otherDetails.GoogleMapsAccuracy = item.GoogleMapsAccuracy;
                otherDetails.HealthConcern = item.HealthConcern;
                otherDetails.HighQualityOfPackage = item.HighQualityOfPackage;
                otherDetails.InfluenceOfRating = item.InfluenceOfRating;
                otherDetails.InfluenceOfTime = item.InfluenceOfTime;
                otherDetails.LateDelivery = item.LateDelivery;
                otherDetails.LessDeliveryTime = item.LessDeliveryTime;
                otherDetails.LongDeliveryTime = item.LongDeliveryTime;
                otherDetails.LowQuantityLowTime = item.LowQuantityLowTime;
                otherDetails.MaximumWaitTime = item.MaximumWaitTime;
                otherDetails.MissingItem = item.MissingItem;
                otherDetails.MoreOffersAndDiscount = item.MoreOffersAndDiscount;
                otherDetails.MoreRestaurantChoices = item.MoreRestaurantChoices;
                otherDetails.NumberOfCalls = item.NumberOfCalls;
                otherDetails.OrderPlacedByMistake = item.OrderPlacedByMistake;
                otherDetails.OrderTime = item.OrderTime;
                otherDetails.Output = item.Output;
                otherDetails.Politeness = item.Politeness;
                otherDetails.PoorHygiene = item.PoorHygiene;
                otherDetails.ResidenceInBusyLocation = item.ResidenceInBusyLocation;
                otherDetails.Reviews = item.Reviews;
                otherDetails.SelfCooking = item.SelfCooking;
                otherDetails.Temperature = item.Temperature;
                otherDetails.TimeSaving = item.TimeSaving;
                otherDetails.Unaffordable = item.Unaffordable;
                otherDetails.Unavailability = item.Unavailability;
                otherDetails.WrongOrderDelivered = item.WrongOrderDelivered;



                custoDto.personalInfo = personalInfo;
                custoDto.foodPerferences = foodPerferences;
                custoDto.otherDetails = otherDetails;
               
                

                customersList.Add(custoDto);
            }

            //Deserialize the data and return.
            return customersList;
        }

        //get all customers with specific gender 
        [HttpGet]
        [Route("api/{values}/{gender}")]
        public List<RestaurentModel> Get(string gender)
        {
            Operations o = new Operations();
            string data = o.ConvertToJson();

            var customers = new List<RestaurentModel>();

            customers = JsonConvert.DeserializeObject<List<RestaurentModel>>(data);

            var specificCustomers = new List<RestaurentModel>();

            foreach (var item in customers)
            {
                if (item.Gender == gender)
                {

                    specificCustomers.Add(item);
                }
            }

            return specificCustomers;
        }

        //total count of Male vs Female Custmores
        [HttpGet]
        [Route("api/{values}/malevsfemale")]
        public MaleVsFemaleDto MaleVsFemale()
        {
            Operations o = new Operations();
            string data = o.ConvertToJson();

            var customers = new List<RestaurentModel>();
            customers = JsonConvert.DeserializeObject<List<RestaurentModel>>(data);


            int malecount = 0;
            int femalecount = 0;

            foreach (var item in customers)
            {
                if (item.Gender == "Male")
                {

                   malecount =  malecount+1;
                }
                else
                {
                   femalecount =  femalecount+1;
                }
            }

            var totalCount = new MaleVsFemaleDto
            {
                MaleCount = malecount,
                FemaleCount = femalecount,
                Description = "total number of male vs female customers"
                
            };

            return totalCount;

        }

        //total count of Male vs Female Custmores who orderd veg food
        [HttpGet]
        [Route("api/{values}/vegfoodcount")]
        public MaleVsFemaleDto vegfoodcount()
        {
            Operations o = new Operations();
            string data = o.ConvertToJson();

            var customers = new List<RestaurentModel>();
            customers = JsonConvert.DeserializeObject<List<RestaurentModel>>(data);

            int malevegcount = 0;
            int femalevegcount = 0;
            string catchPhrase = "Veg foods (Breakfast / Lunch / Dinner)";

            foreach (var item in customers)
            {
                if ((item.PerferenceP1 == catchPhrase || item.PerferenceP2 == catchPhrase) && item.Gender == "Male")
                {

                    malevegcount = malevegcount + 1;
                }
               if((item.PerferenceP1 == catchPhrase || item.PerferenceP2 == catchPhrase) && item.Gender == "Female")
                {
                    femalevegcount = femalevegcount + 1;
                }
            }

            var totalCount = new MaleVsFemaleDto
            {
                FemaleCount = femalevegcount,

                MaleCount= malevegcount,
                Description = "total number of male vs female customers who ordered veg foods for (Breakfast / Lunch / Dinner)"

            };

            return totalCount;
        }

        //Factors Effecting good experience considiring (Affordibility and Availibility) of food items.
        [HttpGet]
        [Route("api/{values}/goodexp")]
        public FactorsEffectingDto goodExp()
        {
            Operations o = new Operations();
            string data = o.ConvertToJson();

            var customers = new List<RestaurentModel>();


            customers = JsonConvert.DeserializeObject<List<RestaurentModel>>(data);

            int countAgree = 0;
            int countDisagree = 0;
            int countNeutral = 0;

            int countAffordable = 0;
            int countUnAffordable = 0;
            int countNeutralAffordable = 0;

            string DesForAval = "";
            string DesForAffo = "";





            foreach (var item in customers)
            {
                if(item.Unavailability == "Disagree" || item.Unavailability == "Strongly Disagree")
                {
                    countDisagree += 1;
                }
                if (item.Unavailability == "Agree" || item.Unavailability == "Strongly Agree")
                {
                    countAgree += 1;

                }
                if (item.Unavailability == "Neutral")
                {
                    countNeutral += 1;
                }
            }

            if (countDisagree > countAgree)
            {
                DesForAval = $"{countDisagree} customers are happy with the availability of the Food Items. ";
            }


            foreach (var item in customers)
            {
                if (item.Unaffordable == "Disagree" || item.Unaffordable == "Strongly Disagree")
                {
                    countUnAffordable += 1;
                }
                if (item.Unaffordable == "Agree" || item.Unaffordable == "Strongly Agree")
                {
                    countAffordable += 1;

                }
                if (item.Unaffordable == "Neutral")
                {
                    countNeutralAffordable += 1;
                }
            }
            if (countUnAffordable > countAffordable)
            {
                DesForAffo = $"{countUnAffordable} customers are not affordable to buy the items.";
            }
            else 
            {
                DesForAffo = $"{countAffordable} customers are affordable to buy the items.";
            }

            var x = new FactorsEffectingDto
            {
                Affordability = DesForAffo,
                Availability = DesForAval,
                Description = "The Experience of the customers has been effected by the Affordability and Availability of the food items."


            };
           

            return x;


        }
    }
}
