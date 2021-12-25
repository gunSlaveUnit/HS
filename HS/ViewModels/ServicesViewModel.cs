using System;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;
using Hotel.Interfaces;
using HS.Context.Entities;
using HS.Infrastructure.Commands.Base;
using HS.ViewModels.Base;
using HS.Views.Windows.Creation;

namespace HS.ViewModels
{
    public class ServicesViewModel : ViewModel
    {
        private readonly ViewModelLocator _locator;
        private readonly IRepository<Service> _servicesRepository;

        #region Properties

        #region Services

        private ObservableCollection<Service> _services;
        public ObservableCollection<Service> Services
        {
            get => _services;
            set => Set(ref _services, value);
        }

        #endregion

        #region SelectedService

        private Service _selectedService;

        public Service SelectedService
        {
            get => _selectedService;
            set => Set(ref _selectedService, value);
        }

        #endregion

        #endregion

        #region Commands

        #region OrderServiceCommand

        private ICommand _orderService;
        public ICommand OrderServiceCommand => _orderService
            ??= new RelayCommand(OnOrderServiceCommandExecuted, CanOrderServiceCommandExecute);
        
        private bool CanOrderServiceCommandExecute(object p) => p is Service;

        private void OnOrderServiceCommandExecuted(object p)
        {
            if (p is not Service) return;
            //TODO: It works, but it is not good in MVVM architecture
            var confirmOrderService = new ServiceOrderConfirmWindow();
            _locator.ServiceConfirmViewModel.SelectedService = SelectedService;
            _locator.ServiceConfirmViewModel.CurrentClient = _locator.MainViewModel.CurrentUser;
            confirmOrderService.Owner = Application.Current.MainWindow;
            confirmOrderService.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            confirmOrderService.ShowDialog();
        }

        #endregion

        #endregion

        public ServicesViewModel(ViewModelLocator locator,
            IRepository<Service> servicesRepository)
        {
            _locator = locator;
            _servicesRepository = servicesRepository;
            var services = _servicesRepository.All;
            Services = new ObservableCollection<Service>(services);
        }
    }
}