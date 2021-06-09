using Paideia.Application.Interfaces;
using Paideia.Domain.Entities;
using Paideia.Domain.Interfaces;
using Paideia.Infra.CrossCutting.Identity.Interface;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Paideia.Application.Services
{
    public class TraningAppService : ITraningAppService
    {
        private readonly ICurrentUser _currentUser;
        private readonly ITrainingRepository _trainingRepository;

        public TraningAppService(ITrainingRepository trainingRepository,
            ICurrentUser currentUser)
        {
            _currentUser = currentUser;
            _trainingRepository = trainingRepository;
        }
        public async Task<IEnumerable<TrainingViewModel>> GetAll()
        {
            var training = new List<TrainingViewModel>();

            var result = await _trainingRepository.GetAll();

            foreach (var item in result)
            {
                training.Add(new TrainingViewModel
                {
                    Id = item.Id,
                    Name = item.Name,
                    CoordinatorName = item.Coordinator.Name,
                    Descripition = item.Description,
                    StartDateYear = item.StartDateYear,
                    Workload = item.Workload,
                    Requirements = item.Requirements,
                });
            }
            return training;
        }
        public async Task Add(TrainingViewModel model)
        {
            var training = new Training
            {
                Name = model.Name,
                CoordinatorId = model.CoordinatorId,
                Workload = model.Workload,
                Description = model.Descripition,
                Requirements = model.Requirements,
                StartDateYear = model.StartDateYear,
                UserId = await _currentUser.GetCurrentId(),
                CreatedDate = DateTime.UtcNow               
        };            
            await _trainingRepository.Add(training);
        }
        public async Task Remove(Guid id)
        {
            await _trainingRepository.Remove(id);
        }
        public async Task<TrainingViewModel> GetById(Guid id)
        {
            var training = await _trainingRepository.GetById(id);
            var trainingViewModel = new TrainingViewModel
            {        
                Id = training.Id,
                Name = training.Name,
                Requirements = training.Requirements,
                StartDateYear = training.StartDateYear, 
                Workload = training.Workload,                 
                Descripition = training.Description,
                CoordinatorId = training.CoordinatorId,
                CoordinatorName = training.Coordinator.Name
            };        
            return trainingViewModel;
        }
       
        public async Task Update(TrainingViewModel model)
        {
            var training = await _trainingRepository.GetById(model.Id);
            if (training != null)
            {
                training.Name = model.Name;
                training.Requirements = model.Requirements;
                training.StartDateYear = model.StartDateYear;
                training.Workload = model.Workload;
                training.CoordinatorId = model.CoordinatorId;
                training.Description = model.Descripition;
                training.UserId = await _currentUser.GetCurrentId();
                training.UpdatedDate = DateTime.UtcNow;               
                await _trainingRepository.Update(training);
            }
            await _trainingRepository.GetAll();
        }
    }
}

    

