using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingProgram
{
    class ConsultantUsers
    {
        /// <summary>
        /// идентификатор пользователя
        /// </summary>
        private ulong id;

        /// <summary>
        /// Свойство чтения и записи идентификатора
        /// </summary>
        public ulong Id
        {
            get { return this.id; }
            set { this.id = value; }
        }

        /// <summary>
        /// Фамилия пользователя
        /// </summary>
        private string surname;

        /// <summary>
        /// Свойство для чтения фамилии пользователя
        /// </summary>
        public string Surname
        {
            get { return this.surname; }
        }

        /// <summary>
        /// Имя пользователя
        /// </summary>
        private string name;

        /// <summary>
        /// свойствр для чтения имени пользователя
        /// </summary>
        public string Name
        {
            get { return this.name; }
        }

        /// <summary>
        /// Фамилия пользователя
        /// </summary>
        private string middleName;

        /// <summary>
        /// Свойство для чтения фамилии пользователя
        /// </summary>
        public string MiddleName
        {
            get { return this.middleName; }
        }

        /// <summary>
        /// Номер телефона пользователя
        /// </summary>
        private string phoneNumber;

        /// <summary>
        /// Свойство чтения и записи номера телефона
        /// </summary>
        public string PhoneNumber
        {
            get { return this.phoneNumber; }
            set { this.phoneNumber = value; }
        }

        /// <summary>
        /// Серия и номер пспорта пользователя
        /// </summary>
        private string seriesNumberPassport;

        /// <summary>
        /// Конструктор пользователей
        /// </summary>
        /// <param name="Id">Идентификатор</param>
        /// <param name="Surname">Фамилия</param>
        /// <param name="Name">Имя</param>
        /// <param name="MiddleName">Отчество</param>
        /// <param name="PhoneNumber">Номер телефона</param>
        /// <param name="SeriesNumberPassport">серия и номер паспорта</param>
        public ConsultantUsers(ulong Id, string Surname, string Name, string MiddleName, string PhoneNumber, string SeriesNumberPassport)
        {
            this.id = Id;
            this.surname = Surname;
            this.name = Name;
            this.middleName = MiddleName;
            this.phoneNumber = PhoneNumber;
            this.seriesNumberPassport = SeriesNumberPassport;
        }

        /// <summary>
        /// Метод печати элементов
        /// </summary>
        public string Print()
        {
            return $"{id}\t{surname}\t{name}\t{middleName}\t{phoneNumber}\t{HidingSeriesAndNumberPassport()}";
        }

        /// <summary>
        /// Метод скрывающий серию и номер паспорта
        /// </summary>
        /// <returns></returns>
        private string HidingSeriesAndNumberPassport()
        {
            if (seriesNumberPassport.Length != 0)
            {
                return $"**********";
            }
            else
            {
                return Convert.ToString(seriesNumberPassport);
            }
        }

    }
}
