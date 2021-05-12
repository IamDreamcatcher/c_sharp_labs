using System;
using System.Collections.Generic;

namespace Cafe
{
    class Program
    {       
        public static void PrintEvent(string massege)
        {
            Console.WriteLine(massege);
        }
        static void Main(string[] args)
        {
            Human firstClient = new Client(77, 10, 0, "Vitalya", "Hate", "c#", new DateTime(1965, 11, 1), Genders.Male);
            firstClient.Address = "Germany, Berlin";
            firstClient.MovingEvent += massege => Console.WriteLine(massege);
            Client secondClient = new Client(200000031, 10, 0, "Tanya", "love", "ISP", new DateTime(2001, 3, 23),
                Genders.Female, "Belarus, Minsk");
            secondClient.MovingEvent += PrintEvent;
            Client thirdClient = new Client(1311141, 10, 0, "Sasha", "The", "Smasher", new DateTime(1986, 8, 8),
                Genders.Male, "Ukraine, Kiev");
            thirdClient.MovingEvent += PrintEvent;

            IMovable movableClient = new Client();
            movableClient.EnterTheCafe();

            Employee firstEmployee = new Employee(1111111, 7, 0, "Employee1", "Hate", "you", new DateTime(1965, 11, 1), Genders.Male);
            firstEmployee.Address = "Rio, Brazil";
            firstEmployee.MovingEvent += PrintEvent;
            Employee secondEmployee = new Employee(2312, 3, 0, "Employee2", "love", "you", new DateTime(2001, 3, 23),
                Genders.Female, "Madrid, Spain");
            secondEmployee.MovingEvent += PrintEvent;
            Employee thirdEmployee = new Employee(772411, 4, 0, "Employee3", "respect", "you", new DateTime(1986, 8, 8),
                Genders.Female, "Moscow, Russia");
            thirdEmployee.MovingEvent += PrintEvent;

            Cafe myCafe = new Cafe();
            myCafe.ClientEntered((Client)firstClient);
            myCafe.ClientEntered(secondClient);
            myCafe.ClientEntered(thirdClient);

            myCafe.EmployeeEntered(firstEmployee);
            myCafe.EmployeeEntered(secondEmployee);
            myCafe.EmployeeEntered(thirdEmployee);

            List <Dish> dishes = new List<Dish>();
            dishes.Add(new Dish("cola", 10));
            dishes.Add(new Dish("soup", 20));
            myCafe.AddOrder((Client)firstClient, dishes);

            dishes.Add(new Dish("potatoes", 100));
            myCafe.AddOrder(thirdClient, dishes);

            dishes.Add(new Dish("pepsi", 10000));
            myCafe.AddOrder(thirdClient, dishes);
            try
            {
                myCafe.CompleteOrder();
                myCafe.CompleteOrder();
                myCafe.AddOrder(secondClient, dishes);
                myCafe.CompleteOrder();
                myCafe.CompleteOrder();
            }
            catch (CafeException ex)
            {
                Console.WriteLine("Exeption: " + ex.Message);
            }
            firstClient.LeaveTheCafe();
            secondClient.LeaveTheCafe();
            thirdClient.LeaveTheCafe();

            firstEmployee.LeaveTheCafe();
            secondEmployee.LeaveTheCafe();
            thirdEmployee.LeaveTheCafe();

            Console.WriteLine("firstClient and secondClient : result of compare {0}", firstClient.CompareTo(secondClient));
            Console.WriteLine("firstClient and firstClient : result of compare {0}", firstClient.CompareTo(firstClient));
            Console.WriteLine("thirdClient and firstClient : result of compare {0}", thirdClient.CompareTo(firstClient));
        }
    }
}
