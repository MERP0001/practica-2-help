using RepairMan.DataClasses.Common;
using RepairMan.Services.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Cryptography;
using System.Security.Principal;
using System.Text;

namespace RepairMan.Business.Common
{
    public class UserControlLogic : IUserControlLogic
    {
        private readonly IUserService _userService;

        public UserControlLogic(IUserService userService)
        {
            _userService = userService;
        }


        private void Validate(User user)
        {
            if (user.Contact == null)
                throw new UserControlLogicException("La informacion de contacto debe de incluirse.");
            if (string.IsNullOrWhiteSpace(user.Name) || string.IsNullOrWhiteSpace(user.Contact.FirstName))
                throw new UserControlLogicException("El nombre no puede estar vacio.");
            if (string.IsNullOrWhiteSpace(user.Contact.LastName))
                throw new UserControlLogicException("El apellido no puede estar vacio.");
            if (user.Contact.Email != null && !new EmailAddressAttribute().IsValid(user.Contact.Email))
                throw new UserControlLogicException("El email ingresado no es valido.");
        }

        public User Create(User user)
        {

            Validate(user);
            if (string.IsNullOrWhiteSpace(user.Password))
                throw new UserControlLogicException("La clave no puede estar vacia.");
            if (_userService.All(x => x.Name == user.Name).Any())
                throw new UserControlLogicException("El correo ingresado ya fue registrado...");
            user.Active = true;
            user.Password = EncryptPassword(user.Password);
            user.CreationDate = DateTime.UtcNow;
            user.Roles = new List<string>() { UserRole.Customer };
            _userService.Create(user);
            return user;
        }

        public User GetUserByCredentials(UserCredentials credentials)
        {
            if (credentials == null)
                return null;

            return _userService.All(x => x.Name.ToLower() == credentials.Name.ToLower() && x.Password == EncryptPassword(credentials.Password)).FirstOrDefault();
        }

        public User GetUserByIdentity(IIdentity identity)
        {
            return _userService.Get(Guid.Parse(identity.Name));
        }

        public User UpdateUser(User user)
        {
            Validate(user);
            var existingUser = _userService.Get(user.UserId);

            existingUser.Name = user.Name;
            if(!string.IsNullOrEmpty(user.Password) && user.Password != existingUser.Password) {
                existingUser.Password = EncryptPassword(user.Password);
            }


            existingUser.Contact.Email = user.Contact.Email;
            existingUser.Contact.FirstName = user.Contact.FirstName;
            existingUser.Contact.LastName = user.Contact.LastName;
            existingUser.Contact.PhoneNumber = user.Contact.PhoneNumber;
            existingUser.Contact.Address = user.Contact.Address;

            _userService.Update(existingUser);
            return user;
        }

        public static string EncryptPassword(string plainPassword)
        {
            var hash = string.Empty;
            var hashedBytes = SHA512.HashData(Encoding.UTF8.GetBytes(plainPassword));
            foreach (var x in hashedBytes)
            {
                hash += x.ToString("x2");
            }
            return hash;
        }
    }

    public class UserCredentials {
        public string Name { get; set; } = null!;
        public string Password { get; set; } = null!;
    }
}
