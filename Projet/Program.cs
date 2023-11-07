using System;

namespace Projet
{
    public class Program
    {
        static void Main(string[] args)
        {
            List<Meal> mealList = new List<Meal>();
            mealList.Add(new Meal(EProductType.Burger, 5.0f));
            mealList.Add(new Meal(EProductType.Salade, 2.0f));
            mealList.Add(new Meal(EProductType.Salade, 2.5f));
            mealList.Add(new Meal(EProductType.Burger, 9.1f));

            Order order = new Order(mealList);

            Console.WriteLine("Voici le prix total: " + order.GetTotalPrice());
        }
    }
}