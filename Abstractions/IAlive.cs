using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zoo;
public interface IAlive
{
    int Food { get; set; }
    bool IsHealthy { get; set; }
}