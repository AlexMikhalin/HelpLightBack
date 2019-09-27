using HelpLight.Repository.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace HelpLight.Repository.Contracts
{
    public interface IUserRepository : IWorkUnit
    {
        void AddUser(User user);
        List<Data.Models.User> GetAllUsers(); // for test now
        //User GetUserById(Guid userId);
        bool IsOrganization(Guid id);
        Guid LoginUser(LoginUser loginUser);
    }
}
