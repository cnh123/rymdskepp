using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rymdskepp.Garage
{




    public class Garage<T> : IEnumerable where T : Spaceship
    {
        public List<T> Spaceships { get; set; } = new List<T>();
        public int MaxLimitPerFloor { get; }
        public string Name { get; set; }

        public Garage(string name)
        {
            Name = name;
            MaxLimitPerFloor = 15;
        }


        IEnumerator IEnumerable.GetEnumerator()
        {
            foreach (T spaceship in Spaceships)
            {
                yield return spaceship;
            }
        }
    }

}



