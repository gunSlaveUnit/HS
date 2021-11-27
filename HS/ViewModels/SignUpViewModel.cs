using System.Windows.Input;
using HS.Infrastructure.Commands.Base;
using HS.Services;
using HS.ViewModels.Base;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace HS.ViewModels
{
    public class SignUpViewModel : ViewModel
    {
        private readonly IClientService _clientService;

        private string _surname;

        public string Surname
        {
            get => _surname;
            set => Set(ref _surname, value);
        }
        
        private string _name;

        public string Name
        {
            get => _name;
            set => Set(ref _name, value);
        }
        
        private string _patronymic;

        public string Patronymic
        {
            get => _patronymic;
            set => Set(ref _patronymic, value);
        }
        
        private string _passport;

        public string Passport
        {
            get => _passport;
            set => Set(ref _passport, value);
        }
        
        private string _phoneNumber;

        public string PhoneNumber
        {
            get => _phoneNumber;
            set => Set(ref _phoneNumber, value);
        }
        
        private string _login;

        public string Login
        {
            get => _login;
            set => Set(ref _login, value);
        }
        
        private string _password;

        public string Password
        {
            get => _password;
            set => Set(ref _password, value);
        }
        
        private string _passwordConfirm;
        private readonly ViewModelLocator _locator;

        public string PasswordConfirm
        {
            get => _passwordConfirm;
            set => Set(ref _passwordConfirm, value);
        }
        
        #region NewUser

        public ICommand SignUpCommand { get; }

        private void OnSignUpCommandExecuted(object p)
        {
             var currentClient = _clientService.SignUp(
                Surname, Name, Patronymic, Passport, PhoneNumber, Login, Password
            );
        }

        private bool CanSignUpCommandExecute(object p) => true;

        #endregion
        
        public SignUpViewModel(IClientService clientService, ViewModelLocator locator)
        {
            _locator = locator;
            _clientService = clientService;
            SignUpCommand = new RelayCommand(OnSignUpCommandExecuted, CanSignUpCommandExecute);
        }
    }
}