using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ReadersCqrsApp.Models;
using ReadersCqrsApp.Models.Entities;
using ReadersCqrsApp.Providers.Context;

namespace ReadersCqrsApp.Providers.Repositories
{
    public interface IUsersRepository
    {
        Task<int> CreateUser(UserRequestModel model);
        IEnumerable<UserResponseModel> GetAll();
        UserResponseModel GetSingle(int readerId);
        Task<int> UpdateUser(int readerId, UserRequestModel model);
    }

    public class UsersRepository : IUsersRepository
    {
        private readonly AppDbContext context;

        public UsersRepository(AppDbContext context)
        {
            this.context = context;
        }

        public async Task<int> CreateUser(UserRequestModel model)
        {
            var user = new User
            {
                EmailAddress = model.EmailAddress,
                Username = model.Username,
                AddedOn = DateTime.Now
            };

            await context.Users.AddAsync(user);
            await context.SaveChangesAsync();

            return user.Id;
        }

        public IEnumerable<UserResponseModel> GetAll()
        {
            var users = context.Users.Select(x => new UserResponseModel
            {
                Id = x.Id,
                EmailAddress = x.EmailAddress,
                Username = x.Username
            });

            return users.ToList();
        }

        public UserResponseModel GetSingle(int userId)
        {
            var user = context.Users.FirstOrDefault(x => x.Id == userId);

            if (user != null)
            {
                return new UserResponseModel
                {
                    Id = user.Id,
                    EmailAddress = user.EmailAddress,
                    Username = user.Username
                };
            }

            return new UserResponseModel();
        }

        public async Task<int> UpdateUser(int userId, UserRequestModel model)
        {
            var user = context.Users.FirstOrDefault(x => x.Id == userId);

            if (user != null)
            {
                if (!string.IsNullOrEmpty(model.Username))
                    user.Username = model.Username;
                if (!string.IsNullOrEmpty(model.EmailAddress))
                    user.EmailAddress = model.EmailAddress;

                context.Users.Update(user);
                await context.SaveChangesAsync();

                return user.Id;
            }

            return -1;
        }
    }
}