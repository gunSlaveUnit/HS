using System.Windows;
using Hotel.Infrastructure.Commands.Base;

namespace Hotel.Infrastructure.Commands
{
    public class CloseAppCommand : Command
    {
        public override bool CanExecute(object parameter) => true;

        public override void Execute(object parameter) => Application.Current.Shutdown();
    }
}