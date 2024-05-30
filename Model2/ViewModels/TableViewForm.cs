using model.DataAccess;
using model.Models;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.IO.Packaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using OfficeOpenXml;
using System.Timers;

namespace Model2.ViewModels;

internal class TableViewModel : BindableBase
{
    private readonly IRegionManager regionManager;
    private readonly ClockService clockService;
    public ICommand TableCommand { get; init; }
    public ICommand ExcelCommand { get; init; }
    ExcelPackage package;
    private Timer _timer;

    string projectPath = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName;

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
        ExcelCommand = new DelegateCommand(excel);
        ShowAddClockCommand = new DelegateCommand(ShowAdd);

        _timer = new Timer(5000);
        _timer.Elapsed += OnTimerElapsed;
        _timer.Start();

        getTable();

    }

    private void OnTimerElapsed(object sender, ElapsedEventArgs e)
    {
        getTable();
    }

    private void getTable()
    {
        ItemValue = clockService.getDataClockShop(Shop);
        CountStr = "Количество строк: " + ItemValue.Count().ToString();
    }

    private void excel()
    {
        // Добавляем новый лист
        ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
        package = new ExcelPackage();
        ExcelWorksheet worksheet = package.Workbook.Worksheets.Add("Sheet1");

        // Заголовки столбцов
        worksheet.Cells[1, 1].Value = "id";
        worksheet.Cells[1, 2].Value = "Бренд";
        worksheet.Cells[1, 3].Value = "Модель";
        worksheet.Cells[1, 4].Value = "Город";
        worksheet.Cells[1, 5].Value = "Цена";
        worksheet.Cells[1, 6].Value = "Статус";
        worksheet.Cells[1, 7].Value = "Магазин";

        // Выводим данные в ячейки
        for (int i = 0; i < ItemValue.Count; i++)
        {
            worksheet.Cells[i + 2, 1].Value = ItemValue[i].id;
            worksheet.Cells[i + 2, 2].Value = ItemValue[i].brend;
            worksheet.Cells[i + 2, 3].Value = ItemValue[i].model;
            worksheet.Cells[i + 2, 4].Value = ItemValue[i].country;
            worksheet.Cells[i + 2, 5].Value = ItemValue[i].cost;
            worksheet.Cells[i + 2, 6].Value = ItemValue[i].status;
            worksheet.Cells[i + 2, 7].Value = ItemValue[i].shop;
        }

        // Сохраняем файл Excel в папке с проектом
        FileInfo file = new FileInfo(Path.Combine(projectPath, "Учет_часов.xlsx"));
        package.SaveAs(file);
    }

    public ICommand ShowAddClockCommand { get; set; }

    private void ShowAdd()
    {
        var region = regionManager.Regions["MainForm"];
        region.NavigationService.Journal.Clear();
        regionManager.RequestNavigate("MainForm", "AddClock");
    }
}