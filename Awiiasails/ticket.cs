using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Markup;

namespace Awiiasails
{

    public class ticket
    {
        Dictionary<string, int> cities = new Dictionary<string, int>() //список городов с ценами
    {
        {"Астрахань", 8000},
        {"Москва", 11000},
        {"Томск", 9000},
        {"Адлер", 3000}
    };

        private passanger passanger;
        private string where;
        private double cost;
        private string buyingDate;

        public ticket(passanger passanger, string where, string buyingDate)
        {
            this.passanger = passanger;
            this.where = where;
            this.buyingDate = buyingDate;
            this.cost = CalculateCost(where);
        }

        public double Cost { get { return this.cost; } }

        private double CalculateCost(string city)
        {
            if (cities.TryGetValue(city, out int baseCost))
            {
                DateTime bornDate = Convert.ToDateTime(passanger.DateOfBirth);
                int age = CalculateAge(bornDate);

                if (age <= 2) return 0; // Бесплатно
                else if (age <= 12) return baseCost * 0.5; // Половина стоимости

                return baseCost; // Полная стоимость
            }

            return null; // Если город не найден, возвращаем ничего
        }

        private int CalculateAge(DateTime bornDate)
        {
            int age = DateTime.Now.Year - bornDate.Year;
            if (DateTime.Now.Month < bornDate.Month || (DateTime.Now.Month == bornDate.Month && DateTime.Now.Day < bornDate.Day))
                age--;
            return age;
        }

        public override string ToString()
        {
            return $"Город: {where}, Дата покупки: {buyingDate}, Стоимость: {cost} руб.";
        }
    }

}