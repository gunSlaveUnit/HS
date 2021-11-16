using Microsoft.Extensions.DependencyInjection;

namespace HS.ViewModels
{
    public class ViewModelLocator
    {
        public MainViewModel MainViewModel => App.Services.GetRequiredService<MainViewModel>();
        public SignInViewModel SignInViewModel => App.Services.GetRequiredService<SignInViewModel>();
        public SignUpViewModel SignUpViewModel => App.Services.GetRequiredService<SignUpViewModel>();
    }
}