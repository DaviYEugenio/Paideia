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
    public class DisciplineRepository : IDisciplineRepository
    {
        private readonly AppDbContext _context;

        public DisciplineRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Discipline>> Get()
        {
            var query = from discipline in _context.Set<Discipline>()
                        join trainingModel in _context.Set<TrainingModel>()
                            on discipline.TrainingModelId equals trainingModel.Id
                        join training in _context.Set<Training>()
                             on trainingModel.TrainingId equals training.Id
                        select new Discipline
                        {                            
                          Workload = discipline.Workload,
                          Requirements = discipline.Requirements,                            
                          Id = discipline.Id,
                          Description = discipline.Description,    
                          Name = discipline.Name,
                          TrainingModel = trainingModel,
                          Training = training                          
                        };

            var result = query.ToList();

            return await Task.FromResult(result);
        }
        public async Task Save(Discipline model)
        {
            _context.Add(model);
            await _context.SaveChangesAsync();
        }
        public async Task Remove(Guid id)
        {
            var discipline = _context.Discipline.Where(x => x.Id == id).FirstOrDefault();
            _context.Remove(discipline);
            var result = await _context.SaveChangesAsync();
        }
        public async Task<Discipline> GetById(Guid id)
        {           
            var query = from discipline in _context.Set<Discipline>()
                        join trainingModel in _context.Set<TrainingModel>()
                            on discipline.TrainingModelId equals trainingModel.Id
                        join training in _context.Set<Training>()
                             on trainingModel.TrainingId equals training.Id
                        where(discipline.Id == id)
                        select new Discipline
                        {
                            Workload = discipline.Workload,
                            Requirements = discipline.Requirements,
                            Id = discipline.Id,
                            Description = discipline.Description,
                            Name = discipline.Name,
                            TrainingModel = trainingModel,
                            Training = training
                        };
            return await Task.FromResult(query.FirstOrDefault());
        }
        public async Task<Discipline> Update(Discipline discipline)
        {
            var train = _context.Update(discipline);
            await _context.SaveChangesAsync();
            return train.Entity;
        }
        public async Task<IEnumerable<Discipline>> GetByTrainingModelId(Guid trainingModelId)
        {
            var discipline = _context.Discipline.Where(x => x.TrainingModelId == trainingModelId).ToList();
            return await Task.FromResult(discipline);
        }
    }
}
