using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace pr79
{
  internal class Program
  {
    static void pr7()
    {
      double a, b;
      Console.ForegroundColor = ConsoleColor.Red;
      Console.WriteLine("Для нахождения квадртаного корня от суммы двух вещественных чисел, введите, пожалуйста");

      Console.ForegroundColor = ConsoleColor.Cyan;
      Console.Write("первое значение: ");
      a = Convert.ToDouble(Console.ReadLine());
      Console.Write("второе значение: ");
      b = Convert.ToDouble(Console.ReadLine());

      Console.ForegroundColor = ConsoleColor.Green;
      Console.WriteLine($"Квадртаный корень от суммы двух вещественных чисел равна {Math.Sqrt(a + b)}");
      Console.ReadKey();
    }

    static void pr8()
    {
      var culture = (CultureInfo)CultureInfo.CurrentCulture.Clone();
      culture.NumberFormat.CurrencySymbol = "р. ";

      float x, y;
      double z, t, g, sum;

      Console.ForegroundColor = ConsoleColor.Red;
      Console.WriteLine(
      "\nПрограмма находит значение выражения a=(y-cos(4x))/(2sin(x)^2+ytg^3z), \n" +
      "выводит текущую время и дату в формате 03/21/22 16-08-2017 Пн \n"
      );

      Console.ForegroundColor = ConsoleColor.Yellow;
      Console.Write("Введите число x для нахождения результата выражения a, x = ");
      x = float.Parse(Console.ReadLine());
      Console.Write("Введите число y для нахождения результата выражения a, y = ");
      y = float.Parse(Console.ReadLine());
      Console.Write("Введите число z для нах ождения результата выражения a, z = ");
      z = double.Parse(Console.ReadLine());
      Console.Write("Введите число t для нахождения результата выражения a, t = ");
      t = double.Parse(Console.ReadLine());
      Console.Write("Введите число g для нахождения результата выражения a, g = ");
      g = double.Parse(Console.ReadLine());

      sum = (y - Math.Cos(4 * x)) / (2 * Math.Pow(Math.Sin(x), 2) + (y * t * Math.Pow(g, 3) * z));

      Console.ForegroundColor = ConsoleColor.Green;
      Console.WriteLine($"Результат выражения в десятичном формате, a = {sum}");
      Console.WriteLine($"Результат выражения в шестнадцатиричном формате, a = {Convert.ToInt32(sum).ToString("X")}");
      Console.WriteLine($"Результат выражения в денежном формате, a = {Convert.ToDecimal(sum).ToString("c", culture)}");
      Console.WriteLine($"Результат выражения a в научном формате a = {sum.ToString("e")}");
      Console.WriteLine($"{DateTime.Now.ToString("H'/'m'/'s MM-dd-yyyy", CultureInfo.InvariantCulture)}");

    }

    static void pr9()
    {
      double a, b, a2, b2, s, s2;
      Console.ForegroundColor = ConsoleColor.Red;
      Console.WriteLine("Для нахождения площади заштрихованной фигуры, введите, пожалуйста");

      Console.ForegroundColor = ConsoleColor.Cyan;
      Console.Write("длину большей фигуры: ");
      a = Convert.ToDouble(Console.ReadLine());
      Console.Write("ширину большей фигуры: ");
      b = Convert.ToDouble(Console.ReadLine());
      s = a * b;

      Console.ForegroundColor = ConsoleColor.Green;
      Console.WriteLine($"Площадь первой фигруы равна = {s}");


      Console.ForegroundColor = ConsoleColor.DarkYellow;
      Console.Write("длину меньшей фигуры: ");
      a2 = Convert.ToDouble(Console.ReadLine());
      Console.Write("ширину меньшей фигуры: ");
      b2 = Convert.ToDouble(Console.ReadLine());
      s2 = a2 * b2;
      if (a2 > a || b2 > b)
      {
        Console.WriteLine("Значение меньшей фигуры не должно быть больше первой");
        // Environment.Exit(1);
        Console.ReadKey();
      }

      Console.ForegroundColor = ConsoleColor.Green;
      Console.WriteLine($"Площадь второй фигруы равна = {s2}");

      Console.ForegroundColor = ConsoleColor.DarkMagenta;
      Console.WriteLine($"Площадь заштрихованной фигуры равна = {s - s2}");
    }

    static void pr789()
    {
      Console.Write("Введите, пожалуйста, ваше имя: ");
      string name = Console.ReadLine();
      Console.WriteLine($"Добро пожаловать, {name}!");

      pr8();

      Console.ForegroundColor = ConsoleColor.Green;
      Console.WriteLine($"До свидания, {name}!");
    }

    static void pr10(bool useTern)
    {
      const int size = 4;
      double[] arr = new double[size];
      double
      sum = 0;

      string type = useTern ? "тернарный" : "условный";
      Console.WriteLine(
      $"Программа находит сумму положительных вещественных чисел, введеными вами." +
      $"Используя {type} оператор"
      );

      for (int i = 0; i < size; i++)
      {
        Console.Write($"Введите {i + 1} вещественное число: ");
        arr[i] = double.Parse(Console.ReadLine());
      }

      for (int i = 0; i < size; i++)
      {
        if (useTern)
        {
          sum += arr[i] % 2 == 0 ? arr[i] : 0;
        }
        else
        {
          if (arr[i] % 2 == 0)
          {
            sum += arr[i];

          }
        }
      }

      Console.WriteLine($"Сумма четных вещественных чисел, введеными вами: {sum}");
    }

    static void pr11()
    {
      double x;
      char k;
    }

    static void pr12()
    {
      string password = "password", bodyPassword = "";
      bool success = false;

      Console.WriteLine(
        "Программа проверяет пароль пользователя \n" +
        "и находит ср. знач. чисел, в случае успешного ввода\n"
      );

      for (int x = 0; x < 3; ++x)
      {
        Console.WriteLine("Введите пароль: ");
        bodyPassword = Console.ReadLine();
        if (password == bodyPassword)
        {
          success = true;
          break;
        }
      }

      if (!success)
      {
        Console.WriteLine("Количество попыток истекло");
        return;
      }

      Console.WriteLine("Вход разрешен!");

      int n, m = 0;
      Console.Write("Введите меньшее значение: ");
      n = int.Parse(Console.ReadLine());
      Console.Write("Введите большее значение: ");
      m = int.Parse(Console.ReadLine());

      Console.WriteLine($"Среднее значение чисел {n} и {m} равно = {(m + n) * .5}");
    }

    static double forPr13(double y, int i)
    {
      y = 1 / Math.Pow(4, i) + Math.Pow(5, i + 2);
      return y;
    }
    static void pr13()
    {
      Console.WriteLine(
        "Программа находит бесконечную сумму с заданной точностью Е (Е > 0) выражения " +
        "1 / 4^i + 5^i+2"
      );

      int e, idx = 0;
      double y = 0;

      Console.Write("Введите точность: ");
      e = int.Parse(Console.ReadLine());

      if (e > 0)
      {
        while (Math.Abs(y) < e)
        {
          y += forPr13(y, idx);
          idx++;
        }

        Console.WriteLine($"Бесконечная сумма с заданной точностью Е - {e}: {y}");
      }
      else
      {
        Console.WriteLine("Заданая точность должна быть больше 0!");
      }
    }

    static void pr14()
    {
      const int size = 17,
                minRange = -100,
                maxRange = 200;

      Console.WriteLine(
       $"Программа создает одномерный массив {size} случайными числами из диапозона [{minRange}, {maxRange}]\n" +
        "Определяет каких элементов массива больше, четных или нечетных\n" +
        "И соритрует массив в порядке возрастания линейным методом\n"
      );

      var rand = new Random();

      int[] arr = new int[size];

      for (int i = 0; i < size; i++)
      {
        arr[i] = rand.Next(minRange, maxRange);
      }

      Console.Write("Заполненный Массив: ");
      for (int i = 0; i < size; i++)
      {
        Console.Write($"{arr[i]} ");
      }


    }

    static void Main(string[] args)
    {
      // pr789();

      // pr10(true);
      // pr10(false);


      // pr11();
      // pr12();
      // pr13();
      pr14();
      Console.ReadKey();
    }
  }
}