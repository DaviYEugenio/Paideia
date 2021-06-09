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
    public class ChurchRepository : IChurchRepository
    {
        private readonly AppDbContext _context;

        public ChurchRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task Save(Church church)
        {
            _context.Add(church);
            await _context.SaveChangesAsync();
        }
        public async Task<IEnumerable<Church>> Get()
        {
            var model = _context.Church.ToList();
            return await Task.FromResult(model);
        }
        public async Task Remove(Guid id)
        {
            var church = _context.Church
                .Where(x => x.Id == id)
                .FirstOrDefault();
            _context.Remove(church);
            var result = await _context.SaveChangesAsync();
        }
        public async Task<Church> GetById(Guid id)
        {
            var church = _context.Church
                .Where(x => x.Id == id)
                .FirstOrDefault();
            return await Task.FromResult(church);
        }
        public async Task<Church> Update(Church church)
        {
            var train = _context.Update(church);
            await _context.SaveChangesAsync();
            return train.Entity;
        }
    }
}
