using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using ежедневник;

class Program
{
    private static int position;

    static void Main(string[] args)
    {

        Order.TotalPrice = 0;
        do
        {
            Console.Clear();
            Console.WriteLine("  Добро пожаловать в кондитерскую!");
            Console.WriteLine("  Выберите параметр торта");
            Console.WriteLine("  Форма торта");
            Console.WriteLine("  Размер торта");
            Console.WriteLine("  Вкус коржей");
            Console.WriteLine("  Количество коржей");
            Console.WriteLine("  Глазурь");
            Console.WriteLine("  Декор");
            Console.WriteLine("  Завершить заказ");
           

            Console.WriteLine("\n Текущий заказ:\n"+
                   $"Форма торта: {Order.CakeForm}\n" +
                   $"Размер торта: {Order.CakeSize}\n" +
                   $"Вкус коржей: {Order.CakeFlavor}\n" +
                   $"Количество коржей: {Order.CakeQuantity}\n" +
                   $"Глазурь: {Order.CakeGlaze}\n" +
                   $"Декор: {Order.CakeDecor}\n" +
                   $"Стоимость заказа: {Order.TotalPrice} руб.");
            int position = Menu.Show(2, 8); 
                
            if (position == 8)
            {
                Console.Clear();
                SaveOrder();
                Console.Clear();
                Console.WriteLine("Заказ сохранен в файле. Спасибо за покупку!");
                ConsoleKeyInfo key = Console.ReadKey();
                if (key.Key == ConsoleKey.Escape)
                    break;
            }

            Console.WriteLine();

            switch (position)
            {
                case 2:
                    Console.Clear();
                    CakeForm();
                    break;
                case 3:
                    Console.Clear();
                    CakeSize();
                    break;
                case 4:
                    Console.Clear();
                    CakeFlavor();
                    break;
                case 5:
                    Console.Clear();
                    CakeQuantity();
                    break;
                case 6:
                    Console.Clear();
                    CakeGlaze();
                    break;
                case 7:
                    Console.Clear();
                    CakeDecor();
                    break;
              
            }
        } while (true);

        

    }



    static void CakeForm()
    {
        List<SubMenuItem> forms = new List<SubMenuItem>()
        {
            new SubMenuItem("  Круг", 450),
            new SubMenuItem("  Прямоугольник", 500),
            new SubMenuItem("  Квадрат", 450),
            new SubMenuItem("  Сердечко", 600)
        };

        ShowSubMenu(forms, "Выберите форму торта:");
        int position = Menu.Show(1, forms.Count);

        if (position == -1) return;
        Order.CakeForm = forms[position - 1].Name;
        Order.TotalPrice += forms[position - 1].Price;
    }

    static void CakeSize()
    {
        List<SubMenuItem> sizes = new List<SubMenuItem>
        {
            new SubMenuItem("  Маленький(Диаметр 16 см, высота 7-8 см.)", 1500),
            new SubMenuItem("  Средний(Диаметр 22 см, высота 10 см..)", 2500),
            new SubMenuItem("  Большой(Диаметр 30 см, высота 11 см.)", 3500)
        };

        ShowSubMenu(sizes, "Выберите размер торта:");
        int position = Menu.Show(1, sizes.Count);

        if (position == -1) return;
        Order.CakeSize = sizes[position - 1].Name;
        Order.TotalPrice += sizes[position - 1].Price;
    }

    static void CakeFlavor()
    {
        List<SubMenuItem> flavors = new List<SubMenuItem>
        {
            new SubMenuItem("  Шоколадный", 110),
            new SubMenuItem("  Ванильный", 100),
            new SubMenuItem("  Ореховый", 150),
            new SubMenuItem("  Кокосовый", 200),
            new SubMenuItem("  Ягодный", 250),
            new SubMenuItem("  Карамельный", 250)
        };

        ShowSubMenu(flavors, "Выберите вкус торта:");
        int position = Menu.Show(1, flavors.Count);

        if (position == -1) return;
        Order.CakeFlavor = flavors[position - 1].Name;
        Order.TotalPrice += flavors[position - 1].Price;
    }

