using System;

namespace Cafe
{
    public class Employee : Human, IMovable
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
                throw new Exception("New rating is bad\n");
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
                Console.WriteLine("Employee {0} enter the cafe", Name);
            }
            else
            {
                Console.WriteLine("Employee {0} was already in the cafe", Name);
            }
            return result;
        }

        public override bool LeaveTheCafe()
        {
            bool result = base.LeaveTheCafe();
            if (result == true)
            {
                Console.WriteLine("Employee {0} leave the cafe", Name);
            }
            else
            {
                Console.WriteLine("Employee {0} was not in the cafe", Name);
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
