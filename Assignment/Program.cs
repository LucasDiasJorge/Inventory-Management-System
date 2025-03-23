using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        List<Product> inventory = new List<Product>();
        bool running = true;

        while (running)
        {
            Console.WriteLine("\nInventory Management System");
            Console.WriteLine("1. Add Product");
            Console.WriteLine("2. Update Stock");
            Console.WriteLine("3. View Products");
            Console.WriteLine("4. Remove Product");
            Console.WriteLine("5. Exit");
            Console.Write("Select an option: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    AddProduct(inventory);
                    break;
                case "2":
                    UpdateStock(inventory);
                    break;
                case "3":
                    ViewProducts(inventory);
                    break;
                case "4":
                    RemoveProduct(inventory);
                    break;
                case "5":
                    running = false;
                    break;
                default:
                    Console.WriteLine("Invalid option. Please try again.");
                    break;
            }
        }
    }

    static void AddProduct(List<Product> inventory)
    {
        Console.Write("Enter product name: ");
        string name = Console.ReadLine();
        Console.Write("Enter product price: ");
        decimal price = decimal.Parse(Console.ReadLine());
        Console.Write("Enter stock quantity: ");
        int stock = int.Parse(Console.ReadLine());

        inventory.Add(new Product(name, price, stock));
        Console.WriteLine("Product added successfully!");
    }

    static void UpdateStock(List<Product> inventory)
    {
        Console.Write("Enter product name: ");
        string name = Console.ReadLine();
        Product product = inventory.Find(p => p.Name == name);

        if (product != null)
        {
            Console.Write("Enter quantity to add/remove (use - for removal): ");
            int quantity = int.Parse(Console.ReadLine());
            product.Stock += quantity;
            Console.WriteLine("Stock updated successfully!");
        }
        else
        {
            Console.WriteLine("Product not found.");
        }
    }

    static void ViewProducts(List<Product> inventory)
    {
        if (inventory.Count == 0)
        {
            Console.WriteLine("No products in inventory.");
        }
        else
        {
            Console.WriteLine("\nProduct List:");
            foreach (var product in inventory)
            {
                Console.WriteLine($"Name: {product.Name}, Price: {product.Price}, Stock: {product.Stock}");
            }
        }
    }

    static void RemoveProduct(List<Product> inventory)
    {
        Console.Write("Enter product name: ");
        string name = Console.ReadLine();
        Product product = inventory.Find(p => p.Name == name);

        if (product != null)
        {
            inventory.Remove(product);
            Console.WriteLine("Product removed successfully!");
        }
        else
        {
            Console.WriteLine("Product not found.");
        }
    }
}

class Product
{
    public string Name { get; set; }
    public decimal Price { get; set; }
    public int Stock { get; set; }

    public Product(string name, decimal price, int stock)
    {
        Name = name;
        Price = price;
        Stock = stock;
    }
}