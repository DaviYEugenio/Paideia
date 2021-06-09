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
    public class ClassAppService : IClassAppService
    {
        private readonly ICurrentUser _currentUser;
        private readonly ITrainingClassRepository _classRepository;

        public ClassAppService(ITrainingClassRepository classRepository,
            ICurrentUser currentUser)
        {
            _classRepository = classRepository;
            _currentUser = currentUser;
        }
        public async Task<IEnumerable<ClassViewModel>> Get()
        {
            var model = new List<ClassViewModel>();

            var result = await _classRepository.Get();

            foreach (var item in result)
            {
                model.Add(new ClassViewModel
                {
                    TrainingName = item.Training.Name,
                    Id = item.Id,  
                    Class = item.Name,
                    Description = item.Description,
                    StartDateYear = item.StartOfYear                     
                });
            }
            return model;
        }
        public async Task Save(ClassViewModel model)
        {

            var classVm = new TrainingClass
            {              
               Name = model.Class,
               Description = model.Description,
               StartOfYear = model.StartDateYear,              
               TrainingId = model.TrainingId,
               UserId = await _currentUser.GetCurrentId(),
               CreatedDate = DateTime.UtcNow
            };
            await _classRepository.Save(classVm);
        }
        public async Task Remove(Guid id)
        {
            await _classRepository.Remove(id);
        }
        public async Task<ClassViewModel> GetById(Guid id)
        {
            var trainingClass = await _classRepository.GetById(id);
            var classViewModel = new ClassViewModel
            {
                Class = trainingClass.Name,
                Description = trainingClass.Description,
                StartDateYear = trainingClass.StartOfYear,
                Id = trainingClass.Id,
                TrainingId = trainingClass.TrainingId,
                TrainingName = trainingClass.Training.Name,
            };
            return classViewModel;
        }

        public async Task Update(ClassViewModel model)
        {
            var trainingClass = await _classRepository.GetById(model.Id);
            if (trainingClass != null)
            {
                trainingClass.Name = model.Class;
                trainingClass.StartOfYear = model.StartDateYear;
                trainingClass.TrainingId = model.TrainingId;
                trainingClass.Description = model.Description;                
                trainingClass.UserId = await _currentUser.GetCurrentId();
                trainingClass.UpdatedDate = DateTime.UtcNow;
                await _classRepository.Update(trainingClass);
            }
            await _classRepository.Get();
        }
    }
}
