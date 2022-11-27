using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;


namespace pr79
{
  internal class Program
  {
    static void pr14()
    {
      char pick;
      const int size = 17,
                minRange = -100,
                maxRange = 200;

      Console.WriteLine(
       $"Программа создает одномерный массив {size} случайными числами из диапозона [{minRange}, {maxRange}]\n" +
        "Определяет каких элементов массива больше, четных или нечетных\n" +
        "И соритрует массив в порядке возрастания линейным методом\n"
      );

      var rand = new Random();
      int isMoreOdd = 0;

      int[] arr = new int[size];

      for (; ; )
      {
        do
        {
          Console.WriteLine("1: Заполнить массив случайными числами из диапозона");
          Console.WriteLine("2: Вывести исходный массив");
          Console.WriteLine("3: Вывести на экран сообщение о том, каких элементов больше, четных или нечетных");
          Console.WriteLine("4: Вывести исходный массив, отсортировать его линейным методом в порядке возрастания и вывести результат");
          Console.WriteLine("5: Выход из программы");
          Console.WriteLine("Выберите пункт меню");
          pick = char.Parse(Console.ReadLine());
        } while (pick > '5');

        unsafe
        {
          switch (pick)
          {
            case '1':
              {
                for (int i = 0; i < size; i++)
                {
                  arr[i] = rand.Next(minRange, maxRange);
                  if (arr[i] % 2 == 0)
                  {
                    isMoreOdd -= 1;
                  }
                  else
                  {
                    isMoreOdd += 1;
                  }
                }
              }; break;
            case '2':
              {
                Console.WriteLine("Исходный массив: ");
                foreach (var el in arr) Console.Write($"{el} ");
                Console.WriteLine();
              }; break;
            case '3':
              {
                if (isMoreOdd == 0)
                {
                  Console.WriteLine("В массиве находится одинаковое количество четных и нечетных элементов");
                }
                if (isMoreOdd > 0)
                {
                  Console.WriteLine("В массиве находится больше нечетных элементов");
                }
                else
                {
                  Console.WriteLine("В массиве находится находится больше четных элементов");
                }
              }; break;
            case '4':
              {
                Console.WriteLine("Исходный массив: ");
                foreach (var el in arr) Console.Write($"{el} ");
                Console.WriteLine();
                int temp;
                for (int i = 0; i < 13; i++)
                {
                  for (int j = i + 1; j < 14; j++)
                  {
                    if (arr[i] > arr[j])
                    {
                      temp = arr[i];
                      arr[i] = arr[j];
                      arr[j] = temp;
                    }
                  }
                }
                Console.WriteLine("Отсортированный массив в порядке возрастания линейным методом:");
                foreach (var el in arr) Console.Write($"{el} ");
              }; break;
            case '5': return;
            default: break;
          }
        }
      }
    }

    enum ListEnum { Карандаш, Ручка, Мелок, Фломастер };
    static void pr19()
    {
      double[] price = { 100, 200, 300, 400 };
      string[] size = { "1x20", "1x15", "5x5", "2x15" };
      int pick;

      Console.WriteLine(
        "Программа выводит данные о цене и размере письменных принадлежностей, приведенных списком в меню"
      );

      for (; ; )
      {
        do
        {
          Console.WriteLine("Чтобы узнать подробнее о продукте, введите его порядковый номер: ");

          foreach (var item in Enum.GetNames(typeof(ListEnum)))
          {
            var idx = Enum.Parse(typeof(ListEnum), item);
            Console.WriteLine($"{(int)idx + 1}) {item}");
          }
          Console.WriteLine($"{price.Length + 1}) Выйти из программы");
          pick = int.Parse(Console.ReadLine());
          if (pick == price.Length + 1) return;
        } while (pick > price.Length);
        int pickIdx = pick - 1;
        Console.WriteLine(
          $"Вами был выбран - {Enum.Parse<ListEnum>((pickIdx).ToString())}\n" +
          $"стоимость: {price[pickIdx]}p.\n" +
          $"размеры: {size[pickIdx]}"
        );
      }
    }

    struct SPORT
    {
      public string name;
      public string country;
      public int[] date;
      public double[] lostWeight;
    }
    static void pr20()
    {
      Console.WriteLine(
        "Программа записывает данные о спротсмене-пятиборце и информацию о соревновании\n" +
        "и выводит на дисплей сведений о спортсмене с указанием среднего веса в килограммах и граммах,\n" +
        "потерянного спортсменом на этапе соревнования"
      );

      SPORT candidate;
      candidate.date = new int[3];
      candidate.lostWeight = new double[5];
      double averageKg = 0;

      Console.Write("Введите имя спортсмена: ");
      candidate.name = Console.ReadLine();
      Console.Write("Страну, проводившую чемпионат: ");
      candidate.country = Console.ReadLine();
      Console.WriteLine("Дата проведения");
      Console.Write("\tДень: ");
      candidate.date[0] = int.Parse(Console.ReadLine());
      Console.Write("\tМесяц: ");
      candidate.date[1] = int.Parse(Console.ReadLine());
      Console.Write("\tГод: ");
      candidate.date[2] = int.Parse(Console.ReadLine());

      for (int i = 0; i < candidate.lostWeight.Length; i++)
      {
        Console.Write($"Вес спортсмена на {i + 1} этапе: ");
        double input = double.Parse(Console.ReadLine());
        candidate.lostWeight[i] = input;
        averageKg += input;
      }
      averageKg = averageKg / candidate.lostWeight.Length;

      Console.WriteLine(
        "Сведения:\n" +
        $"- Имя: {candidate.name}\n" +
        $"- Страна, проводившая чемпионат: {candidate.country}\n" +
        $"- Дата проведения: {candidate.date[0]}/{candidate.date[1]}/{candidate.date[2]}\n" +
        $"- Cреднеий вес, потерянный спортсменом на этапе соревнования\n" +
        $"\tв килограмм: {averageKg}\n" +
        $"\tв граммах: {averageKg / 1000}\n"
      );
    }

    static void Main(string[] args)
    {
      pr14(); // 
      // pr15(); // +
      // pr16(); // +
      // pr17(); // + 
      // pr18(); // +
      // pr19(); // +
      // pr20(); // + 

      Console.ReadKey();
    }
  }
}