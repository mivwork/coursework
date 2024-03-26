using model.DataAccess;
using Prism.Commands;
using Prism.Mvvm;
using System.Windows;

namespace coursework.ViewModels
{
    public class MainWindowViewModel : BindableBase
    {
        private string _title = "Prism Application";
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

        public MainWindowViewModel()
        {
            ShowMessageCommand = new DelegateCommand(ShowMessage);
            ShowMessage();
        }

        public DelegateCommand ShowMessageCommand { get; private set; }

        private void ShowMessage()
        {
            ConnectDB A = new ConnectDB();
            MessageBox.Show(A.CheckUserCredentials());
        }
    }
}
