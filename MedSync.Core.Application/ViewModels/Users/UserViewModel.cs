
using MedSync.Core.Domain.Entities;
using MedSync.Core.Domain.Enums;

namespace MedSync.Core.Application.ViewModels.Users
{
    public class UserViewModel
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public UserType UserType { get; set; }

    }
}
