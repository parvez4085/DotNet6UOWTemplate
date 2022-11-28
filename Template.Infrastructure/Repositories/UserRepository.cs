using Template.Domain.Users;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace Template.Infrastructure.Repositories
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(DbFactory dbFactory) : base(dbFactory)
        {
        }

        public User NewUser(string userName, string email)
        {
            var user = new User()
            {
                UserName = userName,
                Email = email
            };
           
            this.Add(user);

            return user;
        }

        public async Task<IEnumerable<User>> GetUsers()
        {
            return await List(FilterByIsDeleted()).ToListAsync();
        }

        public async Task<IEnumerable<User>> GetByUsername(string username)
        {
            return await List(FilterByByUsername(username)).ToListAsync();
        }

        Expression<Func<User, bool>> FilterByIsDeleted()
        {
            return x => x.IsDeleted == false;
        }

        Expression<Func<User, bool>> FilterByByUsername(string username)
        {
            return x => x.UserName == username;
        }
    }
}
