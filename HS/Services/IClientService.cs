using System.Threading.Tasks;
using HS.Context.Entities;

namespace HS.Services
{
    public interface IClientService
    {
        public Client SignUp(string surname,
            string name, 
            string patronymic, 
            string passport,
            string phoneNumber,
            string login,
            string password,
            ClientStatus status);
        public Client SignIn(string rawLogin, string rowPassword);
    }
}