using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zoo;
public class Tiger : Predator
{
    public Tiger(String name, int food, int number, bool isHealthy = true)
    {
        Name = "Тигр " + name;
        Food = food;
        Number = number;
        IsHealthy = isHealthy;
    }
}