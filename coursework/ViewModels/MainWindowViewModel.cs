using model.DataAccess;
using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Windows;
using System.Windows.Controls;

namespace coursework.ViewModels
{
    public class MainWindowViewModel : BindableBase
    {
        private readonly AutorizationService autorizationService;
        public string _DatabaseConnectionStatus;

        public MainWindowViewModel(AutorizationService autorizationService)
        {
            this.autorizationService = autorizationService;
            _DatabaseConnectionStatus = autorizationService.CheckUserCredentials();
        }

        private string _title = "Clock Service";
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

        public string DatabaseConnectionStatus
        {
            get { return _DatabaseConnectionStatus; }
            set { SetProperty(ref _DatabaseConnectionStatus, value); }
        }
    }
}
