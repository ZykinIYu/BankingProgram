using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingProgram
{
    class Manager : ConsultantUsers
    {
        public Manager(ulong Id, string Surname, string Name, string MiddleName, string PhoneNumber, string SeriesNumberPassport)
            : base (Id, Surname, Name, MiddleName, PhoneNumber, SeriesNumberPassport)
        {
            
        }

        /// <summary>
        /// Метод печати элементов
        /// </summary>
        public override string Print()
        {
            return $"{Id}\t{Surname}\t{Name}\t{MiddleName}\t{PhoneNumber}\t{SeriesNumberPassport}";
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
            userM.FindAll(us => us.Id == Convert.ToUInt64(id)).ForEach(us => us.Surname = Surname);
            userM.FindAll(us => us.Id == Convert.ToUInt64(id)).ForEach(us => us.Name = Name);
            userM.FindAll(us => us.Id == Convert.ToUInt64(id)).ForEach(us => us.MiddleName = MiddleName);
            userM.FindAll(us => us.Id == Convert.ToUInt64(id)).ForEach(us => us.PhoneNumber = PhoneNumber);
            userM.FindAll(us => us.Id == Convert.ToUInt64(id)).ForEach(us => us.SeriesNumberPassport = SeriesNumberPassport);
        }

    }
}
