﻿using System.Collections.ObjectModel;
using System.Windows.Input;
using System.Windows.Media;
using Hotel.Interfaces;
using HS.Context.Entities;
using HS.Infrastructure.Commands.Base;
using HS.Services;
using HS.ViewModels.Base;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace HS.ViewModels
{
    public class SignUpViewModel : ViewModel
    {
        private SolidColorBrush _messageColor;

        public SolidColorBrush MessageColor
        {
            get => _messageColor;
            set => Set(ref _messageColor, value);
        }
        
        private string _signUpStatus;

        public string SignUpStatus
        {
            get => _signUpStatus;
            set => Set(ref _signUpStatus, value);
        }
        
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
        private Client _currentClient;
        private readonly IRepository<ClientStatus> _clientStatusesRepository;

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
                Surname, Name, Patronymic, Passport, PhoneNumber, Login, Password, Statuses[2]);
            _currentClient = currentClient;
            if (_currentClient is null)
            {
                SignUpStatus = "Что-то пошло не так, попробуйте еще раз";
                MessageColor = new SolidColorBrush(Colors.Red);
            }
            else
            {
                SignUpStatus = "Аккаунт успешно создан, вы можете закрыть это окно";
                MessageColor = new SolidColorBrush(Colors.Green);
            }
        }

        private bool CanSignUpCommandExecute(object p) 
            => Password != "" 
               && PasswordConfirm != ""
               && Login != ""
               && Passport != ""
               && PhoneNumber != ""
               && Surname != ""
               && Name != ""
               && Patronymic != ""
               && Password == PasswordConfirm
        ;

        #endregion
        
        #region Statuses

        private ObservableCollection<ClientStatus> _statuses;

        public ObservableCollection<ClientStatus> Statuses
        {
            get => _statuses;
            set => Set(ref _statuses, value);
        }

        #endregion
        
        public SignUpViewModel(IClientService clientService, IRepository<ClientStatus> clientStatusesRepository)
        {
            _clientStatusesRepository = clientStatusesRepository;
            _clientService = clientService;
            Statuses = new ObservableCollection<ClientStatus>(clientStatusesRepository.All);
            SignUpCommand = new RelayCommand(OnSignUpCommandExecuted, CanSignUpCommandExecute);
        }
    }
}