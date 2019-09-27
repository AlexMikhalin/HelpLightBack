using HelpLight.Data.Contexts;
using HelpLight.Repository.Contracts;
using System;
using System.Collections.Generic;
using User = HelpLight.Data.Models.User;
using AutoMapper;
using System.Linq;

namespace HelpLight.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly HelpLightDbContext _HLDbContext;

        public UserRepository(HelpLightDbContext _HLDbContext)
        {
            this._HLDbContext = _HLDbContext;
        }

        public void AddUser(Contracts.User user)
        {
            if (user == null)
            {
                throw new Exception("User is null");
            }

            try
            {
                var userEntity = Mapper.Map<Contracts.User, User>(user);
                _HLDbContext.Add(userEntity);
                SaveChanges();

                //if (!user.IsOrganization)
                //{
                //    AddNewUserKarma(user.Volunteer.IdVolunteer);
                //}
            }
            catch
            {
                throw;
            }
        }

        public List<User> GetAllUsers()
        {
            List<User> users = new List<User>();

            try
            {
                users = _HLDbContext.Users.ToList();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return users;
        }

        public bool IsOrganization(Guid id)
        {
            throw new NotImplementedException();
        }

        public void RegisterUser()
        {
            throw new NotImplementedException();
        }

        public void SaveChanges()
        {
            _HLDbContext.SaveChanges();
        }
    }
}
