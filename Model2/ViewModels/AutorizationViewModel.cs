using model.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows;
using Prism.Mvvm;
using Model2.Views;
using System.Windows.Input;
using Prism.Commands;
using Prism.Regions;
using System.Net;
using System.Security;
using Prism.Events;

namespace Model2.ViewModels;

internal class AutorizationViewModel : BindableBase
{
    private readonly AutorizationService autorizationService;
    private readonly IRegionManager regionManager;

    public AutorizationViewModel(AutorizationService autorizationService, IRegionManager regionManager)
    {
        this.autorizationService = autorizationService;
        this.regionManager = regionManager;
        LoginCommand = new DelegateCommand(TryLogin);
    }

    public ICommand LoginCommand { get; init; }

    private string _loginValue;
    public string LoginValue
    {
        get { return _loginValue; }
        set { SetProperty(ref _loginValue, value);}
    }

    private SecureString _passwordValue; // не работает, невозможно сделать бинд не нарушая mvvm
    public SecureString PasswordValue // не работает, невозможно сделать бинд не нарушая mvvm
    {
        get { return _passwordValue; }
        set { SetProperty(ref _passwordValue, value);}
    }

    private void TryLogin()
    {
        if (autorizationService.LoginAndPassword(LoginValue, "1234") == true)
        {
            regionManager.RequestNavigate("Main", "MainForm");
        }
        else
        {
            MessageBox.Show("Не правильный логин или пароль!", "Ошибка!");
        }
    }

    /* public string PasswordValue
    {
        get { return Marshal.PtrToStringBSTR(Marshal.SecureStringToBSTR(PasswordBox.SecurePassword)); }
    }*/
}
