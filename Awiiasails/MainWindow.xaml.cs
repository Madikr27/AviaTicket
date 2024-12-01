using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Awiiasails
{

    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();

        }

        private void btn_next_Click(object sender, RoutedEventArgs e)
        {
            if (CB_select_city.SelectedItem != null)
            {

                // Создание второй формы и передача объекта Ticket
                human human = new human(CB_select_city.SelectionBoxItem.ToString());
                human.Show();
                this.Close(); // Если хотите скрыть первую форму
            }
            else
            {
                MessageBox.Show("Пожалуйста, выберите город.");
            }
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // Проверяем, выбраны ли элементы в обоих ComboBox
            btn_next.IsEnabled = CB_select_city.SelectedItem != null;
        }
    }
}
