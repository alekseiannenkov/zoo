using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zoo;
public class VeterinaryClinic : IVeterinaryClinic
{
    public bool CheckAnimal(Animal animal)
    {
        return animal.IsHealthy;
    }
}