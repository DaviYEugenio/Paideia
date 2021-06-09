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
    public class ModelAppService : IModelAppService
    {
        private readonly ICurrentUser _currentUser;
        private readonly ITrainingModelRepository _modelRepository;

        public ModelAppService(ITrainingModelRepository modelRepository,
            ICurrentUser currentUser)
        {
            _currentUser = currentUser;
            _modelRepository = modelRepository;
        }
        public async Task<IEnumerable<ModelViewModel>> Get()
        {
            var model = new List<ModelViewModel>();

            var result = await _modelRepository.Get();

            foreach (var item in result)
            {
                model.Add(new ModelViewModel
                {
                    TrainingName = item.Training.Name,
                    Id = item.Id,
                    Module = item.Module,
                    Description = item.Description,
                    Workload = item.Workload,
                    Requirements = item.Requirements,

                });
            }
            return model;
        }

        public async Task Save(ModelViewModel model)
        {

            var module = new TrainingModel
            {
                TrainingId = model.TrainingId,
                Module = model.Module,
                Description = model.Description,
                Workload = model.Workload,
                Requirements = model.Requirements,
                UserId = await _currentUser.GetCurrentId(),
                CreatedDate = DateTime.UtcNow
            };
            await _modelRepository.Save(module);
        }
        public async Task Remove(Guid id)
        {
            await _modelRepository.Remove(id);
        }
        public async Task<ModelViewModel> GetById(Guid id)
        {
            var trainingModel = await _modelRepository.GetById(id);
            var modelViewModel = new ModelViewModel
            {      
                Module = trainingModel.Module,
                Workload = trainingModel.Workload,
                Requirements = trainingModel.Requirements,
                Description = trainingModel.Description,                
                Id = trainingModel.Id,
                TrainingId = trainingModel.TrainingId,
                TrainingName = trainingModel.Training.Name,
            };
            return modelViewModel;
        }

        public async Task Update(ModelViewModel model)
        {
            var trainingModel = await _modelRepository.GetById(model.Id);
            if (trainingModel != null)
            {
                trainingModel.Module = model.Module;
                trainingModel.Requirements = model.Requirements;
                trainingModel.TrainingId = model.TrainingId;
                trainingModel.Description = model.Description;
                trainingModel.Workload = model.Workload;                
                trainingModel.UserId = await _currentUser.GetCurrentId();
                trainingModel.UpdatedDate = DateTime.UtcNow;
                await _modelRepository.Update(trainingModel);
            }
            await _modelRepository.Get();
        }
        public async Task<IEnumerable<ModelViewModel>> GetByTrainingId(Guid trainingId)
        {
            var trainingModel = await _modelRepository.GetByTrainingId(trainingId);
            var model = new List<ModelViewModel>();
            foreach (var item in trainingModel)
            {
                model.Add(new ModelViewModel
                {
                    Module = item.Module,
                    Id = item.Id,                    
                });                
            }
            return model;

        }
    }
}

