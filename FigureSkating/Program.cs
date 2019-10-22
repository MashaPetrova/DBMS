using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace FigureSkating
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = 50;
            while (n != 0)
            {
                Console.WriteLine("\nНажмите необходимое число");
                Console.WriteLine("1 - просмотр списка фигуристов");
                Console.WriteLine("2 - просмотр списка соревнований");
                Console.WriteLine("3 - просмотр участников каждого соревнования");
                Console.WriteLine("4 - добавление фигуриста");
                Console.WriteLine("5 - добавление соревнования");
                Console.WriteLine("6 - добавление фигуриста в соревнование");

                n =  Convert.ToInt32(Console.ReadLine());

                //Добавить спортсмена, добавить соревнование, добавить спортсмена/соревнование
                //вывести спортсменов, вывести соревнования, вывести количество участников на однос соревноании
                using (FSContext db = new FSContext())
                {
                    switch (n)
                    {
                        case 1:
                            var Fs = db.FigureSkaters.ToList();
                            if (Fs.Count == 0)
                                Console.WriteLine("\nТаблица пуста!");
                            else
                            {
                                Console.WriteLine("\nId     Имя    Фамилия   Страна   Возраст");
                                foreach (var fs in Fs)
                                    Console.WriteLine("{0}: {1}  {2}   |  {3}  |   {4} лет  ", fs.Id, fs.FirstName, fs.LastName, fs.Country, fs?.Age);                               
                            }
                            break;

                        case 2:
                            var Comp = db.Competitions.ToList();
                            if (Comp.Count == 0)
                                Console.WriteLine("\nТаблица пуста!");
                            else
                            {
                                Console.WriteLine("\nId     Название       Место проведения");
                                foreach (var comp in Comp)
                                    Console.WriteLine("{0}: {1}  |  {2}, {3}  ", comp.Id, comp.Name, comp.City, comp.Country);
                            }
                            break;

                        case 3:
                            var Compet = db.Competitions.ToList();
                            if (Compet.Count == 0)
                                Console.WriteLine("\nТаблица пуста!");
                            else
                            {
                                foreach (Competition c in db.Competitions.Include(c => c.FigureSkaters))
                                {
                                   Console.WriteLine("\n[{0}]{1} - {2}  участников", c.Id, c.Name, c.FigureSkaters.Count);
                                   Console.WriteLine("Участники");

                                   foreach (FigureSkater fs in c.FigureSkaters)
                                        Console.WriteLine("({0}){1}  {2}", fs.Id, fs.FirstName, fs.LastName);                               
                                }
                            }
                            break;

                        case 4:
                            Console.WriteLine("Введите имя");
                            string fName = Console.ReadLine();

                            Console.WriteLine("Введите фамилию");
                            string lName = Console.ReadLine();

                            Console.WriteLine("Введите возраст, если он неизвестен, просто нажмите Enter");

                            int ageInt = 0; bool ageBool = false;

                            try
                            {
                                string ageStr = Console.ReadLine();
                                if (ageStr != "")
                                {
                                    ageInt = Convert.ToInt32(ageStr);
                                    ageBool = true;
                                } 
                            }
                            catch(Exception)
                            {
                                Console.WriteLine("Вы ввели не число!");
                            }                  
                            
                            
                            Console.WriteLine("Введите страну");
                            string country = Console.ReadLine();

                            if (fName != null && lName != null && country != null)
                            {
                                var figSk = new FigureSkater()
                                {
                                    FirstName = fName,
                                    LastName = lName,
                                    Country = country,
                                    Age = null
                                };
                                if (ageBool) figSk.Age = ageInt;
                                db.FigureSkaters.Add(figSk);
                                db.SaveChanges();
                            }
                            else Console.WriteLine("\nВы ввели не все значения!");
                            break;

                        case 5:
                            Console.WriteLine("\nВведите название соревноания");
                            string name = Console.ReadLine();

                            Console.WriteLine("Введите город проведения");
                            string city = Console.ReadLine();

                            Console.WriteLine("Введите страну проведения");
                            string ccountry = Console.ReadLine();

                            if (name != null && city != null && ccountry != null)
                            {
                                var comp = new Competition()
                                {
                                    Name = name,
                                    City = city,
                                    Country = ccountry
                                };

                                db.Competitions.Add(comp);
                                db.SaveChanges();
                            }
                            else Console.WriteLine("\nВы ввели не все значения!");
                            break;

                        case 6:

                            try
                            {
                                Console.WriteLine("Введите идентификатор соревнования");
                                int c = Convert.ToInt32(Console.ReadLine());
                                Console.WriteLine("Введите идентификатор фигуриста");
                                int fs = Convert.ToInt32(Console.ReadLine());

                                Competition C = db.Competitions.Find(c);
                                FigureSkater FS = db.FigureSkaters.Find(fs);
                                C.FigureSkaters.Add(FS);
                                db.SaveChanges();
                                   
                            }
                            catch (Exception)
                            {
                                Console.WriteLine("\nВы что-то ввели не так! " +
                                    "\nПроверьте идентификаторы (вызовите пункт 1 и пункт 2), а также убедитетсь, что добавляемой вами записи еще не существует" +
                                    "\n(вызовите пункт 3 и посмотрите идентификаторы соревнований и фигуристов, принимающих в них участие)");
                            }
                            break;
                    }


                }
            }

        }
    }
}
