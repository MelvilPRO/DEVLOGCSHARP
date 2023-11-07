using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet
{
    public class Order
    {
        public List<Meal> Meals { get; set; }

        public Order(List<Meal> Meals)
        {
            this.Meals = Meals;
        }

        public float GetTotalPrice()
        {
            float priceResult = 0;

            for (int mealIndex = 0; mealIndex < Meals.Count; mealIndex++)
            {
                Meal currentMeal = Meals[mealIndex];
                priceResult += currentMeal.Price;
            }

            return priceResult;
        }
    }
}
