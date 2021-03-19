using System;
using System.Collections.Generic;

namespace Human
{
    class Humans {
        int numberOfHumans = 0;
        private Dictionary<int, Human> People;
        public Human()
        {
            People = new Dictionary<int, Human>();
        }
        public Humans this[int index] {
            get
            {
                if (index < 0 && index >= numberOfHumans)
                {
                    throw new Exception("There is no Human with such id\n");
                }
                return People[index];
            }
            set 
            {
                if (index != value.Id)
                {
                    throw new Exception("There is no vehicle with such id\n");
                }
                
                People[value.Id] = value;
                numberOfHumans++;
            }
        }
    }
}