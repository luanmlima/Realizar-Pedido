using System;
using Course.Entities.Enums;
using Course.Entities;
using System.Globalization;

//Ler os dados de N pedidos com N itens (N fornecido pelo usuario.) Depois, mostrar um sumário do pedidio.


namespace Course
{
    class Program
    {
        public static NumberStyles culture { get; private set; }

        static void Main(string[] args)
        {
            
            Console.WriteLine("Enter client data:");
            Console.Write("Name: ");
            string name = Console.ReadLine();
            Console.Write("Email: ");
            string email = Console.ReadLine();
            Console.Write("Birth Day (DD/MM/YYYY): ");
            DateTime birthDay = DateTime.Parse(Console.ReadLine());
            Console.WriteLine("Enter order data:");
            Console.Write("Status: ");
            OrderStatus status = Enum.Parse<OrderStatus>(Console.ReadLine());
            Client cliente = new Client(name, email, birthDay);
            Order order = new Order(DateTime.Now, status, cliente);
            Console.WriteLine();

            Console.Write("How many items to this order? ");
            int n = int.Parse(Console.ReadLine());
            Console.WriteLine();

            for (int i = 1; i <= n; i++)
            {
                Console.WriteLine($"Enter #{i} item data:");
                Console.Write("Product name: ");
                string productName = Console.ReadLine();
                Console.Write("Product price: ");
                double productPrice = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                Console.Write("Quantity: ");
                int productQuantity = int.Parse(Console.ReadLine());
                Product product = new Product(productName, productPrice);
                OrderItem orderItem = new OrderItem(productQuantity, productPrice, product);
                order.Items.Add(orderItem);
                Console.WriteLine();
                
            }

            Console.WriteLine(order);



        }
    }
}
