using model.DataAccess;
using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Windows;

namespace coursework.ViewModels
{
    public class MainWindowViewModel : BindableBase
    {
        private string _title = "Prism Application";
        MyDbContext A = new MyDbContext();

        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

        public string _DatabaseConnectionStatus;

        public string DatabaseConnectionStatus
        {
            get { return _DatabaseConnectionStatus; }
            set { SetProperty(ref _DatabaseConnectionStatus, value); }
        }

        public MainWindowViewModel()
        {
            //ShowMessage();
            _DatabaseConnectionStatus = A.CheckUserCredentials();
        }

        private void ShowMessage()
        {
            MessageBox.Show(A.CheckUserCredentials()); //Проверка подлючения
        }
    }
}
