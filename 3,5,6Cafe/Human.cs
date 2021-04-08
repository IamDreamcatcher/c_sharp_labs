using System;

namespace Cafe
{
    public enum Genders
    {
        Male,
        Female,
        Undefined
    }
    public abstract class Human : IComparable<Human>, IMovable
    {
        private static int currentId;
        public int Id { get; }
        public string Name { get; set; }
        public string SecondName { get; set; }
        public string ThirdName { get; set; }
        public string Address { get; set; }
        public Genders Gender { get; set; }
        public DateTime DateOfBirth { get;}

        public bool IsInCafe { get; set; }
        public Human()
        {
            Id = currentId++;
            Name = SecondName = ThirdName = "-";
            Gender = Genders.Undefined;
            DateOfBirth = DateTime.Now;
            Address = null;
            IsInCafe = false;
        }
        public Human(string name, string secondname, string thirdName, DateTime dateOfBirth, Genders gender)
        {
            Id = currentId++;
            Name = name;
            SecondName = secondname;
            DateOfBirth = dateOfBirth;
            ThirdName = thirdName;
            Gender = gender;
            Address = null;
            IsInCafe = false;
        }
        public Human(string name, string secondname, string thirdName,
            DateTime dateOfBirth, Genders gender, string address = null)
        {
            Id = currentId++;
            Name = name;
            SecondName = secondname;
            DateOfBirth = dateOfBirth;
            ThirdName = thirdName;
            Gender = gender;
            Address = address;
            IsInCafe = false;
        }

        public virtual bool EnterTheCafe()
        {
            if (IsInCafe == true)
            {
                Console.WriteLine("Human is in cafe");
                return false;
            }
            Console.WriteLine("Human {0} enter the cafe", Name);

            IsInCafe = true;
            return true;
        }

        public virtual bool LeaveTheCafe()
        {
            if (IsInCafe == false)
            {
                Console.WriteLine("Human isn't in cafe");
                return false;
            }
            Console.WriteLine("Human {0} leave the cafe", Name);
            
            IsInCafe = false;
            return true;
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

        public int CompareTo(Human o)
        {
            if (o == null)
            {
                return -1;
            }
            if (Id > o.Id)
            {
                return 1;
            }
            if (Id < o.Id)
            {
                return -1;
            }

            return 0;
        }

        public override bool Equals(Object obj)
        {
            if (this == obj)
            {
                return true;
            }
            if ((obj == null) || !this.GetType().Equals(obj.GetType())) return false;
            Human p = (Human)obj;
            return Id.Equals(p.Id);
        }
        public override int GetHashCode()
        {
            return Id;
        }

        public override string ToString() 
        {
            return GetType().Name + ":\n" +
                "Id = " + Id + '\n' +
                "Name = " + Name + '\n' +
                "SecondName = " + SecondName + '\n' +
                "ThirdName = " + ThirdName + '\n' +
                "Gender = " + Gender + '\n' +
                "Adress = " + Address + '\n' +
                "DateOfBirth = " + DateOfBirth.ToString("yyyy-MM-dd") + '\n';
        }
    }
}
