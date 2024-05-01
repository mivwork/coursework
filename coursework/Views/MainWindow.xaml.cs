using coursework.Componets;
using model.DataAccess;
using model.Models;
using System;
using System.Windows;
using System.Windows.Controls;

namespace coursework.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Autorization autorization = new Autorization();
        MainTable1 mainTable1 = new MainTable1();

        Users users = new Users();
        MyDbContext B = new MyDbContext();

        public MainWindow()
        {
            InitializeComponent();
            contentControl.Content = autorization;
            autorization.ButtonClick += Component_ButtonClickLogin;
        }

        private void Component_ButtonClickLogin(object sender, EventArgs e)
        {
            if (B.LoginAndPassword(autorization.LoginValue) == true)
            {
                contentControl.Content = mainTable1;
            }
            else
            {
                MessageBox.Show("Не правильный логин или пароль");
            }
            
        }


    }
}
