using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zoo;
public abstract class Animal : IAlive, IInventory
{
    public int Food { get; set; }
    public bool IsHealthy { get; set; }
    public int Number { get; set; }
    public string Name { get; set; }
}