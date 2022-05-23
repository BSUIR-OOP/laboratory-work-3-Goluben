using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3.Classes
{
    public abstract class Slavs
    {
        public string Nation { get; set; }

        public int Population { get; set; }

        public float Area { get; set; }

        public Slavs() { }

        public string ShowInfo()
            => $"Nation: {Nation}, Population: {Population}, Area: {Area}.";

        public abstract string Move();
    }
}