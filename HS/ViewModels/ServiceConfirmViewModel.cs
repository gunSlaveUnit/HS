using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using Hotel.Interfaces;
using HS.Context.Entities;
using HS.Infrastructure.Commands.Base;
using HS.ViewModels.Base;

namespace HS.ViewModels
{
    public class ServiceConfirmViewModel : ViewModel
    {
        #region Properties

        #region SelectedService

        private Service _selectedService;

        public Service SelectedService
        {
            get => _selectedService;
            set => Set(ref _selectedService, value);
        }

        #endregion

        #region CurrentClient

        private Client _currentClient;

        public Client CurrentClient
        {
            get => _currentClient;
            set => Set(ref _currentClient, value);
        }

        #endregion

        #endregion

        #region ConfirmOrderServiceCommand

        private ICommand _confirmOrderServiceCommand;
        private readonly IRepository<Reservation> _reservationsRepository;
        private readonly IRepository<OrderedService> _orderedServicesRepository;

        public ICommand ConfirmOrderServiceCommand => _confirmOrderServiceCommand
            ??= new RelayCommand(OnConfirmOrderServiceCommandExecuted, CanConfirmOrderServiceCommandExecute);

        private bool CanConfirmOrderServiceCommandExecute(object p)
            => CurrentClient.Reservations.FirstOrDefault() != default;

        private void OnConfirmOrderServiceCommandExecuted(object p)
        {
            _orderedServicesRepository.AddAsync(new OrderedService
            {
                Service = SelectedService,
                Reservation = _reservationsRepository.All.First(r => r.ClientId == CurrentClient.Id),
                CheckoutPrice = SelectedService.Price
            });
        }

        #endregion
        
        public ServiceConfirmViewModel(IRepository<Reservation> reservationsRepository,
            IRepository<OrderedService> orderedServicesRepository)
        {
            _reservationsRepository = reservationsRepository;
            _orderedServicesRepository = orderedServicesRepository;
        }
    }
}