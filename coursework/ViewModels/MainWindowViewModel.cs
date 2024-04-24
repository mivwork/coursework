using model.DataAccess;
using Prism.Commands;
using Prism.Mvvm;
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

        public MainWindowViewModel()
        {
            ShowMessage();
        }

        private void ShowMessage()
        {
            MessageBox.Show(A.CheckUserCredentials()); //Проверка подлючения
        }
    }
}
