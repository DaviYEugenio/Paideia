using Microsoft.EntityFrameworkCore;
using Paideia.Domain.Entities;
using Paideia.Domain.Interfaces;
using Paideia.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Paideia.Infra.Data.Repository
{
    public class TrainingRepository : ITrainingRepository
    {
        private readonly AppDbContext _context;

        public TrainingRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task Add(Training training)
        {
            _context.Add(training);
            await _context.SaveChangesAsync();
        }
        public async Task<IEnumerable<Training>> GetAll()
        {
            var training =  _context.Training.Include(c => c.Coordinator).ToList();
            return await Task.FromResult(training);
        }        
        public async Task Remove(Guid id)
        {
            var training = _context.Training.Where(x => x.Id == id).FirstOrDefault();
            _context.Remove(training);
            var result = await _context.SaveChangesAsync();
        }
        public async Task<Training> GetById(Guid id)
        {
            var training = _context.Training.Where(x => x.Id == id).FirstOrDefault();
            return await Task.FromResult(training);
        }
        public async Task<Training> Update(Training training)
        {
            var train = _context.Update(training);
            await _context.SaveChangesAsync();
            return train.Entity;
        }

    }
}
