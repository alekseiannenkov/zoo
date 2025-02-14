using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zoo;
public class Zoo
{
    private List<Animal> _animals;
    private List<Thing> _things;
    private IVeterinaryClinic _veterinaryClinic;

    public Zoo(IVeterinaryClinic veterinaryClinic)
    {
        _animals = new List<Animal>();
        _things = new List<Thing>();
        _veterinaryClinic = veterinaryClinic;
    }

    public bool AddAnimal(Animal animal)
    {
        if (_veterinaryClinic.CheckAnimal(animal))
        {
            _animals.Add(animal);
            return true;
        }

        return false;
    }

    public void AddThing(Thing thing)
    {
        _things.Add(thing);
    }

    public int NumberOfAnimals()
    {
        return _animals.Count;
    }

    public int AmountOfFood()
    {
        int food = 0;
        foreach (var animal in _animals)
        {
            food += animal.Food;
        }
        return food;
    }

    public List<Animal> GetContactAnimals()
    {   
        var contactAnimals = new List<Animal>();
        foreach (var animal in _animals)
        {
            if (animal is Herbo && ((Herbo)animal).Kindness > 5)
            {
                contactAnimals.Add(animal);
            }
        }
        return contactAnimals;
    }

    public List<String> GetAnimalsInfo()
    {
        List<String> animalsInfo = new List<String>();
        foreach (var animal in _animals)
        {
            animalsInfo.Add("Животное: " + animal.Name + "; номер:" + animal.Number);
        }
        return animalsInfo;
    }

    public List<String> GetThingsInfo()
    {
        List<String> thingsInfo = new List<string>();
        foreach (var thing in _things)
        {
            thingsInfo.Add("Вещь: " + thing.Name + "; номер:" + thing.Number);
        }
        return thingsInfo;
    }
    public List<String> GetInventoryInfo()
    {

        List<String> inventoryInfo = GetAnimalsInfo().Concat(GetThingsInfo()).ToList();
        return inventoryInfo;
    }
}