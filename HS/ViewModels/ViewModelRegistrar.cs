using HS.ViewModels;
using Microsoft.Extensions.DependencyInjection;

namespace Hotel.ViewModels
{
    static class ViewModelRegistrator
    {
        public static IServiceCollection AddViewModels(this IServiceCollection services) => services
            .AddSingleton<MainViewModel>()
            .AddSingleton<SignInViewModel>()
            .AddSingleton<SignUpViewModel>()
        ;
    }
}