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
        public ulong Id { get; set; }

        /// <summary>
        /// Фамилия пользователя
        /// </summary>
        private string surname;

        /// <summary>
        /// Свойство для чтения фамилии пользователя
        /// </summary>
        public string Surname { get; set; }

        /// <summary>
        /// Имя пользователя
        /// </summary>
        private string name;

        /// <summary>
        /// свойствр для чтения имени пользователя
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Фамилия пользователя
        /// </summary>
        private string middleName;

        /// <summary>
        /// Свойство для чтения фамилии пользователя
        /// </summary>
        public string MiddleName { get; set; }

        /// <summary>
        /// Номер телефона пользователя
        /// </summary>
        private string phoneNumber;

        /// <summary>
        /// Свойство чтения и записи номера телефона
        /// </summary>
        public string PhoneNumber { get; set; }

        /// <summary>
        /// Серия и номер папорта пользователя
        /// </summary>
        private string seriesNumberPassport;

        /// <summary>
        /// Свойство чтения и записи номера телефона
        /// </summary>
        public string SeriesNumberPassport { get; set; }

        /// <summary>
        /// Дата и время изменения записи
        /// </summary>
        private DateTime dateTimeEntryModified;

        /// <summary>
        /// Свойство поля дата и время изменения записи
        /// </summary>
        public DateTime DateTimeEntryModified { get; set; }

        /// <summary>
        /// Поле показывающее какие данные изменены
        /// </summary>
        private string whatDataChanged;

        /// <summary>
        /// Свойство поля показывающее какие данные изменены
        /// </summary>
        public string WhatDataChanged { get; set; }

        /// <summary>
        /// Поле показывающее тип изменения
        /// </summary>
        private string typeChange;

        /// <summary>
        /// Свойство поля показывающее тип изменения
        /// </summary>
        public string TypeChange { get; set; }

        /// <summary>
        /// Поле показывающее кто изменил
        /// </summary>
        private string whoChangedData;

        /// <summary>
        /// Свойство поля показывающее кто изменил
        /// </summary>
        public string WhoChangedData { get; set; }

        /// <summary>
        /// Конструктор пользователей
        /// </summary>
        /// <param name="Id">Идентификатор</param>
        /// <param name="Surname">Фамилия</param>
        /// <param name="Name">Имя</param>
        /// <param name="MiddleName">Отчество</param>
        /// <param name="PhoneNumber">Номер телефона</param>
        /// <param name="SeriesNumberPassport">серия и номер паспорта</param>
        public ConsultantUsers(ulong Id, string Surname, string Name, string MiddleName, string PhoneNumber, string SeriesNumberPassport, DateTime DateTimeEntryModified, string WhatDataChanged, string TypeChange, string WhoChangedData)
        {
            this.id = Id;
            this.surname = Surname;
            this.name = Name;
            this.middleName = MiddleName;
            this.phoneNumber = PhoneNumber;
            this.seriesNumberPassport = SeriesNumberPassport;
            this.dateTimeEntryModified = DateTimeEntryModified;
            this.whatDataChanged = WhatDataChanged;
            this.typeChange = TypeChange;
            this.whoChangedData = WhoChangedData;
        }

        /// <summary>
        /// Метод печати элементов
        /// </summary>
        public virtual string Print()
        {
            return $"{id}\t{surname}\t{name}\t{middleName}\t{phoneNumber}\t{HidingSeriesAndNumberPassport()}\t{dateTimeEntryModified}\t{whatDataChanged}\t{typeChange}\t{whoChangedData}";
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

        /// <summary>
        /// Метод корректировки параметров пользователя
        /// </summary>
        /// <param name="id">Идентификатор</param>
        /// <param name="Surname">Фамилия</param>
        /// <param name="Name">Имя</param>
        /// <param name="MiddleName">Отчество</param>
        /// <param name="PhoneNumber">Номер телефона</param>
        /// <param name="SeriesNumberPassport">Серия и номер паспорта</param>
        /// <param name="user">Коллекция пользователей для консультанта</param>
        /// <param name="userM">Коллекция пользователей для менеджера</param>
        public virtual void ParameterСhange(ulong id, string Surname, string Name, string MiddleName, string PhoneNumber, string SeriesNumberPassport, List<ConsultantUsers> user, List<Manager> userM)
        {
            user.FindAll(us => us.Id == Convert.ToUInt64(id)).ForEach(us => us.phoneNumber = PhoneNumber);
            user.FindAll(us => us.Id == Convert.ToUInt64(id)).ForEach(us => us.dateTimeEntryModified = DateTime.Now);
            user.FindAll(us => us.Id == Convert.ToUInt64(id)).ForEach(us => us.whatDataChanged = "Изменено: phoneNumber");
            user.FindAll(us => us.Id == Convert.ToUInt64(id)).ForEach(us => us.typeChange = "Изменена запись");
            user.FindAll(us => us.Id == Convert.ToUInt64(id)).ForEach(us => us.whoChangedData = "Консультант");
            userM.FindAll(us => us.Id == Convert.ToUInt64(id)).ForEach(us => us.PhoneNumber = PhoneNumber);
            userM.FindAll(us => us.Id == Convert.ToUInt64(id)).ForEach(us => us.dateTimeEntryModified = DateTime.Now);
            userM.FindAll(us => us.Id == Convert.ToUInt64(id)).ForEach(us => us.whatDataChanged = "Изменено: phoneNumber");
            userM.FindAll(us => us.Id == Convert.ToUInt64(id)).ForEach(us => us.typeChange = "Изменена запись");
            userM.FindAll(us => us.Id == Convert.ToUInt64(id)).ForEach(us => us.whoChangedData = "Консультант");
        }
    }
}
