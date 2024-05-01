using model.DataAccess;
using model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
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
    /// Логика взаимодействия для Table.xaml
    /// </summary>
    public partial class Table : UserControl
    {
        MyDbContext C = new MyDbContext();
        public Table()
        {
            InitializeComponent();

            List<Clock> objects = C.getDataClock();

            dataGrid.ItemsSource = objects;

        }
    }
}
