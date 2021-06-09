using Paideia.Domain.Entities;
using Paideia.Domain.Interfaces;
using Paideia.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paideia.Infra.Data.Repository
{
    public class DropoutsRepository : IDropoutsRepository
    {
        private readonly AppDbContext _context;

        public DropoutsRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task Save(Dropouts dropouts)
        {
            _context.Add(dropouts);
            await _context.SaveChangesAsync();
        }
        public async Task<IEnumerable<Dropouts>> Get()
        {
            var model = _context.Dropouts.ToList();
            return await Task.FromResult(model);
        }
        public async Task Remove(Guid id)
        {
            var dropouts = _context.Dropouts
                .Where(x => x.Id == id)
                .FirstOrDefault();
            _context.Remove(dropouts);
            var result = await _context.SaveChangesAsync();
        }
        public async Task<Dropouts> GetById(Guid id)
        {
            var dropouts = _context.Dropouts
                .Where(x => x.Id == id)
                .FirstOrDefault();
            return await Task.FromResult(dropouts);
        }
        public async Task<Dropouts> GetByName(string name)
        {
            var dropouts = _context.Dropouts
                .Where(x => x.Name == name)
                .FirstOrDefault();
            return await Task.FromResult(dropouts);
        }
        public async Task<Dropouts> Update(Dropouts dropouts)
        {
            var train = _context.Update(dropouts);
            await _context.SaveChangesAsync();
            return train.Entity;
        }
    }
}
