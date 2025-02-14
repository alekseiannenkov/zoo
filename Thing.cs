using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zoo;
public abstract class Thing : IInventory
{
    public int Number { get; set; }
    public string Name { get; set; }
}
