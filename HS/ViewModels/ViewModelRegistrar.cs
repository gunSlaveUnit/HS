using Microsoft.Extensions.DependencyInjection;

namespace HS.ViewModels
{
    static class ViewModelRegistrator
    {
        public static IServiceCollection AddViewModels(this IServiceCollection services) => services
            .AddSingleton<MainViewModel>()
            .AddSingleton<SignInViewModel>()
            .AddSingleton<SignUpViewModel>()
            .AddSingleton<ViewModelLocator>()
        ;
    }
}