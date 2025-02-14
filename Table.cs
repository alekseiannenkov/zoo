using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zoo;
public class Table : Thing
{
    public Table(String name, int number)
    {
        Name = "Стол " + name;
        Number = number;
    }
}