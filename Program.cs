using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        Dictionary<int, City> cities = new Dictionary<int, City>();

        Console.WriteLine("1.1.1 Enter city name:");
        string cityName = Console.ReadLine();

        Console.WriteLine("1.1.2 Enter the number of cities connected to this city:");
        int numOfConnections = ReadPositiveInteger();

        Console.WriteLine("1.1.3 Enter the IDs of connected cities:");
        List<int> connectedCityIds = new List<int>();

        for (int i = 0; i < numOfConnections; i++)
        {
            int connectedCityId = ReadPositiveInteger();

            if (connectedCityIds.Contains(connectedCityId) || connectedCityId == i + 1)
            {
                Console.WriteLine("Invalid ID");
                i--;
                continue;
            }

            connectedCityIds.Add(connectedCityId);
        }

        City city = new City(cityName, connectedCityIds);
        cities.Add(1, city);

        Console.WriteLine("City Information:");
        Console.WriteLine($"City ID: 1, City Name: {cityName}, Connected Cities: {string.Join(", ", connectedCityIds)}");
    }

    static int ReadPositiveInteger()
    {
        int number;

        while (true)
        {
            if (int.TryParse(Console.ReadLine(), out number) && number >= 0)
                break;

            Console.WriteLine("Invalid input. Please enter a positive integer:");
        }

        return number;
    }
}

class City
{
    public string Name { get; set; }
    public List<int> ConnectedCityIds { get; set; }

    public City(string name, List<int> connectedCityIds)
    {
        Name = name;
        ConnectedCityIds = connectedCityIds;
    }
}
