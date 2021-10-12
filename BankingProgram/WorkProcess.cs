﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingProgram
{
    class WorkProcess
    {
        List<ConsultantUsers> user;
        List<Manager> userM;
        private ulong id;
        Random randomize;
        string proofWork;
        string typeEmployee;
        string correctedUser;
        string newParameterValue;
        string newSurname;
        string newName;
        string newMiddleName;
        string newPhoneNumber;
        string newSeriesNumberPassport;

        /// <summary>
        /// Старт программы
        /// </summary>
        public void Start()
        {
            user = new List<ConsultantUsers>();
            userM = new List<Manager>();
            randomize = new Random();
            FillingCollectionWithUsers();
            LoginName();
        }

        /// <summary>
        /// Метод выбора под какой ролью будет запускаться программа
        /// </summary>
        private void LoginName()
        {
            for (; ; )
            {
                Console.Clear();
                Console.WriteLine($"Под кем хотите зайти?");
                Console.WriteLine($"1. Консультант");
                Console.WriteLine($"2. Менеджер");
                Console.Write($"Необходимо выбрать 1 или 2: ");
                typeEmployee = Console.ReadLine();
                WorkUnderRole();
                Console.Clear();
                Console.Write($"Необходимо еще выполнить работы в других ролях? да/нет: ");
                proofWork = Console.ReadLine().ToLower();
                if (proofWork == "нет")
                {
                    break;
                }
            }
            
        }

        /// <summary>
        /// Метод для наполнения коллекции пользователями
        /// </summary>
        private void FillingCollectionWithUsers()
        {
            for (int i = 0; i < 21; i++)
            {
                user.Add(new ConsultantUsers(NumberId(), $"Фамилия {i}", $"Имя {i}", $"Отчество {i}", Convert.ToString(80000000000 + randomize.Next(800000000, 900000000)), Convert.ToString(1000000000 + randomize.Next(100000000, 999999999))));
                userM.Add(new Manager(user[i].Id, user[i].Surname, user[i].Name, user[i].MiddleName, user[i].PhoneNumber, user[i].SeriesNumberPassport));
            }
        }

        /// <summary>
        /// Вывод в консоль всех пользователей
        /// </summary>
        private void ReadUser()
        {
            if (typeEmployee == "1")
            {
                for (int i = 0; i < user.Count; i++)
                {
                    Console.WriteLine($"{user[i].Print()}");
                }
            }

            if (typeEmployee == "2")
            {
                for (int i = 0; i < user.Count; i++)
                {
                    Console.WriteLine($"{userM[i].Print()}");
                }
            }
        }

        /// <summary>
        /// Метод определяющий наибольший Id и увеличивающий его на 1
        /// </summary>
        /// <returns></returns>
        private ulong NumberId()
        {
            id = 0;
            for (int i = 0; i < user.Count; i++)
            {
                if (user[i].Id > id)
                {
                    id = user[i].Id;
                }
            }
            id++;
            return id;
        }

        /// <summary>
        /// Метод для корректировки пользовательских данных
        /// </summary>
        private void DataCorrection()
        {
            if (typeEmployee == "1")
            {
                Console.WriteLine();
                Console.WriteLine($"Какие работы необходимо выполнить: ");
                Console.WriteLine($"1. Скорректировать номер телефона ");
                Console.Write($"Необходимо выбрать 1: ");

                switch (Console.ReadLine())
                {
                    case "1":
                        ChangingParametersConsultant();
                        break;
                }
            }

            if (typeEmployee == "2")
            {
                Console.WriteLine();
                Console.WriteLine($"Какие работы необходимо выполнить: ");
                Console.WriteLine($"1. Скорректировать данные ");
                Console.Write($"Необходимо выбрать 1: ");

                switch (Console.ReadLine())
                {
                    case "1":
                        ChangingParametersManager();
                        break;
                }
            }
        }

        /// <summary>
        /// Изменение параметров пользователей под ролью консультанта
        /// </summary>
        private void ChangingParametersConsultant()
        {
            Console.Clear();
            ReadUser();
            Console.WriteLine();
            Console.Write($"Введите id необходимого пользователя: ");
            correctedUser = Console.ReadLine();

            for (; ; )
            {
                Console.Clear();
                Console.Write($"Введите новый номер телефона: ");
                newParameterValue = Console.ReadLine();

                if (newParameterValue.Length == 11 && newParameterValue.All(char.IsDigit) == true)
                {
                    for (int i = 0; i < user.Count; i++)
                    {
                        if (user[i].Id == Convert.ToUInt64(correctedUser))
                        {
                            user[i].ParameterСhange(Convert.ToUInt64(correctedUser), user[i].Surname, user[i].Name, user[i].MiddleName, newParameterValue, user[i].SeriesNumberPassport, user, userM);
                        }
                    }
                }
                else
                {
                    Console.Clear();
                    Console.Write($"Номер телефона, является обязательным полем, оно не может быть пустым, должно содержать только цифры и иметь ровно 11 символов");
                    Console.ReadKey();
                }
                break;
            }
        }

        /// <summary>
        /// Изменение параметров пользователей под ролью менеджера
        /// </summary>
        private void ChangingParametersManager()
        {
            Console.Clear();
            ReadUser();
            Console.WriteLine();
            Console.Write($"Введите id необходимого пользователя: ");
            correctedUser = Console.ReadLine();

            for (; ; )
            {

                for (int i = 0; i < user.Count; i++)
                {
                    if (userM[i].Id == Convert.ToUInt64(correctedUser))
                    {
                        newSurname = userM[i].Surname;
                        newName = userM[i].Name;
                        newMiddleName = userM[i].MiddleName;
                        newPhoneNumber = userM[i].PhoneNumber;
                        newSeriesNumberPassport = userM[i].SeriesNumberPassport;
                        Console.Clear();
                        Console.Write($"Необходимо изменить фамилию? да/нет: ");
                        if (Console.ReadLine().ToLower() == "да")
                        {
                            Console.Clear();
                            Console.Write($"Введите новую фамилию: ");
                            newSurname = Console.ReadLine();
                        }

                        Console.Clear();
                        Console.Write($"Необходимо изменить имя? да/нет: ");
                        if (Console.ReadLine().ToLower() == "да")
                        {
                            Console.Clear();
                            Console.Write($"Введите новое имя: ");
                            newName = Console.ReadLine();
                        }

                        Console.Clear();
                        Console.Write($"Необходимо изменить отчество? да/нет: ");
                        if (Console.ReadLine().ToLower() == "да")
                        {
                            Console.Clear();
                            Console.Write($"Введите новое отчество: ");
                            newMiddleName = Console.ReadLine();
                        }

                        Console.Clear();
                        Console.Write($"Необходимо изменить номер телефона? да/нет: ");
                        if (Console.ReadLine().ToLower() == "да")
                        {
                            Console.Clear();
                            Console.Write($"Введите новый номер телефона: ");
                            var storage = Console.ReadLine();
                            if (storage.Length == 11 && storage.All(char.IsDigit) == true)
                            {
                                newPhoneNumber = storage;
                            }
                            else
                            {
                                Console.Clear();
                                Console.Write($"Номер телефона, является обязательным полем, оно не может быть пустым, должно содержать только цифры и иметь ровно 11 символов");
                                Console.ReadKey();
                            }
                        }

                        Console.Clear();
                        Console.Write($"Необходимо изменить серию и номер паспорта? да/нет: ");
                        if (Console.ReadLine().ToLower() == "да")
                        {
                            Console.Clear();
                            Console.Write($"Введите новую серию и номер паспорта: ");
                            var storage = Console.ReadLine();
                            if (storage.Length == 9 && storage.All(char.IsDigit) == true || storage.Length == 0 )
                            {
                                newSeriesNumberPassport = storage;
                            }
                            else
                            {
                                Console.Clear();
                                Console.Write($"Серия и номер паспорта должна содержать 9 цифр, либо можно поле не заполнять");
                                Console.ReadKey();
                            }
                        }
                        userM[i].ParameterСhange(Convert.ToUInt64(correctedUser), newSurname, newName, newMiddleName, newPhoneNumber, newSeriesNumberPassport, user, userM);
                    } 
                }
                break;
            }
        }

        /// <summary>
        /// Метод описывающий работу под ролью
        /// </summary>
        private void WorkUnderRole()
        {  
            for (; ; )
            {
                Console.Clear();
                ReadUser();
                DataCorrection();
                Console.Clear();
                Console.Write($"Необходимо еще выполнить работы? да/нет: ");
                proofWork = Console.ReadLine().ToLower();
                if (proofWork == "нет")
                {
                    break;
                }
            }
        }
    }
}
