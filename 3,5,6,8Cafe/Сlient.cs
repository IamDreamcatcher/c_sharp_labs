﻿using System;

namespace Cafe
{
    public class Client : Human
    {
        public int AmountOfMoney { get; set; }
        public double Rating { get; private set; }
        public int MoneySpent { get; set; }

        public Client() : base()
        {
            AmountOfMoney = 0;
            Rating = 10;
            MoneySpent = 0;
        }
        public Client(int amountOfMoney, double rating, int moneySpent, string name, string secondname, 
            string thirdName, DateTime dateOfBirth, Genders gender, string address = null) :
            base(name, secondname, thirdName, dateOfBirth, gender, address)
        {
            AmountOfMoney = amountOfMoney;
            Rating = rating;
            MoneySpent = moneySpent;
        }

        public void ChangeRating(double newRating)
        {
            if (newRating < 0)
            {
                throw new CafeException("New rating is bad");
            }
            Rating = newRating;
        }

        public void AngryAtAnEmployee(Employee employee)
        {
            employee.ChangeRating(employee.Rating * 0.7);
            employee.ChangeSalary(employee.Salary * 0.9);
            employee.AmountOfFines += 1000;
        }
        public override bool EnterTheCafe()
        {
            bool result = base.EnterTheCafe();
            if (result == true)
            {
                InvokeMovingEvent("Client " + Name + " enter the cafe\n");
            }
            else
            {
                InvokeMovingEvent("Client " + Name + " was already in the cafe\n");
            }
            return result;
        }

        public override bool LeaveTheCafe()
        {
            bool result = base.LeaveTheCafe();
            if (result == true)
            {
                InvokeMovingEvent("Client " + Name + " leave the cafe\n");
            }
            else
            {
                InvokeMovingEvent("Client " + Name + " was not in the cafe\n");
            }
            return result;
        }

        public override string ToString() 
        {
            return base.ToString() +
                "Amount Of Money = " + AmountOfMoney + '\n' +
                "Rating = " + Rating + '\n' +
                "Money Spent = " + MoneySpent + '\n'; 
        }
    }
}
