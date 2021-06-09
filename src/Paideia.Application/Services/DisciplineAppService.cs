using Paideia.Application.Interfaces;
using Paideia.Domain.Entities;
using Paideia.Domain.Interfaces;
using Paideia.Infra.CrossCutting.Identity.Interface;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Paideia.Application.Services
{
    public class DisciplineAppService : IDisciplineAppService
    {
        private readonly ICurrentUser _currentUser;
        private readonly IDisciplineRepository _disciplineRepository;

        public DisciplineAppService(IDisciplineRepository disciplineRepository,
            ICurrentUser currentUser)
        {
            _disciplineRepository = disciplineRepository;
            _currentUser = currentUser;
        }
        public async Task<IEnumerable<DisciplineViewModel>> Get()
        {
            var model = new List<DisciplineViewModel>();

            var result = await _disciplineRepository.Get();

            foreach (var item in result)
            {
                model.Add(new DisciplineViewModel
                {
                    TrainingName = item.Training.Name,
                    TrainingModelName = item.TrainingModel.Module,
                    Id = item.Id,
                    Name = item.Name,
                    Description = item.Description,
                    Workload = item.Workload,
                    Requirements = item.Requirements,
                });
            }
            return model;
        }
        public async Task Save(DisciplineViewModel model)
        {

            var disciplineVm = new Discipline
            {
                Name = model.Name,
                Description = model.Description,
                Requirements = model.Requirements,
                Workload = model.Workload,                
                TrainingModelId = model.TrainingModelId,                
                UserId = await _currentUser.GetCurrentId(),
                CreatedDate = DateTime.UtcNow
            };
            await _disciplineRepository.Save(disciplineVm);
        }
        public async Task Remove(Guid id)
        {
            await _disciplineRepository.Remove(id);
        }
        public async Task<DisciplineViewModel> GetById(Guid id)
        {
            var discipline = await _disciplineRepository.GetById(id);
            var disciplineViewModel = new DisciplineViewModel
            {
                Name = discipline.Name,
                Description = discipline.Description,
                Requirements = discipline.Requirements,
                Workload = discipline.Workload,
                Id = discipline.Id,
                TrainingModelId = discipline.TrainingModelId,            
                TrainingName = discipline.Training.Name,
                TrainingModelName = discipline.TrainingModel.Module,
            };
            return disciplineViewModel;
        }

        public async Task Update(DisciplineViewModel model)
        {
            var discipline = await _disciplineRepository.GetById(model.Id);
            if (discipline != null)
            {
                discipline.Name = model.Name;
                discipline.Workload = model.Workload;
                discipline.TrainingModelId = model.TrainingModelId;
                discipline.Requirements = model.Requirements;                
                discipline.Description = model.Description;
                discipline.UserId = await _currentUser.GetCurrentId();
                discipline.UpdatedDate = DateTime.UtcNow;
                await _disciplineRepository.Update(discipline);
            }
            await _disciplineRepository.Get();
        }
        public async Task<IEnumerable<DisciplineViewModel>> GetByTrainingModelId(Guid trainingModelId)
        {
            var discipline = await _disciplineRepository.GetByTrainingModelId(trainingModelId);
            var model = new List<DisciplineViewModel>();
            foreach (var item in discipline)
            {
                model.Add(new DisciplineViewModel
                {
                    Name = item.Name,
                    Id = item.Id,
                });
            }
            return model;

        }
    }
}
