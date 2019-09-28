using HelpLight.Repository.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace HelpLight.Repository.Contracts
{
    public interface IUserRepository : IWorkUnit
    {
        void AddUser(User user);
        Contracts.User GetUser(Guid userId);
        //User GetUserById(Guid userId);
        bool IsOrganization(Guid id);
        Guid LoginUser(LoginUser loginUser);
    }
}
