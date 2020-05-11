using System;
using System.Collections.Generic;
using System.Text;
using Course.Entities.Enums;
using System.Globalization;

namespace Course.Entities
{
    class Order
    {
        public DateTime Moment { get; set; }
        public OrderStatus Status { get; set; }
        public Client Client { get; set; }

        public List<OrderItem> Items { get; set; } = new List<OrderItem>();

        public Order()
        {
        }

        public Order(DateTime moment, OrderStatus status, Client client)
        {
            Moment = moment;
            Status = status;
            Client = client;
        }

        public void addItem(OrderItem item)
        {
            Items.Add(item);
        }

        public void removeItem(OrderItem item)
        {
            Items.Remove(item);
        }

        public double Total()
        {
            double sum = 0;
            foreach (OrderItem O in Items)
            {
                sum += O.subTotal(); 
            }
            return sum;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("ORDER SUMMARY:");
            sb.Append("Order Moment: ");
            sb.AppendLine(DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss"));
            sb.Append("Status: ");
            sb.AppendLine(Status.ToString());
            sb.Append("Client: ");
            sb.Append(Client.Name);
            sb.Append(" " + Client.BirthDate.ToString("(dd/MM/yyyy)"));
            sb.AppendLine(" - " + Client.Email);
            Console.WriteLine();
            sb.AppendLine("Order Items:");
            foreach (OrderItem O in Items)
            {
                sb.Append(O.Product.Name);
                sb.Append(", $" + O.Price.ToString("F2", CultureInfo.InvariantCulture));
                sb.Append(", Quantity: " + O.Quantity);
                sb.AppendLine(", SubTotal: $" + O.subTotal().ToString("F2", CultureInfo.InvariantCulture));
               
            }
            Console.WriteLine();
            sb.AppendLine("Total price: $" +Total().ToString("F2", CultureInfo.InvariantCulture));

            return sb.ToString();
            
        }
    }
}
