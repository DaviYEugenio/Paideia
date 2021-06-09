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
    public class CoordinatorRepository : ICoordinatorRepository  
    {
        private readonly AppDbContext _context;

        public CoordinatorRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task Save(Coordinator coordinator)
        {
            _context.Add(coordinator);
            await _context.SaveChangesAsync();
        }
        public async Task<IEnumerable<Coordinator>> Get()
        {
            var model = _context.Coordinator.ToList();
            return await Task.FromResult(model);
        }
        public async Task Remove(Guid id)
        {
            var coordinator = _context.Coordinator
                .Where(x => x.Id == id)
                .FirstOrDefault();
            _context.Remove(coordinator);
            var result = await _context.SaveChangesAsync();
        }
        public async Task<Coordinator> GetById(Guid id)
        {
            var coordinator = _context.Coordinator
                .Where(x => x.Id == id)
                .FirstOrDefault();
            return await Task.FromResult(coordinator);
        }
        public async Task<Coordinator> Update(Coordinator coordinator)
        {
            var train = _context.Update(coordinator);
            await _context.SaveChangesAsync();
            return train.Entity;
        }
    }
}
