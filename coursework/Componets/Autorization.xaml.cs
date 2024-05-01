using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
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
    /// Логика взаимодействия для Autorization.xaml
    /// </summary>
    public partial class Autorization : UserControl
    {
        public Autorization()
        {
            InitializeComponent();
        }

        public event EventHandler ButtonClick;

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            // вызов события ButtonClick
            ButtonClick?.Invoke(this, EventArgs.Empty);
        }

        public string LoginValue
        {
            get { return LoginTextBox.Text; }
        }


        public string PasswordValue { 
            get { return Marshal.PtrToStringBSTR(Marshal.SecureStringToBSTR(PasswordBox.SecurePassword)); } 
        }
    }
}