    static void CakeQuantity()
    {
        List<SubMenuItem> quantities = new List<SubMenuItem>
        {
            new SubMenuItem("  1 корж", 200),
            new SubMenuItem("  2 коржа", 400),
            new SubMenuItem("  3 коржа", 600),
            new SubMenuItem("  4 коржа", 800)
        };


        ShowSubMenu(quantities, "Выберите количество коржей:");
        int position = Menu.Show(1, quantities.Count);

        if (position == -1) return;
        Order.CakeQuantity = quantities[position - 1].Name;
        Order.TotalPrice += quantities[position - 1].Price;
    }

    static void CakeGlaze()
    {
        List<SubMenuItem> glazes = new List<SubMenuItem>
        {
            new SubMenuItem("  Шоколад", 100),
            new SubMenuItem("  Крем", 200),
            new SubMenuItem("  Безе", 250),
            new SubMenuItem("  Драже", 150),
            new SubMenuItem("  Ягоды", 250)
        };

        ShowSubMenu(glazes, "Выберите глазурь:");
        int position = Menu.Show(1, glazes.Count);

        if (position == -1) return;
        Order.CakeGlaze = glazes[position - 1].Name;
        Order.TotalPrice += glazes[position - 1].Price;
    }
    static void CakeDecor()
    {
        List<SubMenuItem> decors = new List<SubMenuItem>
        {
            new SubMenuItem("  Цветы", 350),
            new SubMenuItem("  Подсвечники", 250),
            new SubMenuItem("  Фигурки", 400)
        };

        ShowSubMenu(decors, "Выберите декор:");
        int position = Menu.Show(1, decors.Count);

        if (position == -1) return;
        Order.CakeDecor = decors[position - 1].Name;
        Order.TotalPrice += decors[position - 1].Price;
    }

    static void ShowSubMenu(List<SubMenuItem> subMenu, string prompt)
    {
        Console.WriteLine(prompt);


        for (int i = 0; i < subMenu.Count; i++)
        {
            Console.WriteLine($" {subMenu[i].Name} - {subMenu[i].Price} руб.");
        }
        Console.WriteLine();
    }

    static void SaveOrder()
    {
        DateTime now = DateTime.Now;
        Console.WriteLine("Заказ сохранен в файле. Спасибо за покупку!");
        string order = $" {now:G}\n" +
                       $"Форма торта: {Order.CakeForm}\n" +
                       $"Размер торта: {Order.CakeSize}\n" +
                       $"Вкус коржей: {Order.CakeFlavor}\n" +
                       $"Количество коржей: {Order.CakeQuantity}\n" +
                       $"Глазурь: {Order.CakeGlaze}\n" +
                       $"Декор: {Order.CakeDecor}\n" +
                       $"Стоимость заказа: {Order.TotalPrice} руб.";

        using (StreamWriter writer = File.AppendText("История заказов.txt"))
        {
            writer.WriteLine(order);
            writer.WriteLine("---------------");
        }
        Order.CakeForm = " ";
        Order.CakeSize = " ";
        Order.CakeFlavor = " ";
        Order.CakeQuantity = " ";
        Order.CakeGlaze = " ";
        Order.CakeDecor = " ";
        Order.TotalPrice = 0;
        

        


    }

    class Order
    {
        public static string CakeForm { get; set; }
        public static string CakeSize { get; set; }
        public static string CakeFlavor { get; set; }
        public static string CakeQuantity { get; set; }
        public static string CakeGlaze { get; set; }
        public static string CakeDecor { get; set; }
        public static int TotalPrice { get; set; }
    }

    class SubMenuItem
    {
        public string Name { get; set; }
        public int Price { get; set; }

        public SubMenuItem(string name, int price)
        {
            Name = name;
            Price = price;
        }
    }
}