using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
 using System.Xml.Linq;

namespace REGISTRATIONAPP
{
    class Program
    {
        static void Main(string[] args)
        {
            User user = new User();
            Registration registration = new Registration();
            int i = 0;
            int a;
            Console.WriteLine("1.Регистрация");
            Console.WriteLine("2.Вход");
            Console.WriteLine("3.Выход");

            while (!int.TryParse(Console.ReadLine(), out i))
            {
                Console.WriteLine("Введите цифру ");
            }
            a = i;

            while (a != 1 && a != 2 && a != 3)
            {
                Console.WriteLine("Введите цифру 1, 2, 3");
                while (!int.TryParse(Console.ReadLine(), out i))
                {
                    Console.WriteLine("Введите цифру 1, 2, 3");
                }
                a = i;
            }

            if (a == 1)
            {
                
                FillUser(user);
                registration.Registr(user);
                Console.WriteLine("Вы успешно зарегистрированы");
            }
            else if (a == 2)
            {
                Console.WriteLine("Не сделал");
                Console.ReadLine();
            }
            else if (a == 3)
            {
                Environment.Exit(0);
            };        
        }

        static private bool IsEmailSyntaxValid(string emailToValidate)
        {
            return System.Text.RegularExpressions.Regex.IsMatch(emailToValidate,
                @"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$");
        }

        static void FillUser(User user)
        {
           // User user = new User();
            Console.WriteLine("Введите Email");
            while (IsEmailSyntaxValid(user.Email=Console.ReadLine()) == false)
            {
                Console.WriteLine("Некоректный Email");
            }
            

            
            string pattern = @"^((8|\+7)[\- ]?)?(\(?\d{3}\)?[\- ]?)?[\d\- ]{7,10}$";
            while (true)
            {
                Console.WriteLine("Введите номер телефона");
                user.Phone = Console.ReadLine();

                if (Regex.IsMatch(user.Phone, pattern, RegexOptions.IgnoreCase))
                {
                    Console.WriteLine("Номер подтвержден");
                    break;
                }
                else
                {
                    Console.WriteLine("Некорректный номер");
                }
            }

            Console.WriteLine("Введите пароль");
            user.Password = Console.ReadLine();

            Console.WriteLine("Введите город");
            user.City = Console.ReadLine();

            Console.WriteLine("Введите возраст");
            int i = 0;
            while (!int.TryParse(Console.ReadLine(), out i))
            {
                Console.WriteLine("Некоректный возраст");
            }
            user.Age = i;
        }

    }
}

