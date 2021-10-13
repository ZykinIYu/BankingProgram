using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingProgram
{
    class Manager : ConsultantUsers
    {
        /// <summary>
        /// Поле временного хранения
        /// </summary>
        private string changedFields;

        /// <summary>
        /// Свойство поля временного хранения
        /// </summary>
        public string СhangedFields
        {
            get { return this.changedFields; }
            set { this.changedFields = value; }
        }

        public Manager(ulong Id, string Surname, string Name, string MiddleName, string PhoneNumber, string SeriesNumberPassport, DateTime DateTimeEntryModified, string WhatDataChanged, string TypeChange, string WhoChangedData)
            : base (Id, Surname, Name, MiddleName, PhoneNumber, SeriesNumberPassport, DateTimeEntryModified, WhatDataChanged, TypeChange, WhoChangedData)
        {
            
        }

        /// <summary>
        /// Метод печати элементов
        /// </summary>
        public override string Print()
        {
            return $"{Id}\t{Surname}\t{Name}\t{MiddleName}\t{PhoneNumber}\t{SeriesNumberPassport}\t{DateTimeEntryModified}\t{WhatDataChanged}\t{TypeChange}\t{WhoChangedData}";
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
        public override void ParameterСhange(ulong id, string Surname, string Name, string MiddleName, string PhoneNumber, string SeriesNumberPassport, List<ConsultantUsers> user, List<Manager> userM)
        {
            user.FindAll(us => us.Id == Convert.ToUInt64(id)).ForEach(us => us.Surname = Surname);
            user.FindAll(us => us.Id == Convert.ToUInt64(id)).ForEach(us => us.Name = Name);
            user.FindAll(us => us.Id == Convert.ToUInt64(id)).ForEach(us => us.MiddleName = MiddleName);
            user.FindAll(us => us.Id == Convert.ToUInt64(id)).ForEach(us => us.PhoneNumber = PhoneNumber);
            user.FindAll(us => us.Id == Convert.ToUInt64(id)).ForEach(us => us.SeriesNumberPassport = SeriesNumberPassport);
            user.FindAll(us => us.Id == Convert.ToUInt64(id)).ForEach(us => us.DateTimeEntryModified = DateTime.Now);
            user.FindAll(us => us.Id == Convert.ToUInt64(id)).ForEach(us => us.WhatDataChanged = changedFields);
            user.FindAll(us => us.Id == Convert.ToUInt64(id)).ForEach(us => us.TypeChange = "Изменена запись");
            user.FindAll(us => us.Id == Convert.ToUInt64(id)).ForEach(us => us.WhoChangedData = "Менеджер");
            userM.FindAll(us => us.Id == Convert.ToUInt64(id)).ForEach(us => us.Surname = Surname);
            userM.FindAll(us => us.Id == Convert.ToUInt64(id)).ForEach(us => us.Name = Name);
            userM.FindAll(us => us.Id == Convert.ToUInt64(id)).ForEach(us => us.MiddleName = MiddleName);
            userM.FindAll(us => us.Id == Convert.ToUInt64(id)).ForEach(us => us.PhoneNumber = PhoneNumber);
            userM.FindAll(us => us.Id == Convert.ToUInt64(id)).ForEach(us => us.SeriesNumberPassport = SeriesNumberPassport);
            userM.FindAll(us => us.Id == Convert.ToUInt64(id)).ForEach(us => us.DateTimeEntryModified = DateTime.Now);
            userM.FindAll(us => us.Id == Convert.ToUInt64(id)).ForEach(us => us.WhatDataChanged = changedFields);
            userM.FindAll(us => us.Id == Convert.ToUInt64(id)).ForEach(us => us.TypeChange = "Изменена запись");
            userM.FindAll(us => us.Id == Convert.ToUInt64(id)).ForEach(us => us.WhoChangedData = "Менеджер");
        }

    }
}
