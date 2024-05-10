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

namespace Model2.ViewModels;

internal class MainFormViewModel : BindableBase
{
    private readonly IRegionManager regionManager;
    public ICommand ShowTableCommand { get; set; }
    public ICommand ShowUserCommand { get; set; }

    public MainFormViewModel(IRegionManager regionManager)
    {
        this.regionManager = regionManager;
        ShowTableCommand = new DelegateCommand(ShowTable);
        ShowUserCommand = new DelegateCommand(ShowUser);
    }

    private void ShowTable()
    {
        var region = regionManager.Regions["MainForm"];
        region.NavigationService.Journal.Clear();
        regionManager.RequestNavigate("MainForm", "Table");
    }

    private void ShowUser()
    {
        var region = regionManager.Regions["MainForm"];
        region.NavigationService.Journal.Clear();
        regionManager.RequestNavigate("MainForm", "User");
    }
}
