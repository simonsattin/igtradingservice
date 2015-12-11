using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using IGTrading.Data;
using IGTrading.Data.SqlServer;
using IGTrading.Model;
using System;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace IGTradingUI.ViewModel
{
    /// <summary>
    /// This class contains properties that the main View can data bind to.
    /// <para>
    /// Use the <strong>mvvminpc</strong> snippet to add bindable properties to this ViewModel.
    /// </para>
    /// <para>
    /// You can also use Blend to data bind with the tool's support.
    /// </para>
    /// <para>
    /// See http://www.galasoft.ch/mvvm
    /// </para>
    /// </summary>
    public class MainViewModel : ViewModelBase
    {
        private ObservableCollection<CustomOrder> _CustomOrders;
        private CustomOrder _NewCustomOrder;

        private ICustomOrderRepository _CustomOrderRepository;

        public RelayCommand RefreshCustomOrdersCommand { get; private set; }
        public RelayCommand AddCustomOrderCommand { get; private set; }

        /// <summary>
        /// Initializes a new instance of the MainViewModel class.
        /// </summary>
        public MainViewModel()
        {
            CustomOrders = new ObservableCollection<CustomOrder>();
            CreateCustomOrder();

            _CustomOrderRepository = new SqlServerCustomOrderRepository();

            RefreshCustomOrdersCommand = new RelayCommand(RefreshCustomOrders);
            AddCustomOrderCommand = new RelayCommand(AddCustomOrder);

            RefreshCustomOrders();
        }


        public ObservableCollection<CustomOrder> CustomOrders
        {
            get { return _CustomOrders; }
            set
            {
                _CustomOrders = value;
                RaisePropertyChanged("CustomOrders");
            }
        }

        private CustomOrder _SelectedCustomOrder;
        public CustomOrder SelectedCustomOrder
        {
            get { return _SelectedCustomOrder; }
            set
            {
                _SelectedCustomOrder = value;
                RaisePropertyChanged("SelectedCustomOrder");
            }
        }

        public CustomOrder NewCustomOrder
        {
            get { return _NewCustomOrder; }
            set { _NewCustomOrder = value; RaisePropertyChanged("NewCustomOrder"); }
        }

        public ICommand DeleteCommand { get; set; }

        private void DeleteSelected()
        {
            if (null != SelectedCustomOrder)
            {
                CustomOrders.Remove(SelectedCustomOrder);
            }
        }
        
        private void RefreshCustomOrders()
        {
            DeleteCommand = new RelayCommand(DeleteSelected);

            CustomOrders = new ObservableCollection<CustomOrder>(_CustomOrderRepository.GetAll());
        }

        private void AddCustomOrder()
        {
            try
            {
                _CustomOrderRepository.Insert(NewCustomOrder);
                CustomOrders.Add(NewCustomOrder);
                CreateCustomOrder();
            }
            catch (Exception exception)
            {

            }            
        }

        private void CreateCustomOrder()
        {
            NewCustomOrder = new CustomOrder();
            NewCustomOrder.NextEarnings = DateTime.Today;
            NewCustomOrder.Expiry = DateTime.Today;
        }
    }
}