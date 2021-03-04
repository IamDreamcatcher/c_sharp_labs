namespace Dijkstra
{
    public class Road
    {
        public City firstCity { get; set; }
        public City secondCity { get; set; }
        public int cost { get; set; }
        public Road(City firstCity, City secondCity, int cost)
        {
            this.firstCity = firstCity;
            this.secondCity = secondCity;
            this.cost = cost;
        }
    }
}
