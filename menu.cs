using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ежедневник
{
    internal class Menu
    {
        public static int Show(int minStrelochka, int maxStrelochka)
        {
            int position = minStrelochka;
            ConsoleKeyInfo key = Console.ReadKey();

            do
            {
                Console.SetCursorPosition(0, position);
                Console.WriteLine("  ");
                if (key.Key == ConsoleKey.UpArrow && position != minStrelochka)
                {
                    position--;
                }
                else if (key.Key == ConsoleKey.DownArrow && position != maxStrelochka)
                {
                    position++;
                }
                else if (key.Key == ConsoleKey.Escape)
                {
                    break;
                }

                Console.SetCursorPosition(0, position);
                Console.WriteLine("->");
                key = Console.ReadKey();
            } while (key.Key != ConsoleKey.Enter && key.Key != ConsoleKey.Escape);

            if (key.Key == ConsoleKey.Escape)
                return -1;
            return position;
        }
    }
}
