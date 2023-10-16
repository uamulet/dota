using System;
using System.Collections.Generic;
using System.Threading;


public class Road
{
    public double Length { get; set; }
    public double Width { get; set; }
    public int NumberOfLanes { get; set; }
    public int TrafficLevel { get; set; }

    public Road(double length, double width, int numberOfLanes)
    {
        Length = length;
        Width = width;
        NumberOfLanes = numberOfLanes;
        TrafficLevel = 0;
    }
}

public class Vehicle : IDriveable
{
    public double Speed { get; set; }
    public double Size { get; set; }
    public string Type { get; set; }

    public Vehicle(double speed, double size, string type)
    {
        Speed = speed;
        Size = size;
        Type = type;
    }

    public void Move()
    {
        Console.WriteLine($"{Type} is moving at {Speed} mph.");
    }

    public void Stop()
    {
        Console.WriteLine($"{Type} has stopped.");
    }
}


public interface IDriveable
{
    void Move();
    void Stop();
}


public class TrafficSimulation
{
    public static void SimulateTraffic(Road road, List<Vehicle> vehicles)
    {
        Console.WriteLine($"Traffic on the road with {road.NumberOfLanes} lane(s) and a length of {road.Length} miles:");
        while (road.TrafficLevel < 100)
        {
            foreach (var vehicle in vehicles)
            {
                if (vehicle.Speed > road.TrafficLevel)
                {
                    vehicle.Move();
                    road.TrafficLevel += 10;
                }
                else
                {
                    vehicle.Stop();
                }
                Thread.Sleep(1000);
            }
        }
        Console.WriteLine("Traffic has cleared.");
    }
}

class Program
{
    static void Main()
    {
        Road cityRoad = new Road(10, 2, 2);
        List<Vehicle> vehicles = new List<Vehicle>
        {
            new Vehicle(60, 10, "Car"),
            new Vehicle(50, 20, "Truck"),
            new Vehicle(40, 15, "Bus"),
            new Vehicle(70, 8, "Motorcycle")
        };

        TrafficSimulation.SimulateTraffic(cityRoad, vehicles);

        Console.ReadLine();
    }
}
