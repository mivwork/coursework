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

    private List<Clock> _itemValue;
    public List<Clock> ItemValue
    {
        get { return _itemValue; }
        set { SetProperty(ref _itemValue, value); }
    }

    public TableViewModel(IRegionManager regionManager, ClockService clockService)
    {
        this.regionManager = regionManager;
        this.clockService = clockService;
        ItemValue = clockService.getDataClock();
    }
}