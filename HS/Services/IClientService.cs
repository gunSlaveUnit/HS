using System.Threading.Tasks;
using Hotel.Context.Entities;

namespace HS.Services
{
    public interface IClientService
    {
        public Task<Client> SignUp(string surname,
            string name, 
            string patronymic, 
            string passport,
            string phoneNumber,
            string login,
            string password);
        public Task<Client> SignIn(string rawLogin, string rowPassword);
    }
}