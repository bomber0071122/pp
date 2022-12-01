﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.IO;

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

    static void pr15()
    {
      const int size = 8, minRange = -300, maxRange = 500;
      var rand = new Random();

      char pick;
      int[,] arr = new int[size, size];


      Console.WriteLine(
      "Программа выводит пользовательское меню, где можно:\n" +
      $"\tзаполнить случайным образом целыми числами из диапазона [{minRange}; {maxRange}] двумерный массив, содержащий {size}х{size}\n" +
      "\tвывести исходный массив на экран\n" +
      "\tзаменить все элементы на главной диагонале на -1\n" +
      "\tОтсортировать все четные строки в порядке убывания"
      );


      for (; ; )
      {
        do
        {
          Console.WriteLine("1: Заполнить массив случайными числами");
          Console.WriteLine("2: Вывод массива на экран");
          Console.WriteLine("3: Замена всех элементов на главной диагонале на -1 и вывод полученного результата");
          Console.WriteLine("4: Отсортировать все четные строки в порядке убывания и вывод полученного результата");
          Console.WriteLine("5: Выход из программы");
          Console.WriteLine("Выберите пункт меню");
          pick = char.Parse(Console.ReadLine());
        } while (pick > '5');

        switch (pick)
        {
          case '1':
            {
              for (int i = 0; i < size; i++)
              {
                for (int j = 0; j < size; j++)
                {
                  arr[i, j] = rand.Next(minRange, maxRange);
                }
              }
            }; break;
          case '2':
            {
              Console.WriteLine("Полученный массив: ");
              for (int i = 0; i < size; i++)
              {
                for (int j = 0; j < size; j++)
                {
                  Console.Write($"{arr[i, j]} ");
                }
                Console.WriteLine();
              }
              Console.WriteLine();
            }; break; ;
          case '3':
            {
              Console.WriteLine("Полученный массив: ");
              for (int i = 0; i < size; i++)
              {
                arr[i, i] -= 1;
                for (int j = 0; j < size; j++)
                {
                  Console.Write($"{arr[i, j]} ");
                }
                Console.WriteLine();
              }
            }
            break;
          case '4':
            {
              for (int i = 0; i < size; i++)
              {
                for (int j = 0; j < size; j++)
                {
                  for (int k = 0; k < j; k++)
                  {
                    if (i % 2 == 0)
                    {
                      if (arr[i, k] < arr[i, k + 1])
                      {
                        int myTemp = arr[i, k];
                        arr[i, k] = arr[i, k + 1];
                        arr[i, k + 1] = myTemp;
                      }
                    }
                  }
                  Console.Write($"{arr[i, j]} ");
                }
                Console.WriteLine();
              }
            }; break;
          case '5': return;
          default: break;
        }
      }
    }

    static void pr16()
    {
      int[][] arr = new int[3][];
      arr[0] = new int[9];
      arr[1] = new int[4];
      arr[2] = new int[4];

      char pick;

      Console.WriteLine(
      "Программа выводит пользовательское меню, где можно:\n" +
      $"- заполнить два одномерных массива значениями\n" +
      "- вывести полученный результат:\n" +
      "\tсумма положительных элементов первого массива\n" +
      "\tсумма отрицательных элементов второго массива\n" +
      "\tколичество четных элементов первого массива\n" +
      "\tколичество нечетных элементов второго массива"
      );

      for (; ; )
      {
        do
        {
          Console.WriteLine("1: Заполнить два одномерных массива");
          Console.WriteLine("2: Вывести полученный результат");
          Console.WriteLine("3: Выход из программы");
          Console.WriteLine("Выберите пункт меню");
          pick = char.Parse(Console.ReadLine());
        } while (pick > '3');

        switch (pick)
        {
          case '1':
            {
              for (int i = 0; i < arr.Length; i++)
              {
                if (i == 2) break;
                for (int j = 0; j < arr[i].Length; j++)
                {
                  Console.WriteLine($"Введите {arr[i].Length} целых чисел");
                  Console.Write($"{j + 1}): ");

                  arr[i][j] = int.Parse(Console.ReadLine());

                  switch (i)
                  {
                    case 0:
                      {
                        Console.WriteLine("!1: ");
                        if (arr[i][j] > 0) arr[2][0] += arr[i][j];
                        if (arr[i][j] % 2 == 0) arr[2][2] += 1;
                        continue;
                      }
                    case 1:
                      {
                        if (arr[i][j] < 0) arr[2][1] += arr[i][j];
                        if (arr[i][j] % 2 != 0) arr[2][3] += 1;
                        continue;
                      }
                  }
                }
              }
            }; break;
          case '2':
            {
              Console.WriteLine(
                $"сумма положительных элементов первого массива - {arr[2][0]}\n" +
                $"сумма отрицательных элементов второго массива - {arr[2][1]}\n" +
                $"количество четных элементов первого массива - {arr[2][2]}\n" +
                $"количество нечетных элементов второго массива - {arr[2][3]}"
              );
            }; break;
          case '3': return;
          default: break;
        }
      }
    }

    static void pr17()
    {
      const int size = 9;

      char pick;
      int[] iArray = new int[size];

      Console.WriteLine(
        "Программа выводит пользовательское меню, где можно:\n" +
        $"- заполнить массив длинной {size} целочисленными элементами\n" +
        "- вывести на экран адрес каждого четного элемента\n" +
        "- вывести на экран значение элемента, индекс которого меньше индекса, введенного вами, на 1\n" +
        "- определяет время работы пользователя с программой при выборе каждого пункта меню"
      );

      for (; ; )
      {
        do
        {
          Console.WriteLine("1: Заполнить массив");
          Console.WriteLine("2: Вывести на экран адрес каждого четного элемента");
          Console.WriteLine("3: Вывести на экран значение элемента, индекс которого меньше индекса, введенного вами, на 1");
          Console.WriteLine("4: Выход из программы");
          Console.WriteLine("Выберите пункт меню");
          pick = char.Parse(Console.ReadLine());
        } while (pick > '4');

        System.Diagnostics.Stopwatch watch = System.Diagnostics.Stopwatch.StartNew();
        unsafe
        {
          switch (pick)
          {
            case '1':
              {
                watch.Start();

                Console.WriteLine("Введите, пожалуйста, целочисленные значения");
                for (int idx = 0; idx < size; idx++)
                {
                  Console.Write($"{idx + 1}): ");
                  iArray[idx] = int.Parse(Console.ReadLine());
                };
                watch.Stop();
                Console.WriteLine($"Ваше время работы пунктом 1: {watch.Elapsed}");
                watch.Reset();
              }; break;
            case '2':
              {
                watch.Start();

                fixed (int* ptr = iArray)
                {
                  for (int i = 0; i < size; i++)
                  {
                    if (i % 2 == 0)
                    {
                      Console.WriteLine("Адрес элемента с индексом " + i + " = " + (int)(ptr + i));
                    }
                  };
                }
                watch.Stop();
                Console.WriteLine($"Ваше время работы пунктом 2: {watch.Elapsed}");
                watch.Reset();
              }; break;
            case '3':
              {
                watch.Start();
                Console.Write("Введите, пожалуйста, индекс больше -1: ");
                int userIdx = int.Parse(Console.ReadLine());
                fixed (int* ptr = iArray)
                {
                  if (userIdx <= 0 || userIdx > iArray.Length - 1)
                  {
                    Console.WriteLine($"Введеный индекс должен не меньше 0 или не больше {iArray.Length - 1}");
                  }
                  else
                  {
                    Console.WriteLine($"Значение элемента, индекс которого меньше на 1: {*(ptr + (userIdx - 1))}");
                  }
                }
                watch.Stop();
                Console.WriteLine($"Ваше время работы пунктом 3: {watch.Elapsed}");
                watch.Reset();
              }; break;
            case '4': return;
            default: break;
          }
        }
      }
    }

    static void pr18()
    {
      string str = "";
      char letter;
      int countReplace = 0;
      StringBuilder res = new StringBuilder("");

      char pick;
      Console.WriteLine("Программа выводит пользовательское меню, где можно:\n" +
      $"\tЗаменить введенной буквой четные символы в строке\n" +
      "\tвывести полученного слово и количество замен" +
      "\t");

      for (; ; )
      {
        do
        {
          Console.WriteLine("1: Ввести строку");
          Console.WriteLine("2: прозвести замену четных символов в веденной строке");
          Console.WriteLine("3: Вывод новой строки и количества замен");
          Console.WriteLine("4: Выход из программы");
          Console.WriteLine("Выберите пункт меню");
          pick = char.Parse(Console.ReadLine());
        } while (pick > '4');

        switch (pick)
        {
          case '1':
            {
              Console.Write("Введите, пожалуйста, слово: ");
              str = Console.ReadLine();
            }; break;
          case '2':
            {
              Console.WriteLine("Введите, пожалуйста, букву, которой будут заменены четные символы");
              letter = char.Parse(Console.ReadLine());
              res = new StringBuilder(str);
              for (int i = 0; i < str.Length; i++)
              {
                if (i % 2 == 0)
                {
                  res[i] = letter;
                  countReplace++;
                }
              }
              Console.WriteLine("Замена произведена успешно!");
            }; break;
          case '3':
            {
              Console.WriteLine($"Полученное слово - {res}. \nКоличество замен - {countReplace}");
            }; break;
          case '4': return;
          default: break;
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

    static void pr22()
    {
      const string path = "input.dat", resultPath = "info.txt";
      string[] userInput;

      char pick;

      for (; ; )
      {
        do
        {
          Console.Clear();
          Console.WriteLine(
            $"Программа выводит пользовательское меню, где можно: \n" +
             "- Записать в байтовый файл строки, введенные пользователем\n" +
             "- Считать текст из байтового файла, убрать все пробелы из строк, определить длину строк\n" +
             "- Считать данные из результирующего текстового файла"
          );

          Console.WriteLine("1: Записать в байтовый файл строки");
          Console.WriteLine("2: Считать данные из результирующего текстового файла");
          Console.WriteLine("3: Выход из программы");
          Console.WriteLine("Выберите пункт меню");
          pick = char.Parse(Console.ReadLine());
        } while (pick > '3');

        switch (pick)
        {
          case '1':
            {
              Console.Clear();
              Console.WriteLine("1: Записать в байтовый файл строки");
              Console.Write("Введите текст: ");
              userInput = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

              using (BinaryWriter writer = new BinaryWriter(File.Open(path, FileMode.Create)))
              {
                foreach (string text in userInput) writer.Write(text);
              };

              using (StreamWriter SW = new StreamWriter(File.Open("info.txt", FileMode.Create)))
              {
                using (BinaryReader reader = new BinaryReader(File.Open(path, FileMode.Open)))
                {
                  int length = userInput.Length;

                  for (int i = 0; i < length; i++)
                  {
                    string info = reader.ReadString();
                  }
                  string woSpace = Regex.Replace(string.Join("", userInput), @"\s", "");
                  int woSpaceLength = Regex.Matches(string.Join(" ", userInput), @"\s").Count;
                  SW.Write(
                    $"Длина строк: {length} символа\n" +
                    $"Результат без пробелов: {woSpace}\n" +
                    $"Количество удаленных пробелов: {woSpaceLength}"
                  );
                };
              };
              Console.ReadKey();
            }; break;
          case '2':
            {
              Console.Clear();
              Console.WriteLine("2: Считать данные из результирующего текстового файла");
              using (StreamReader reader = new StreamReader(File.Open(resultPath, FileMode.Open)))
              {
                string resultData = reader.ReadToEnd();
                Console.WriteLine(resultData);
              };
              Console.ReadKey();
            }; break;
          case '3': return;
          default: break;
        }
      }
    }

    struct Processor
    {
      public string company;
      public string name;
      public string typeCooling;
      public double price;
      public double frequency;
      public int coreCount;
      public int cacheMemorySize;
    }
    static void pr23()
    {
      const string path = "pr23-input.dat";
      Processor processor;

      char pick;

      for (; ; )
      {
        do
        {
          Console.Clear();
          Console.WriteLine(
            $"Программа выводит пользовательское меню, где можно: \n" +
             "- Сохранить данные о процессоре, введенными пользователем\n" +
             "- Вывести данные о процессоре из двоичного файла на экран"
          );

          Console.WriteLine("1: Сохранить данные о процессоре, введенными пользователем");
          Console.WriteLine("2: Вывести данные о процессоре из двоичного файла на экран");
          Console.WriteLine("3: Выход из программы");
          Console.WriteLine("Выберите пункт меню");
          pick = char.Parse(Console.ReadLine());
        } while (pick > '3');

        switch (pick)
        {
          case '1':
            {
              Console.Clear();
              Console.WriteLine("1: Сохранить данные о процессоре, введенными пользователем");

              Console.WriteLine("Введите, пожалуйста, данные о процессоре: ");
              Console.Write("Название фирмы: ");
              processor.company = Console.ReadLine();
              Console.Write("Наименование: ");
              processor.name = Console.ReadLine();
              Console.Write("Тип охлаждения: ");
              processor.typeCooling = Console.ReadLine();
              Console.Write("Цена: ");
              processor.price = double.Parse(Console.ReadLine());
              Console.Write("Частота процессора: ");
              processor.frequency = double.Parse(Console.ReadLine());
              Console.Write("Количество ядер: ");
              processor.coreCount = int.Parse(Console.ReadLine());
              Console.Write("Размер кэш-памяти: ");
              processor.cacheMemorySize = int.Parse(Console.ReadLine());
              using (BinaryWriter writer = new BinaryWriter(File.Open(path, FileMode.Create)))
              {
                // writer.Write(
                //   $"Название фирмы: {processor.company}\n" +
                //   $"Наименование: {processor.name}\n" +
                //   $"Тип охлаждения: {processor.typeCooling}\n" +
                //   $"Цена: {processor.price}\n" +
                //   $"Частота процессора: {processor.frequency}\n" +
                //   $"Количество ядер: {processor.coreCount}\n" +
                //   $"Размер кэш-памяти: {processor.cacheMemorySize}"
                // );
                // writer.Write($"test: {32}");
                writer.Write(processor.company);
                writer.Write(processor.name);
                writer.Write(processor.typeCooling);
                writer.Write(processor.price);
                writer.Write(processor.frequency);
                writer.Write(processor.coreCount);
                writer.Write(processor.cacheMemorySize);
              };

              Console.ReadKey();
            }; break;
          case '2':
            {
              Console.Clear();
              Console.WriteLine("2: Вывести данные о процессоре из двоичного файла на экран, в соответсвие с критерием");
              using (BinaryReader reader = new BinaryReader(File.Open(path, FileMode.Open)))
              {
                // int count = reader.ReadInt32();
                // string t = reader.
                decimal frequency = reader.ReadDecimal();
                Console.WriteLine($"Частота процессора: {frequency}");
              };
              Console.ReadKey();
            }; break;
          case '3': return;
          default: break;
        }
      }
    }

    static void Main(string[] args)
    {
      // pr19(); // +
      // pr20(); // + 

      // pr22(); // +

      pr23();
      Console.ReadKey();
    }
  }
}