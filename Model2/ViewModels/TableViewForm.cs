using model.DataAccess;
using model.Models;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Model2.ViewModels;

internal class TableViewModel : BindableBase
{
    private readonly IRegionManager regionManager;
    private readonly ClockService clockService;
    public ICommand TableCommand { get; init; }
    
    private List<Clock> _itemValue;
    public List<Clock> ItemValue
    {
        get { return _itemValue; }
        set { SetProperty(ref _itemValue, value); }
    }

    private List<Shop> _itemShopValue;
    public List<Shop> ItemShopValue
    {
        get { return _itemShopValue; }
        set { SetProperty(ref _itemShopValue, value); }
    }

    private Shop _shop;
    public Shop Shop
    {
        get { return _shop; }
        set { SetProperty(ref _shop, value); }
    }

    private string _countStr = "Количество строк: ";
    public string CountStr
    {
        get { return _countStr; }
        set { SetProperty(ref _countStr, value); }
    }

    public TableViewModel(IRegionManager regionManager, ClockService clockService)
    {
        this.regionManager = regionManager;
        this.clockService = clockService;
        ItemValue = clockService.getDataClock();
        ItemShopValue = clockService.getDataShop();
        CountStr += ItemValue.Count().ToString();
        TableCommand = new DelegateCommand(getTable);
    }

    private void getTable()
    {
        ItemValue = clockService.getDataClockShop(Shop);
        CountStr = "Количество строк: " + ItemValue.Count().ToString();
    }
}