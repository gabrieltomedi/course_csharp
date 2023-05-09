using EnumExemple.Entities;
using EnumExemple.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnumExemple
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Order order = new Order
            {
                Id = 1293,
                Moment = DateTime.Now,
                Status = OrderStatus.PendingPayment
            };
            Console.WriteLine(order);  

            string txt = OrderStatus.PendingPayment.ToString();

            OrderStatus os = Enum.Parse<OrderStatus>("Delivered");

            /*
              Outras formas
              OrderStatus os = (OrderStatus)Enum.Parse(typeof(OrderStatus), "Delivered");

              OrderStatus os;
              Enum.TryParse("Delivered", out os);  
             */


            Console.WriteLine(txt); 
            Console.WriteLine(os);

            

        }
    }
}
