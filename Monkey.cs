using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zoo;
public class Monkey : Herbo
{
    public Monkey(String name, int food, int number, int kindness, bool isHealthy = true)
    {
        Name = "Обезьяна " + name;
        Food = food;
        Number = number;
        Kindness = kindness;
        IsHealthy = isHealthy;
    }
}