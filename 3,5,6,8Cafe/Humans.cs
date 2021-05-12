using System;
using System.Collections.Generic;

namespace Cafe
{
    class Humans {
        int numberOfHumans = 0;
        private Dictionary<int, Human> People;
        public Humans()
        {
            People = new Dictionary<int, Human>();
        }
        public Human this[int index] {
            get
            {
                if (index < 0 && index >= numberOfHumans)
                {
                    throw new CafeException("There is no Human with such id");
                }
                return People[index];
            }
            set 
            {
                if (index != value.Id)
                {
                    throw new CafeException("There is no Human with such id");
                }
                People[index] = value;
                numberOfHumans++;
            }
        }
    }
}