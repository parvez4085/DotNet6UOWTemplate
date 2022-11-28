using Template.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Template.Domain.Users;
public interface IUserRepository : IRepository<User>
{
    User NewUser(string userName
        , string email);

    Task<IEnumerable<User>> GetUsers();
    Task<IEnumerable<User>> GetByUsername(string username);

}