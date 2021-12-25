using System;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using Hotel.Interfaces;
using HS.Context.Entities;

namespace HS.Services
{
    public class ClientService : IClientService
    {
        private static string _alphabet = "0123456789" +
                                         "abcdefghijklmnopqrstuvwxyz" +
                                         "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        private readonly IRepository<Client> _clients;

        public ClientService(IRepository<Client> clients)
        {
            _clients = clients;
        }
        public Client SignUp(string surname, string name, string patronymic, 
            string passport, string phoneNumber, string login,
            string rawPassword)
        {
            string salt = GenerateRandomString(10);
            //string saltedLogin = login + salt;
            string saltedPassword = rawPassword + salt;
            //string hashedSaltedLogin = GetHashString(saltedLogin);
            string hashedSaltedPassword = GetHashString(saltedPassword);
            var newClient = new Client()
            {
                Surname = surname,
                Name = name,
                Patronymic = patronymic,
                Document = passport,
                PhoneNumber = phoneNumber,
                Login = login,
                Password = hashedSaltedPassword,
                Salt = salt
            };
            return _clients.Add(newClient);
        }

        public Client SignIn(string rawLogin, string rawPassword)
        {
            var clients = _clients.All;
            var client = clients.FirstOrDefault(c => c.Login == rawLogin);
            if (client == null) return null!;
            string inputPasswordWithSalt = rawPassword + client.Salt;
            string hashedInputPassword = GetHashString(inputPasswordWithSalt);
            if (hashedInputPassword == client.Password) return client;
            return null!;
        }
        
        private static byte[] GetHash(string inputString)
        {
            using (HashAlgorithm algorithm = SHA256.Create())
                return algorithm.ComputeHash(Encoding.UTF8.GetBytes(inputString));
        }

        private static string GetHashString(string inputString)
        {
            StringBuilder sb = new StringBuilder();
            foreach (byte b in GetHash(inputString))
                sb.Append(b.ToString("X2"));

            return sb.ToString();
        }

        private static string GenerateRandomString(int length)
        {
            Random random = new Random();
            StringBuilder sb = new StringBuilder(length - 1);
            for (int i = 0; i < length; ++i)
            {
                sb.Append(_alphabet[random.Next(0, _alphabet.Length - 1)]);
            }

            return sb.ToString();
        }
    }
}