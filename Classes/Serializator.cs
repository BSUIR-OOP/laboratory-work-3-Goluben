using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Lab3.Interfaces;

namespace Lab3.Classes
{
    public class Serializator : ISerializator
    {
        public TeacherstList Deserialize(string text)
        {
            SlavsList res = new SlavsList();
            string[] stream = text.Split(' ');
            for (int i = 0; i < stream.Length; i++)
            {
                if (!s.Equals(""))
                {
                    Type type = Type.GetType(stream[i++]);
                    Slavs slav = (Slavs)Activator.CreateInstance(type);
                    slav.Nation = stream[i++];
                    slav.Population = int.Parse(stream[i++]);
                    slav.Area = float.Parse(stream[i]);
                    res.Add(slav);
                }
            }
            return res;
        }

        public string Serialize(SlavsList slavs)
        {
            string resultStr = "";
            foreach (Slavs slav in slavs)
            {
                Type type = slav.GetType();
                resultStr += $"{type.FullName}\t";
                resultStr += $"{slav.Nation}\t";
                resultStr += $"{slav.Population}\t";
                resultStr += $"{slav.Area}\n";
            }
            return resultStr;
        }
    }
}
