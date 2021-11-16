using System.Windows;
using HS.Infrastructure.Commands.Base;

namespace HS.Infrastructure.Commands
{
    public class CloseAppCommand : Command
    {
        public override bool CanExecute(object parameter) => true;

        public override void Execute(object parameter) => Application.Current.Shutdown();
    }
}