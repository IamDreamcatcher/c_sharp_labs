using System;
using System.Collections.Generic;

namespace Cafe
{
    public struct OrderInfo
    {
        public List <Dish> Dishes;
        public Client Client;
        public Employee Employee;

        public OrderInfo(List <Dish> dish, Client сlient, Employee employee)
        {
            Dishes = dish;
            Client = сlient;
            Employee = employee;
        }
    }
    public class Order
    {

        private static int currentId;
        public int Id { get; }
        public OrderInfo Info { get; }
        public int TotalCost { get; }
        public bool isComplete { get; private set; }

        public Order(List <Dish> dishes, Client client, Employee employee)
        {
            Info = new OrderInfo(dishes, client, employee);
            TotalCost = CalculateThecost(dishes);
            isComplete = false;
            Id = currentId++;
        }

        public void CompleteTheOrder()
        {
            if (isComplete == true)
            {
                throw new CafeException("The order was completed earlier");
            }
            if (Info.Client.AmountOfMoney < TotalCost)
            {
                Info.Client.ChangeRating(Info.Client.Rating - 1.1);
                throw new CafeException("Clinet have no money ro pay\n");
            }
            Info.Client.AmountOfMoney -= TotalCost;
            Info.Client.MoneySpent += TotalCost;
            Info.Client.ChangeRating(Info.Client.Rating + 0.8);
            isComplete = true;
        }
        private int CalculateThecost(List <Dish> dishes)
        {
            int totalCost = 0;
            foreach(Dish dish in dishes)
            {
                totalCost += dish.Cost;
            }
            return totalCost;
        }

        public override bool Equals(Object obj)
        {
            if (this == obj)
            {
                return true;
            }
            if ((obj == null) || !this.GetType().Equals(obj.GetType())) return false;
            Order p = (Order)obj;
            return Id.Equals(p.Id);
        }
        public override int GetHashCode()
        {
            return Id;
        }
    }
}
