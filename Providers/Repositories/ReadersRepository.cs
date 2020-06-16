using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ReadersCqrsApp.Models;
using ReadersCqrsApp.Models.Entities;
using ReadersCqrsApp.Providers.Context;

namespace ReadersCqrsApp.Providers.Repositories
{
    public interface IReadersRepository
    {
        Task<int> CreateReader(CreateReaderModel model);
        IEnumerable<Reader> GetAll();
        Reader GetSingle(int readerId);
        Task<int> UpdateReader(int readerId, UpdateReaderModel model);
    }

    public class ReadersRepository : IReadersRepository
    {
        private readonly AppDbContext context;

        public ReadersRepository(AppDbContext context)
        {
            this.context = context;
        }

        public IEnumerable<Reader> GetAll()
        {
            var readers = context.Readers.Include(x => x.User);
            return readers.ToList();
        }

        public Reader GetSingle(int readerId)
        {
            return context.Readers.Include(x => x.User).FirstOrDefault(x => x.Id == readerId);
        }

        public async Task<int> CreateReader(CreateReaderModel model)
        {
            var reader = new Reader
            {
                Bio = model.Bio,
                Alias = model.Alias,
                AddedOn = DateTime.Now,
                UserId = model.UserId
            };

            await context.Readers.AddAsync(reader);
            await context.SaveChangesAsync();

            return reader.Id;
        }

        public async Task<int> UpdateReader(int readerId, UpdateReaderModel model)
        {
            var reader = context.Readers.FirstOrDefault(x => x.Id == readerId);

            if (reader != null)
            {
                if (!string.IsNullOrEmpty(model.Bio))
                    reader.Bio = model.Bio;
                if (!string.IsNullOrEmpty(model.Alias))
                    reader.Alias = model.Alias;

                context.Readers.Update(reader);
                await context.SaveChangesAsync();

                return reader.Id;
            }

            return -1;
        }
    }
}