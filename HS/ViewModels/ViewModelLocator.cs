using Microsoft.Extensions.DependencyInjection;

namespace HS.ViewModels
{
    public class ViewModelLocator
    {
        public MainViewModel MainViewModel => App.Services.GetRequiredService<MainViewModel>();
        public SignInViewModel SignInViewModel => App.Services.GetRequiredService<SignInViewModel>();
        public SignUpViewModel SignUpViewModel => App.Services.GetRequiredService<SignUpViewModel>();
        public NewReservByClientViewModel NewReservByClientViewModel => App.Services.GetRequiredService<NewReservByClientViewModel>();
        public NewRoomTypeViewModel NewRoomTypeViewModel => App.Services.GetRequiredService<NewRoomTypeViewModel>();
        public ServiceConfirmViewModel ServiceConfirmViewModel => App.Services.GetRequiredService<ServiceConfirmViewModel>();
        public NewRoomWindowViewModel NewRoomWindowViewModel => App.Services.GetRequiredService<NewRoomWindowViewModel>();
    }
}