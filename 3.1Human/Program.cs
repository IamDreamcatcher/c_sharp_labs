using System;

namespace Human
{
    class Program
    {
        static void Main(string[] args)
        {
            Human firstHuman = new Human();
            firstHuman.Name = "Sasha";
            firstHuman.SecondName = "The";
            firstHuman.ThirdName = "Smasher";
            firstHuman.Address = "Ukraine, Kiev";
            Console.WriteLine(firstHuman);
            Console.WriteLine("Age : {0}", firstHuman.GetAge());

            Human secondHuman = new Human("Vitalya", "Hate", "c#", new DateTime(1965, 11, 1), Genders.Male);
            secondHuman.Address = "Germany, Berlin";
            Console.WriteLine(secondHuman);
            Console.WriteLine("Age : {0}", secondHuman.GetAge());
            secondHuman.Height = 191.4;
            secondHuman.Weight = 78.3;
            Console.WriteLine("Body Mass Index : {0}", secondHuman.CalculateBodyMassIndex());
            
            Human thirdHuman = new Human("Tanya", "love", "ISP", new DateTime(2001, 3, 23),
                Genders.Female, 56.3, 173.6, "Belarus, Minsk");
            Console.WriteLine(thirdHuman);
            Console.WriteLine("Age : {0}", thirdHuman.GetAge());
            Console.WriteLine("Body Mass Index : {0}", thirdHuman.CalculateBodyMassIndex());
        }
    }
}
