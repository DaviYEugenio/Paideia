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
     public class TrainingModelRepository : ITrainingModelRepository
    {
        private readonly AppDbContext _context;

        public TrainingModelRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task Save(TrainingModel model)
        {
            _context.Add(model);
            await _context.SaveChangesAsync();
        }
        public async Task<IEnumerable<TrainingModel>> Get()
        {           
            var model = _context.TrainingModel.Include(c => c.Training).ToList();
            return await Task.FromResult(model);
        }
        public async Task Remove(Guid id)
        {
            var trainingModel = _context.TrainingModel.Where(x => x.Id == id).FirstOrDefault();
            _context.Remove(trainingModel);
            var result = await _context.SaveChangesAsync();
        }
        public async Task<TrainingModel> GetById(Guid id)
        {
            var trainingModel = _context.TrainingModel.Where(x => x.Id == id).FirstOrDefault();
            return await Task.FromResult(trainingModel);
        }
        public async Task<TrainingModel> Update(TrainingModel trainingModel)
        {
            var train = _context.Update(trainingModel);
            await _context.SaveChangesAsync();
            return train.Entity;
        }
        public async Task<IEnumerable<TrainingModel>> GetByTrainingId(Guid trainingId)
        {
            var trainingModel = _context.TrainingModel.Where(x => x.TrainingId == trainingId).ToList();
            return await Task.FromResult(trainingModel);
        }
    }
}
