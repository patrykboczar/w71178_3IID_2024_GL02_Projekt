using Kino.Models;

namespace Kino.Services
{
    public class UserService
    {
        private List<User> users = new List<User>();
        private const string filePath = "users.txt";

        public UserService()
        {
            LoadUsers(); 
        }

        private void LoadUsers()
        {
            if (File.Exists(filePath))
            {
                var lines = File.ReadAllLines(filePath);
                foreach (var line in lines)
                {
                    var parts = line.Split(',');
                    users.Add(new User { Email = parts[0], Password = parts[1] });
                }
            }
        }

        private void SaveUsers()
        {
            var lines = users.Select(u => $"{u.Email},{u.Password}");
            File.WriteAllLines(filePath, lines);
        }

        public bool Login(string email, string password)
        {
            return users.Any(u => u.Email == email && u.Password == password);
        }

        public void Register(string email, string password)
        {
            users.Add(new User { Email = email, Password = password });
            SaveUsers();
        }
    }
}