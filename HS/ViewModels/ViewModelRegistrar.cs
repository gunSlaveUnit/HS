using Microsoft.Extensions.DependencyInjection;

namespace HS.ViewModels
{
    static class ViewModelRegistrator
    {
        public static IServiceCollection AddViewModels(this IServiceCollection services) => services
            .AddSingleton<MainViewModel>()
            .AddSingleton<SignInViewModel>()
            .AddSingleton<SignUpViewModel>()
            .AddSingleton<NewReservByClientViewModel>()
            .AddSingleton<NewRoomTypeViewModel>()
            .AddSingleton<ServiceConfirmViewModel>()
            .AddSingleton<NewRoomWindowViewModel>()
            .AddSingleton<PaymentViewModel>()
            .AddSingleton<ViewModelLocator>()
        ;
    }
}