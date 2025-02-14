using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zoo;
public class Computer : Thing
{
    public Computer(String name, int number)
    {
        Name = "Компьютер " + name;
        Number = number;
    }
}