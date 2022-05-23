using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Lab3.Classes
{
    public class SlavsList: IEnumerable
    {
        private List<Slavs> slavs = new List<Slavs>();

        public int Count
            => slavs.Count;

        public void Add(Slavs t)
            => slavs.Add(t);

        public void Remove(Slavs t)
            => slavs.Remove(t);

        public List<Slavs> GetSlavs()
            => slavs;

        public Slavs Get(int index)
            => slavs[index];

        public IEnumerator GetEnumerator()
            => slavs.GetEnumerator();
    }
}
