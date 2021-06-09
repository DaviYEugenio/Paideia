using Microsoft.EntityFrameworkCore;
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
    public class TrainingClassRepository : ITrainingClassRepository
    {
        private readonly AppDbContext _context;

        public TrainingClassRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<TrainingClass>> Get()
        {
            var model = _context.TrainingClass.Include(c => c.Training).ToList();
            return await Task.FromResult(model);
        }
        public async Task Save(TrainingClass model)
        {
            _context.Add(model);
            await _context.SaveChangesAsync();
        }
        public async Task Remove(Guid id)
        {
            var trainingClass = _context.TrainingClass.Where(x => x.Id == id).FirstOrDefault();
            _context.Remove(trainingClass);
            var result = await _context.SaveChangesAsync();
        }
        public async Task<TrainingClass> GetById(Guid id)
        {
            var trainingClass = _context.TrainingClass.Where(x => x.Id == id).FirstOrDefault();
            return await Task.FromResult(trainingClass);
        }
        public async Task<TrainingClass> Update(TrainingClass trainingClass)
        {
            var train = _context.Update(trainingClass);
            await _context.SaveChangesAsync();
            return train.Entity;
        }
    }
}






