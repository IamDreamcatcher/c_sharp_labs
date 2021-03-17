using System;

namespace Human
{
    public enum Genders
    {
        Male,
        Female,
        Undefined
    }
    public class Human
    {
        private static int currentId;
        public int Id { get; }
        public string Name { get; set; }
        public string SecondName { get; set; }
        public string ThirdName { get; set; }
        public double Weight { get; set; }
        public double Height { get; set; }
        public string Address { get; set; }
        public Genders Gender { get; set; }
        public DateTime DateOfBirth { get;}
        public Human()
        {
            Id = currentId++;
            Name = SecondName = ThirdName = "-";
            Gender = Genders.Undefined;
            Weight = Height = 0;
            DateOfBirth = DateTime.Now;
            Address = null;
        }
        public Human(string name, string secondname, string thirdName, DateTime dateOfBirth, Genders gender)
        {
            Id = currentId++;
            Name = name;
            SecondName = secondname;
            DateOfBirth = dateOfBirth;
            ThirdName = thirdName;
            Gender = gender;
            Weight = Height = 0;
            Address = null;
        }
        public Human(string name, string secondname, string thirdName, DateTime dateOfBirth, Genders gender,
            double weight, double height, string adress = null)
        {
            Id = currentId++;
            Name = name;
            SecondName = secondname;
            DateOfBirth = dateOfBirth;
            ThirdName = thirdName;
            Gender = gender;
            Weight = weight;
            Height = height;
            Address = adress;
        }

        public double CalculateBodyMassIndex()
        {
            double heightInMeters = Height * 0.01;
            return Weight / (heightInMeters * heightInMeters);
        }
        public int GetAge()
        {
            int age = DateTime.Now.Year - DateOfBirth.Year;
            if (DateTime.Now.Month < DateOfBirth.Month || 
               (DateTime.Now.Month == DateOfBirth.Month && DateTime.Now.Day < DateOfBirth.Day))
            {
                age--;
            }
            return age;
        }
        public override string ToString() 
        {
            return "Human{\n" +
                "Id = " + Id + '\n' + 
                "Name = " + Name + '\n' +
                "SecondName = " + SecondName + '\n' +
                "ThirdName = " + ThirdName + '\n' +
                "Gender = " + Gender + '\n' +
                "Adress = " + Address+ '\n' +
                "DateOfBirth = " + DateOfBirth.ToString("yyyy-MM-dd") + '\n' +
                "Weight = " + Weight + '\n' +
                "Height = " + Height + '\n' +
                '}';
        }
    }
}
