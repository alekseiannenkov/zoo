using Microsoft.Extensions.DependencyInjection;
using System;
using zoo;

class Program
{
    private static ServiceCollection? _services;
    private static Zoo? _zoo;

    static void Main()
    {
        try
        {
            InitServices();

            using (var serviceProvider = _services!.BuildServiceProvider())
            {
                _zoo = serviceProvider.GetRequiredService<Zoo>();

                bool exit = false;
                while (!exit)
                {
                    Menu();
                    string? input = Console.ReadLine();
                    exit = ProcessMenuChoice(input);
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Ошибка: " + ex.Message);
        }
    }

    static void InitServices()
    {
        _services = new ServiceCollection();
        _services.AddSingleton<IVeterinaryClinic, VeterinaryClinic>();
        _services.AddSingleton<Zoo>();
    }

    static void Menu()
    {
        Console.WriteLine("\nВыберите действие:");
        Console.WriteLine("1. Добавить новое животное в зоопарк");
        Console.WriteLine("2. Вывести отчет о количестве еды");
        Console.WriteLine("3. Вывести информацию о животных контактного зоопарка");
        Console.WriteLine("4. Вывести информацию о животных");
        Console.WriteLine("0. Выход");
    }

    static bool ProcessMenuChoice(string? input)
    {
        switch (input)
        {
            case "1":
                MenuAddAnimal();
                break;
            case "2":
                MenuGetFoodConsumptionInfo();
                break;
            case "3":
                MenuGetContactAnimals();
                break;
            case "4":
                MenuGetInventoryInfo();
                break;
            case "0":
                return true;
            default:
                Console.WriteLine("Некорректный ввод. Попробуйте снова");
                break;
        }
        return false;
    }


    static void MenuAddAnimal()
    {
        if (_zoo == null)
        {
            Console.WriteLine("Ошибка: Зоопарк не создан.");
            return;
        }

        Animal? animal = CreateAnimalFromInput();
        if (animal != null && _zoo.AddAnimal(animal))
        {
            Console.WriteLine($"Животное {animal.Name} успешно добавлено в зоопарк.");
        }
        else
        {
            Console.WriteLine("Животное не прошло проверку здоровья.");
        }
    }

    static void MenuGetFoodConsumptionInfo()
    {
        if (_zoo == null)
        {
            Console.WriteLine("Ошибка: Зоопарк не создан.");
            return;
        }
        Console.WriteLine($"Количество потребляемой еды: {_zoo.AmountOfFood()} кг в сутки");

    }

    static void MenuGetContactAnimals()
    {
        if (_zoo == null)
        {
            Console.WriteLine("Ошибка: Зоопарк не создан.");
            return;
        }

        var contactAnimals = _zoo.GetContactAnimals();
        if (contactAnimals.Count == 0)
        {
            Console.WriteLine("Ни одно животное не подходит для контактного зоопарка.");
            return;
        }

        Console.WriteLine("Животные для контактного зоопарка:");
        foreach (var animal in contactAnimals)
        {
            Console.WriteLine($"{animal.Name}, номер: {animal.Number}");
        }
    }

    static void MenuGetInventoryInfo()
    {
        if (_zoo == null)
        {
            Console.WriteLine("Ошибка: Зоопарк не создан.");
            return;
        }

        var inventory = _zoo.GetInventoryInfo();
        if (inventory.Count == 0)
        {
            Console.WriteLine("В зоопарке нет предметов.");
            return;
        }

        Console.WriteLine("Информация об инвентаре:");
        foreach (var item in inventory)
        {
            Console.WriteLine(item);
        }
    }

    static Animal? CreateAnimalFromInput()
    {
        string animalCategory = GetValidatedInput("Выберите тип животного:\n" +
                                              "1. Обезьяна\n" +
                                              "2. Кролик\n" +
                                              "3. Тигр\n" +
                                              "4. Волк\n" +
                                              "Ваш выбор: ",
                                              input => new[] { "1", "2", "3", "4" }.Contains(input),
                                              "Неверный выбор типа животного. Пожалуйста, введите 1, 2, 3 или 4.");

        string name = GetValidatedInput("Введите имя животного: ",
                                        input => !string.IsNullOrWhiteSpace(input),
                                        "Имя не может быть пустым. Попробуйте снова.");

        int food = GetValidatedInt("Введите количество кг еды в сутки: ",
                                    value => value > 0,
                                    "Количество еды должно быть положительным числом. Попробуйте снова.");

        int number = GetValidatedInt("Введите инвентаризационный номер: ",
                                      value => value > 0,
                                      "Инвентаризационный номер должен быть положительным числом. Попробуйте снова.");

        switch (animalCategory)
        {
            case "1":
            case "2":
                {
                    int kindness = GetValidatedInt("Введите уровень доброты (0-10): ",
                        value => value >= 0 && value <= 10,
                        "Уровень доброты должен быть от 0 до 10. Попробуйте снова.");
                    return animalCategory == "1"
                        ? new Monkey(name, food, number, kindness)
                        : new Rabbit(name, food, number, kindness);
                }
            case "3":
            case "4":
                return animalCategory == "3"
                    ? new Tiger(name, food, number)
                    : new Wolf(name, food, number);
            default:
                Console.WriteLine("Неверный выбор типа животного.");
                return null;
        }
    }

    static string GetValidatedInput(string prompt, Func<string, bool> validate, string errorMessage)
    {
        while (true)
        {
            Console.Write(prompt);
            string? input = Console.ReadLine();
            if (input != null && validate(input))
            {
                return input;
            }
            Console.WriteLine(errorMessage);
        }
    }

    static int GetValidatedInt(string prompt, Func<int, bool> validate, string errorMessage)
    {
        while (true)
        {
            Console.Write(prompt);
            string? input = Console.ReadLine();
            if (int.TryParse(input, out int value) && validate(value))
            {
                return value;
            }
            Console.WriteLine(errorMessage);
        }
    }
}