
namespace Cafe
{
    public class Dish
    {
        public string Name { get; set; }
        public int Cost { get; set; }
        public Dish()
        {
            Name = "-";
            Cost = 0;
        }
        public Dish(string name, int cost)
        {
            Name = name;
            Cost = cost;
        }

        public override string ToString() 
        {
            return "Dish : \n" +
                "Name = " + Name + '\n' +
                "Cost = " + Cost + '\n';
        }
    }
}
