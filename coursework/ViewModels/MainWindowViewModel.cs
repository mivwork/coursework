using coursework.Componets;
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

        public MainWindowViewModel(AutorizationService autorizationService, ClockService clockService)
        {
            this.autorizationService = autorizationService;
            this.clockService = clockService;
            _DatabaseConnectionStatus = autorizationService.CheckUserCredentials();
        }

        private readonly ClockService clockService;

        

        private string _title = "Prism Application";
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


    }
}
