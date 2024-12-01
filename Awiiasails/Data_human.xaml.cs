using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Text.RegularExpressions;
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
    /// <summary>
    /// Логика взаимодействия для Data_human.xaml
    /// </summary>
    public partial class Data_human : Window
    {
       
        private string City;
        private int passengersCount;
        List<passanger> passengers = new List<passanger>();
        // Конструктор
        public Data_human(string city, int man, int chilfren)
        {
            InitializeComponent();
            City = city;
            passengersCount = (man + chilfren);
        }

        public void btn_add_Click(object sender, RoutedEventArgs e)
        {

            // Получаем данные из текстовых полей
            string name = TB_name.Text; // Текстовое поле для имени
            string familiya = TB_famaliya.Text; // Текстовое поле для фамилии
            string dateOfBirth = DateBorn.Text; // Текстовое поле для даты рождения
            string series = TB_PASPORT_seria.Text; // Текстовое поле для серии паспорта
            string number = TB_PASPORT_number.Text; // Текстовое поле для номера паспорта


            // Создаем экземпляр класса passanger
            passanger _passager = new passanger(name, familiya, dateOfBirth, series, number);
            passengers.Add(_passager);
            // Вывод информации в ListBox
            LB_data_passagires.Items.Add(_passager); 


            int man = PersonList.Man.Sum();
            int children = PersonList.Children.Sum();
            int sum_human = man + children;

            if(sum_human != LB_data_passagires.Items.Count)
            {
                btn_next.IsEnabled = false;
                btn_add_human.IsEnabled = true;
                btn_edit.IsEnabled = false;

            }
            else
            {
                btn_next.IsEnabled = true;
                btn_add_human.IsEnabled = false;
                btn_edit.IsEnabled = true;
            }
        }
        private void LB_calendarClosed(object sender, RoutedEventArgs e)
        {
            DateTime dateBrith = DateBorn.SelectedDate.Value;
            int  age = DateTime.Now.Year - dateBrith.Year;
            if (age < 14)
            {
                TB_PASPORT_seria.Text = "";
                TB_PASPORT_number.Text = "";
                TB_PASPORT_seria.IsEnabled = false;
                TB_PASPORT_number.IsEnabled = false;
            }
            else 
            {
                TB_PASPORT_number.IsEnabled = true;
                TB_PASPORT_seria.IsEnabled = true;
            }
        }
        private void TextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            var regex = new Regex("[^a-zA-Za-яА-Я]");
            e.Handled = regex.IsMatch(e.Text); // Запретить ввод, если текст не соответствует
        }
        private void btn_edit_Click(object sender, RoutedEventArgs e)
        {
            if (LB_data_passagires.SelectedIndex == -1) return;
            passengers[LB_data_passagires.SelectedIndex] = null;
            string name = TB_name.Text;
            string surname = TB_famaliya.Text;
            string bornDate = DateBorn.Text;
            string pasport_Series, pasport_Number;
            try
            {
                pasport_Series = TB_PASPORT_seria.Text;
                pasport_Number = TB_PASPORT_number.Text;
            }
            catch
            {
                return;
            }
            if (name == "" || surname == "" || bornDate == "" || pasport_Series == "" || pasport_Number == "") return;

            passanger passenger = new passanger(name, surname, bornDate, pasport_Series, pasport_Number);
            passengers[LB_data_passagires.SelectedIndex] = passenger;
            LB_data_passagires.Items.Insert(LB_data_passagires.SelectedIndex, passenger.ToString());
            LB_data_passagires.Items.RemoveAt(LB_data_passagires.SelectedIndex);
        }
        public void btn_next_Click(object sender, RoutedEventArgs e)
        {
            // Использование списка пассажиров
            result result = new result(City,passengers);
            result.Show();
            this.Close();
        }
    }
}
