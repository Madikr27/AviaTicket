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
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Awiiasails
{
    /// <summary>
    /// Логика взаимодействия для human.xaml
    /// </summary>
    public partial class human : Window
    {

        public string City;


        public human(string city)
        {
            InitializeComponent();


            TB_child.TextChanged += Input_TextChanged;
            TB_human.TextChanged += Input_TextChanged;
            City = city;
        }


        private void btn_next_Click(object sender, RoutedEventArgs e)
        {

            int man = Int32.Parse(TB_human.Text);
            int children = Int32.Parse(TB_child.Text);
            int result = man + children;

            if (man < 0 | man == 0 & children != 0 | children == 0)
            {
                MessageBox.Show("Должен быть хотя бы быть 1 взрослый");
            }
            else if (result > 100)
            {
                MessageBox.Show("Кол-во пассажиров больше 100!");
            }

            else
            {
                //переход на новую форму
                Data_human data_human = new Data_human(City, man, children);
                data_human.Show();
                this.Close();
            }

            // Сохраните данные в список
            PersonList.Man.Add(man);
            PersonList.Children.Add(children);


        }
        private void Input_TextChanged(object sender, TextChangedEventArgs e){
                // Проверяем, заполнены ли оба поля
                btn_next.IsEnabled = !string.IsNullOrWhiteSpace(TB_child.Text) && !string.IsNullOrWhiteSpace(TB_human.Text);
        }
        private void TextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {

            var regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text); // Запретить ввод, если текст не соответствует
        }
    }
}
