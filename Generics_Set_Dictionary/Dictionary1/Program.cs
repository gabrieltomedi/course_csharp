namespace Dictionary1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, string> cookies= new Dictionary<string, string>();

            cookies["user"] = "maria";
            cookies["email"] = "maria@gmail.com";
            cookies["phone"] = "99723124";
            cookies["phone"] = "33412341";

            Console.WriteLine(cookies["email"]);
            Console.WriteLine(cookies["phone"]);

            cookies.Remove("email");

            if (cookies.ContainsKey("email"))
            {
                Console.WriteLine( cookies["email"]);
            }
            else
            {
                Console.WriteLine("There is no 'email' key");
            }

            Console.WriteLine("Size: " + cookies.Count);

            Console.WriteLine("All Cookies:");

            /*
             foreach (var item in cookies)
            {
                Console.WriteLine(item.Key + ": " + item.Value);
            }
             */

            foreach (KeyValuePair<string, string> item in cookies)
            {
                Console.WriteLine(item.Key + ": " + item.Value);
            }
        }
    }
}