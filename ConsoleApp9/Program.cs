using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using System.Xml.Linq;
using System.Data;
using static System.Net.Mime.MediaTypeNames;
using System.Runtime.InteropServices;

namespace ConsoleApp9
{
    
    class Program
    {
        
        static void Main(string[] args)
        {
            //  создаём пустой список с типом данных Contact
            var phoneBook = new List<Contact>();

            // добавляем контакты
            phoneBook.Add(new Contact("Игорь", "Николаев", 79990000001, "igor@example.com"));
            phoneBook.Add(new Contact("Сергей", "Довлатов", 79990000010, "serge@example.com"));
            phoneBook.Add(new Contact("Анатолий", "Карпов", 79990000011, "anatoly@example.com"));
            phoneBook.Add(new Contact("Валерий", "Леонтьев", 79990000012, "valera@example.com"));
            phoneBook.Add(new Contact("Сергей", "Брин", 799900000013, "serg@example.com"));
            phoneBook.Add(new Contact("Иннокентий", "Смоктуновский", 799900000013, "innokentii@example.com"));
            //Цикл для повторения запросов
            while (true)
            {
                var keychar = Console.ReadKey().KeyChar;
                Console.Clear();
                //проверка на введённый Символ
                if (!Char.IsDigit(keychar))
                {
                    Console.WriteLine("Ошибка ввода");
                }else
                {
                    //реализация запроса 
                    IEnumerable<Contact> timeList = null;
                    switch (keychar)
                    {
                        case '1':
                            timeList = phoneBook.Take(2);
                            break;
                        case '2':
                            timeList = phoneBook.Skip(2).Take(2);
                            break;
                        case '3':
                            timeList = phoneBook.Skip(4).Take(2);
                            break;

                    }
                    //Линк запрос для сортировки по имени, а после по фомилии 
                    var Sort = from sort in timeList
                               orderby sort.Name, sort.LastName
                               select sort;
                    //цикл ввывода 
                    foreach (var contact in timeList)
                    {
                        Console.WriteLine("Имя:" + contact.Name + "\nФамилия:" + contact.LastName + "\nПочта:" + contact.Email + "\nНомер телефона:" + contact.PhoneNumber);
                    }
                }       
            }
        }   
    }
}
