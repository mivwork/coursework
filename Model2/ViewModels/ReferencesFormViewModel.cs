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

internal class ReferencesFormViewModel : BindableBase
    {
        private readonly IRegionManager regionManager;
        private readonly ClockService clockService;

        public ReferencesFormViewModel(IRegionManager regionManager, ClockService clockService)
        {
            this.regionManager = regionManager;
            this.clockService = clockService;
            ItemBrend = clockService.getDataBrend();
            ItemModel = clockService.getDataModel();
            ItemCountry = clockService.getDataCountry();
            AddValueCommand = new DelegateCommand(setTable);
        }

        public ICommand AddValueCommand { get; set; }
        private Clock clock;

        private List<Brend_clock> _itemBrend;
        public List<Brend_clock> ItemBrend
        {
            get { return _itemBrend; }
            set { SetProperty(ref _itemBrend, value); }
        }

        private Brend_clock _brend_value;
        public Brend_clock Brend_value
        {
            get { return _brend_value; }
            set { SetProperty(ref _brend_value, value); }
        }

        private List<Model_clock> _itemModel;
        public List<Model_clock> ItemModel
        {
            get { return _itemModel; }
            set { SetProperty(ref _itemModel, value); }
        }

        private Model_clock _model_value;
        public Model_clock Model_value
        {
            get { return _model_value; }
            set { SetProperty(ref _model_value, value); }
        }

        private List<Country_clock> _itemCountry;
        public List<Country_clock> ItemCountry
        {
            get { return _itemCountry; }
            set { SetProperty(ref _itemCountry, value); }
        }

        private Model_clock _country_value;
        public Model_clock Country_value
        {
            get { return _country_value; }
            set { SetProperty(ref _country_value, value); }
        }

        private List<string> _table_value = new List<string> {
                "Бренды",
                "Модели",
                "Города" 
        };

        public List<string> Table_value 
        { get { 
            return _table_value; }
          set {}
        }

        private string _v_value;
        public string V_value
        {
            get { return _v_value; }
            set { SetProperty(ref _v_value, value); }
        }

        private string _zn_value;
        public string Zn_value
        {
            get { return _zn_value; }
            set { SetProperty(ref _zn_value, value); }
        }

        public void setTable()
        {
            clockService.Add(Zn_value, V_value);
            ItemBrend = clockService.getDataBrend();
            ItemModel = clockService.getDataModel();
            ItemCountry = clockService.getDataCountry();
        }
}