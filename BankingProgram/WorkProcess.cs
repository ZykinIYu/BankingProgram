using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingProgram
{
    class WorkProcess
    {
        ConsultantUsers cu;
        List<ConsultantUsers> user;
        private ulong id;
        Random randomize;
        string proofWork;
        string typeEmployee;
        string correctedUser;
        string newParameterValue;

        /// <summary>
        /// Старт программы
        /// </summary>
        public void Start()
        {
            user = new List<ConsultantUsers>();
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
                switch (typeEmployee)
                {
                    case "1":
                        WorkUnderRoleConsultant();
                        break;

                    case "2":
                        break;
                }
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
            for (int i = 1; i < 21; i++)
            {
                user.Add(new ConsultantUsers(NumberId(), $"Фамилия {i}", $"Имя {i}", $"Отчество {i}", Convert.ToString(80000000000 + randomize.Next(800000000, 900000000)), Convert.ToString(1000000000 + randomize.Next(100000000, 999999999))));
            }
        }

        /// <summary>
        /// Вывод в консоль всех пользователей
        /// </summary>
        private void ReadUser()
        {
            for (int i = 0; i < user.Count; i++)
            {
                Console.WriteLine($"{user[i].Print()}");
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
                            user[i].ParameterСhange(Convert.ToUInt64(correctedUser), newParameterValue, user);
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
        /// Метод описывающий работу под ролью консультанта
        /// </summary>
        private void WorkUnderRoleConsultant()
        {
            for (; ; )
            {
                Console.Clear();
                ReadUser();
                DataCorrection();
                Console.Clear();
                Console.Write($"Необходимо еще выполнить работы в роли консультанта? да/нет: ");
                proofWork = Console.ReadLine().ToLower();
                if (proofWork == "нет")
                {
                    break;
                }
            }
        }
    }
}
