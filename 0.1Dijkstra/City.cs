using System;

namespace Dijkstra
{
    public class City
    {
        public string name { get; set; }
        public City(string name)
        {
            this.name = name;
        }
        public override bool Equals(Object obj)
        {
            if (this == obj) return true;
            if ((obj == null) || !this.GetType().Equals(obj.GetType())) return false;
            City p = (City)obj;
            return name == p.name;
        }
        public override int GetHashCode()
        {
            return name.GetHashCode();
        }

    }
}
