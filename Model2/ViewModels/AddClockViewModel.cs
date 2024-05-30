using DryIoc;
using model.DataAccess;
using model.Models;
using Model2.Views;
using OfficeOpenXml.Table.PivotTable;
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

internal class AddClockViewModel : BindableBase
{
    private readonly IRegionManager regionManager;
    private readonly ClockService clockService;
    public ICommand ReturnTableCommand { get; set; }
    public ICommand AddandReturnTableCommand { get; set; }
    private Clock clock;

    private List<Shop> _itemShopsValue;
    public List<Shop> ItemShopsValue
    {
        get { return _itemShopsValue; }
        set { SetProperty(ref _itemShopsValue, value); }
    }

    private List<Brend_clock> _itemBrendValue;
    public List<Brend_clock> ItemBrendValue
    {
        get { return _itemBrendValue; }
        set { SetProperty(ref _itemBrendValue, value); }
    }

    private List<Model_clock> _itemModelValue;
    public List<Model_clock> ItemModelValue
    {
        get { return _itemModelValue; }
        set { SetProperty(ref _itemModelValue, value); }
    }

    private List<Country_clock> _itemCountryValue;
    public List<Country_clock> ItemCountryValue
    {
        get { return _itemCountryValue; }
        set { SetProperty(ref _itemCountryValue, value); }
    }

    private List<Status_clock> _itemStatusValue;
    public List<Status_clock> ItemStatusValue
    {
        get { return _itemStatusValue; }
        set { SetProperty(ref _itemStatusValue, value); }
    }

    private Shop _shops;
    public Shop Shops
    {
        get { return _shops; }
        set { SetProperty(ref _shops, value); }
    }

    private Model_clock _model_clock;
    public Model_clock Model_clock
    {
        get { return _model_clock; }
        set { SetProperty(ref _model_clock, value); }
    }

    private Brend_clock _brend_clock;
    public Brend_clock Brend_clock
    {
        get { return _brend_clock; }
        set { SetProperty(ref _brend_clock, value); }
    }

    private Country_clock _country_clock;
    public Country_clock Country_clock
    {
        get { return _country_clock; }
        set { SetProperty(ref _country_clock, value); }
    }

    private Status_clock _status_clock;
    public Status_clock Status_clock
    {
        get { return _status_clock; }
        set { SetProperty(ref _status_clock, value); }
    }

    private int _cost_clock;
    public int Cost_clock
    {
        get { return _cost_clock; }
        set { SetProperty(ref _cost_clock, value); }
    }

    public AddClockViewModel(IRegionManager regionManager, ClockService clockService)
    {
        this.regionManager = regionManager;
        this.clockService = clockService;
        ItemBrendValue = clockService.getDataBrend();
        ItemModelValue = clockService.getDataModel();
        ItemCountryValue = clockService.getDataCountry();
        ItemStatusValue = clockService.getDataStatus();
        ItemShopsValue = clockService.getDataShop();
        ReturnTableCommand = new DelegateCommand(ReturnTable);
        AddandReturnTableCommand = new DelegateCommand(AddandReturnTable);
    }

    private void AddandReturnTable()
    {
        try
        {
            clock = new Clock();
            if (Brend_clock == null || Model_clock == null || Country_clock == null || Status_clock == null || Shops == null)
            {
                throw new InvalidOperationException("Не заполнены все поля");
            } else
            {
                clock.brend = Brend_clock.name;
                clock.model = Model_clock.name;
                clock.country = Country_clock.name;
                clock.cost = Cost_clock;
                clock.status = Status_clock.name;
                clock.shop = Shops.name;
                clockService.AddClock(clock);
            }
            var region = regionManager.Regions["MainForm"];
            region.NavigationService.Journal.Clear();
            regionManager.RequestNavigate("MainForm", "Table");
        } catch (Exception ex)
        {
            MessageBox.Show("Ошибка: " + ex.Message, "Ошибка!");
        }
    }

    private void ReturnTable()
    {
        var region = regionManager.Regions["MainForm"];
        region.NavigationService.Journal.Clear();
        regionManager.RequestNavigate("MainForm", "Table");
    }
}