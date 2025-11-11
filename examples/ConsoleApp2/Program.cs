using ConsoleApp2.Models;
using Microsoft.EntityFrameworkCore;

namespace ConsoleApp2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using (ApplicationContext db = new ())
            {
                db.Database.Migrate();
            }

            Console.ReadLine();
        }
    }
}
