using System.Windows;
using System.Windows.Input;
using Hotel.Context.Entities;
using Hotel.Views.Windows;
using HS.Infrastructure.Commands.Base;
using HS.ViewModels.Base;

namespace HS.ViewModels
{
    public class SignInViewModel : ViewModel
    {
        //            _locator.SignInViewModel.CurrentUser = currentClient;

        #region Commands

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

        public SignInViewModel()
        {
            #region CommandsInit

            OpenNewSignUpWindowCommand =
                new RelayCommand(OnOpenNewSignUpWindowCommandExecuted, CanOpenNewSignUpWindowCommandExecute);
            
            #endregion
        }
    }
}