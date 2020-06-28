using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TorpedoClassLibrary;

namespace TorpedoConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            Ship ship = new Ship(3, 4);
            ship.Hit(3);
            ship.ShipHit += Hit;
            Console.WriteLine("asd");
            Console.ReadKey();
        }
        static void Hit(object sender, int damage)
        {
            Console.WriteLine(damage);
        }
    }
}
