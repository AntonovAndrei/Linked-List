using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace DoublyLinkedList
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Minions";
            Console.ForegroundColor = ConsoleColor.Yellow;
            string path = @"C:\Users\пользователь\source\repos\Minions.minion";

            while (true)
            {
                Console.WriteLine("\nВыберите действие:\n" +
                "1. Добавить миньона\n" +
                "2. Вывести всех миньонов\n" +
                "3. Удалить миньона\n" +
                "4. Закончить работу программы.");
                int command = int.Parse(Console.ReadLine());

                if(command == 4)
                {
                    break;
                }
                else if (command == 3)
                {
                    try
                    {
                        var minion = new Minion();
                        Console.Write("Введите имя миньона которого вы хотитие удалить: ");
                        string name = Console.ReadLine();

                        List<string> allText = new List<string>();
                        using (StreamReader sr = new StreamReader(path, System.Text.Encoding.Default))
                        {
                            String line;
                            while ((line = sr.ReadLine()) != null)
                            {
                                allText.Add(line);
                            }
                        }


                        bool isDeleted = false;
                        for(int i = 0; i < allText.Count; i++)
                        {
                            if (allText[i].Contains(name))
                            {
                                for(int k = 0; k < 3; k++)
                                { 
                                    allText.RemoveAt(i);
                                }
                                isDeleted = true;
                            }
                        }
                        if (isDeleted)
                        {
                            Console.WriteLine("Миньон успешно удален");
                        }
                        else
                        {
                            Console.WriteLine("Такого миньона нет");
                        }

                        using (StreamWriter sw = new StreamWriter(path, false))
                        {
                            for (int j = 0; j < allText.Count; j++)
                                sw.WriteLine(allText[j]);
                        }
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                    }
                }
                else if(command == 2)
                {
                    String line;
                    try
                    {
                        StreamReader sr = new StreamReader(path);
                        byte counter = 1;
                        var minion = new Minion();
                        line = sr.ReadLine();
                        while (line != null)
                        {
                            if (!line.Contains("Ї"))
                            {
                                if (counter == 1)
                                {
                                    minion.Name = line;
                                }
                                else if (counter == 2)
                                {
                                    int value;
                                    int.TryParse(string.Join("", line.Where(c => char.IsDigit(c))), out value);
                                    minion.Age = value;
                                }
                                else
                                {
                                    Console.WriteLine("Произошла какая то ошибка.");
                                }
                                ++counter;
                            }
                            else
                            {
                                counter = 1;
                                minion.PrintMinion();
                            }
                            line = sr.ReadLine();
                        }
                        sr.Close();
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                    }
                }
                else if(command == 1)
                {
                    var minion = new Minion();
                    Console.Write("Введите имя миньона: ");
                    minion.Name = Console.ReadLine();
                    Console.Write("Введите возраст миньона: ");
                    minion.Age = int.Parse(Console.ReadLine());
                    try
                    {
                        using (StreamWriter sw = File.AppendText(path))
                        {
                            sw.WriteLine(minion.Name);
                            sw.WriteLine(minion.Age);
                            sw.WriteLine("Ї");
                        }
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                    }
                }
                else
                {
                    Console.WriteLine("Введите правильную комманду!");
                }
            }
        }
    }
}