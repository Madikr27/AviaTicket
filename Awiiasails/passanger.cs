using System;
using System.Collections.Generic;
using System.Data;
using System.IO.Pipes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Awiiasails
{

    public class passanger
    {
        private string name;
        private string familiya;
        private string bornDate;
        private string pasportSeries;
        private string pasportNumner;


        public passanger(string name, string familiya, string bornDate, string pasportSeries, string pasportNumber)
        {
            this.name = name;
            this.familiya = familiya;
            this.bornDate = bornDate;
            this.pasportSeries = pasportSeries;
            this.pasportNumner = pasportNumber;
        }
        public string FirstName { get { return name; } } //имя
        public string LastName { get { return familiya; } } // фамилия
        public string DateOfBirth { get { return bornDate; } } // дата рождания
        public string Series { get { return pasportSeries; } } // серия паспорта
        public string Number { get { return pasportNumner; } } //номер паспорта


        public override string ToString()
        {
            return $"ФИО: {FirstName} {LastName}, Дата рождения: {DateOfBirth}, Серия: {Series}, Номер: {Number}"; //вывыод 
        }
    }

    public class PersonList
    {
        public static List<int> Man { get; set; } = new List<int>();
        public static List<int> Children { get; set; } = new List<int>();
    }
}
