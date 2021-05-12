using System;

namespace Cafe
{
    public class Employee : Human
    {
        public double Salary { get; private set; }
        public double Rating { get; private set; }
        public int AmountOfFines { get; set; }

        public Employee() : base()
        {
            Salary = 0;
            Rating = 0;
            AmountOfFines = 0;
        }
        public Employee(double salary, double rating, int amountOfFines, string name, string secondname,
            string thirdName, DateTime dateOfBirth, Genders gender, string address = null) :
            base(name, secondname, thirdName, dateOfBirth, gender, address)
        {
            Salary = salary;
            Rating = rating;
            AmountOfFines = amountOfFines;
        }

        public void ChangeRating(double newRating)
        {
            if (newRating < 0 || newRating > 10)
            {
                throw new CafeException("New rating is bad");
            }
            Rating = newRating;
        }
        public void ChangeSalary(double newSalary)
        {
            if (newSalary <= 100)
            {
                Console.WriteLine("Rest in peace employee, new salary is so low");
                return;
            }
            Salary = newSalary;
        }
        public override bool EnterTheCafe()
        {
            bool result = base.EnterTheCafe();
            if (result == true)
            {
                InvokeMovingEvent("Employee " + Name + " enter the cafe\n");
            }
            else
            {
                InvokeMovingEvent("Employee " + Name + " was already in the cafe\n");
            }
            return result;
        }

        public override bool LeaveTheCafe()
        {
            bool result = base.LeaveTheCafe();
            if (result == true)
            {
                InvokeMovingEvent("Employee " + Name + " leave the cafe");
            }
            else
            {
                InvokeMovingEvent("Employee " + Name + " was not in the cafe\n");
            }
            return result;
        }

        public override string ToString() 
        {
            return base.ToString() +
                "Salary = " + Salary + '\n' +
                "Rating = " + Rating + '\n' +
                "Amount Of Fines = " + AmountOfFines + '\n';
        }
    }
}
