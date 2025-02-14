using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zoo;
public class Wolf : Predator
{
    public Wolf(String name, int food, int number, bool isHealthy = true)
    {
        Name = "Волк " + name;
        Food = food;
        Number = number;
        IsHealthy = isHealthy;
    }
}