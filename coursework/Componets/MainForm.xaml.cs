using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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

namespace coursework.Componets
{
    /// <summary>
    /// Логика взаимодействия для MainTable1.xaml
    /// </summary>
    public partial class MainForm : UserControl
    {
        Table table = new Table();

        User user = new User();

        public MainForm()
        {
            InitializeComponent();
            contentControl.Content = table;
        }

        private void TableButton_Click(object sender, RoutedEventArgs e)
        {
            contentControl.Content = table;
        }

        private void UserButton_Click(object sender, RoutedEventArgs e)
        {
            contentControl.Content = user;
        }
    }
}
