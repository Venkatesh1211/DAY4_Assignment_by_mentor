using System;
using System.Collections.Generic;

// ================= INTERFACE =================
interface IOrderOperations
{
    void AddOrder();
    void UpdateOrder();
    void RemoveOrder();
    void ProcessOrder();
}

// ================= MODEL =================
class Order
{
    public int OrderId;
    public string ProductName;
    public double Price;
    public int CustomerId;

    // Constructor
    public Order(int id, string product, double price, int custId)
    {
        OrderId = id;
        ProductName = product;
        Price = price;
        CustomerId = custId;
    }
}

// ================= MAIN LOGIC =================
class OrderManager : IOrderOperations
{
    // Collections
    List<Order> orders = new List<Order>();
    Dictionary<int, string> customers = new Dictionary<int, string>();
    HashSet<string> categories = new HashSet<string>();
    Queue<Order> orderQueue = new Queue<Order>();
    Stack<string> statusStack = new Stack<string>();

    // Static + Const
    public static int totalOrders = 0;
    public const string PLACED = "Placed";
    public const string PROCESSED = "Processed";

    // Constructor
    public OrderManager()
    {
        customers[1] = "Venky";
        customers[2] = "Ravi";
    }

    // Add Order
    public void AddOrder()
    {
        Console.Write("Enter Order ID: ");
        int id = int.Parse(Console.ReadLine()!);

        Console.Write("Enter Product Name: ");
        string product = Console.ReadLine()!;

        Console.Write("Enter Price: ");
        double price = double.Parse(Console.ReadLine()!);

        Console.Write("Enter Customer ID: ");
        int custId = int.Parse(Console.ReadLine()!);

        Order order = new Order(id, product, price, custId);

        orders.Add(order);
        orderQueue.Enqueue(order);
        categories.Add(product);
        statusStack.Push(PLACED);

        totalOrders++;

        Console.WriteLine("Order Added Successfully!");
    }

    // Update Order
    public void UpdateOrder()
    {
        Console.Write("Enter Order ID to update: ");
        int id = int.Parse(Console.ReadLine()!);

        foreach (var order in orders)
        {
            if (order.OrderId == id)
            {
                Console.Write("Enter new price: ");
                order.Price = double.Parse(Console.ReadLine()!);

                Console.WriteLine("Order Updated!");
                return;
            }
        }

        Console.WriteLine("Order not found!");
    }

    // Remove Order
    public void RemoveOrder()
    {
        Console.Write("Enter Order ID to remove: ");
        int id = int.Parse(Console.ReadLine()!);

        orders.RemoveAll(o => o.OrderId == id);

        Console.WriteLine("Order Removed!");
    }

    // Process Order (FIFO)
    public void ProcessOrder()
    {
        if (orderQueue.Count == 0)
        {
            Console.WriteLine("No orders to process!");
            return;
        }

        Order order = orderQueue.Dequeue();
        statusStack.Push(PROCESSED);

        Console.WriteLine($"Processing Order: {order.OrderId}");
    }

    // Display Orders
    public void DisplayOrders()
    {
        Console.WriteLine("\nAll Orders:");
        foreach (var o in orders)
        {
            Console.WriteLine($"ID: {o.OrderId}, Product: {o.ProductName}, Price: {o.Price}");
        }
    }

    // Show Categories
    public void ShowCategories()
    {
        Console.WriteLine("\nUnique Categories:");
        foreach (var c in categories)
        {
            Console.WriteLine(c);
        }
    }

    // Show Status History
    public void ShowStatus()
    {
        Console.WriteLine("\nOrder Status History:");
        foreach (var s in statusStack)
        {
            Console.WriteLine(s);
        }
    }
}

// ================= MAIN =================
class Program
{
    static void Main()
    {
        OrderManager manager = new OrderManager();

        while (true)
        {
            Console.WriteLine("\n===== ORDER MENU =====");
            Console.WriteLine("1. Add Order");
            Console.WriteLine("2. Update Order");
            Console.WriteLine("3. Remove Order");
            Console.WriteLine("4. Process Order");
            Console.WriteLine("5. View Orders");
            Console.WriteLine("6. View Categories");
            Console.WriteLine("7. View Status History");
            Console.WriteLine("8. Exit");

            int choice = int.Parse(Console.ReadLine()!);

            switch (choice)
            {
                case 1: manager.AddOrder(); break;
                case 2: manager.UpdateOrder(); break;
                case 3: manager.RemoveOrder(); break;
                case 4: manager.ProcessOrder(); break;
                case 5: manager.DisplayOrders(); break;
                case 6: manager.ShowCategories(); break;
                case 7: manager.ShowStatus(); break;
                case 8: return;
                default: Console.WriteLine("Invalid choice"); break;
            }
        }
    }
}
