using model.DataAccess;
using model.Models;
using Model2.Views;
using Prism.Commands;
using Prism.Events;
using Prism.Mvvm;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using static Npgsql.PostgresTypes.PostgresCompositeType;

namespace Model2.ViewModels;

internal class UserViewModel : BindableBase
{
    private readonly IRegionManager regionManager;
    private readonly UserService userService;

    public UserViewModel(IRegionManager regionManager, UserService userService)
    {
        this.regionManager = regionManager;
        this.userService = userService;
        UserValue = userService.getuser();
        UserloginValue = UserValue.login;
        LastnameValue = UserValue.lastname;
        NameValue = UserValue.name;
        FirstnameValue = UserValue.firstname;
    }

    private Users _userValue;
    public Users UserValue
    {
        get { return _userValue; }
        set { SetProperty(ref _userValue, value); }
    }

    private string _userloginValue;
    public string UserloginValue
    {
        get { return _userloginValue; }
        set { SetProperty(ref _userloginValue, value); }
    }

    private string _lastnameValue;
    public string LastnameValue
    {
        get { return _lastnameValue; }
        set { SetProperty(ref _lastnameValue, value); }
    }

    private string _nameValue;
    public string NameValue
    {
        get { return _nameValue; }
        set { SetProperty(ref _nameValue, value); }
    }

    private string _firstnameValue;
    public string FirstnameValue
    {
        get { return _firstnameValue; }
        set { SetProperty(ref _firstnameValue, value); }
    }

}