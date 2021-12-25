using Hotel.Interfaces;
using HS.Context.Entities;
using HS.ViewModels.Base;

namespace HS.ViewModels
{
    public class ServicesViewModel : ViewModel
    {
        private readonly ViewModelLocator _locator;
        private readonly IRepository<Service> _servicesRepository;

        public ServicesViewModel(ViewModelLocator locator,
            IRepository<Service> servicesRepository)
        {
            _locator = locator;
            _servicesRepository = servicesRepository;
        }
    }
}