using System;
using System.Collections.Generic;


public class Computer
{
    public string IPAddress { get; set; }
    public int Power { get; set; }
    public string OperatingSystem { get; set; }

    public Computer(string ipAddress, int power, string os)
    {
        IPAddress = ipAddress;
        Power = power;
        OperatingSystem = os;
    }
}


public class Server : Computer
{
    public Server(string ipAddress, int power, string os, string serverType)
        : base(ipAddress, power, os)
    {
        ServerType = serverType;
    }

    public string ServerType { get; set; }
}

public class Workstation : Computer
{
    public Workstation(string ipAddress, int power, string os, string workstationType)
        : base(ipAddress, power, os)
    {
        WorkstationType = workstationType;
    }

    public string WorkstationType { get; set; }
}

public class Router : Computer
{
    public Router(string ipAddress, int power, string os, string routerType)
        : base(ipAddress, power, os)
    {
        RouterType = routerType;
    }

    public string RouterType { get; set; }
}


public interface IConnectable
{
    void ConnectTo(Computer computer);
    void DisconnectFrom(Computer computer);
    void SendData(Computer computer, string data);
    string ReceiveData();
}


public class Network
{
    private List<Computer> computers;

    public Network()
    {
        computers = new List<Computer>();
    }

    public void AddComputer(Computer computer)
    {
        computers.Add(computer);
    }

    public void ConnectComputers(Computer computer1, Computer computer2)
    {
        Console.WriteLine($"{computer1.IPAddress} is connected to {computer2.IPAddress}.");
    }

    public void DisconnectComputers(Computer computer1, Computer computer2)
    {
        Console.WriteLine($"{computer1.IPAddress} is disconnected from {computer2.IPAddress}.");
    }
}

class Program
{
    static void Main()
    {
        Server server = new Server("192.168.1.1", 1000, "Windows Server", "Database Server");
        Workstation workstation = new Workstation("192.168.1.2", 500, "Windows 10", "Developer Workstation");
        Router router = new Router("192.168.1.3", 200, "RouterOS", "Wireless Router");

        Network network = new Network();
        network.AddComputer(server);
        network.AddComputer(workstation);
        network.AddComputer(router);

        network.ConnectComputers(server, workstation);
        network.DisconnectComputers(server, router);

        Console.ReadLine();
    }
}
