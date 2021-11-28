using System.Windows;
using System.Windows.Input;
using Hotel;
using Hotel.Context.Entities;
using Hotel.Views.Windows;
using HS.Infrastructure.Commands.Base;
using HS.Services;
using HS.ViewModels.Base;

namespace HS.ViewModels
{
    public class SignInViewModel : ViewModel
    {
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
        
        private readonly ViewModelLocator _locator;

        private readonly IClientService _clientService;

        #region Commands

        #region SignIn

        public ICommand SignInCommand { get; }

        private void OnSignInCommandExecuted(object p)
        {
            //TODO: It works, but it is not good in MVVM architecture
            var item = _clientService.SignIn(Login, Password);
            _locator.MainViewModel.CurrentUser = item;
            MainWindow mw = new MainWindow();
            Application.Current.MainWindow.Close();
            Application.Current.MainWindow = mw;
            mw.DataContext = _locator.MainViewModel;
            mw.Show();
        }

        private bool CanSignInCommandExecute(object p) => true;

        #endregion

        #region NewUser

        public ICommand OpenNewSignUpWindowCommand { get; }

        private void OnOpenNewSignUpWindowCommandExecuted(object p)
        {
            var newUserWindow = new SignUpWindow();
            newUserWindow.Owner = Application.Current.MainWindow;
            newUserWindow.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            newUserWindow.ShowDialog();
        }

        private bool CanOpenNewSignUpWindowCommandExecute(object p) => true;

        #endregion

        #endregion

        public SignInViewModel(IClientService clientService, ViewModelLocator locator)
        {
            _clientService = clientService;
            _locator = locator;
            #region CommandsInit

            OpenNewSignUpWindowCommand =
                new RelayCommand(OnOpenNewSignUpWindowCommandExecuted, CanOpenNewSignUpWindowCommandExecute);
            SignInCommand =
                new RelayCommand(OnSignInCommandExecuted, CanSignInCommandExecute);
            
            #endregion
        }
    }
}