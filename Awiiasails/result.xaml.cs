using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Awiiasails
{
    public partial class result : Window
    {

        public result(string city, List<passanger> passengers)
        {
            InitializeComponent();
            double totalCost = 0;

            foreach (passanger passenger in passengers)
            {
                ticket ticket = new ticket(passenger, city, DateTime.Now.ToString());
                totalCost += ticket.Cost; //итоговая суммма
                // Выводим информацию о пассажире и данные о билете
                LB_result.Items.Add($"Данные пассажира:\n{passenger.ToString()}\nБилет пассажира:\n{ticket.ToString()}\n");
            }

            label_result.Content = $"ИТОГО: {totalCost} руб.";
        }

    }
}


