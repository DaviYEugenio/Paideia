using Paideia.Application.Interfaces;
using Paideia.Application;
using Paideia.Domain.Entities;
using Paideia.Domain.Interfaces;
using Paideia.Infra.CrossCutting.Identity.Interface;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Paideia.Application.Services
{
    public class CoordinatorAppService : ICoordinatorAppService
    {
        private readonly ICurrentUser _currentUser;
        private readonly ICoordinatorRepository _coordinatorRepository;

        public CoordinatorAppService(ICoordinatorRepository coordinatorRepository,
            ICurrentUser currentUser)
        {
            _coordinatorRepository = coordinatorRepository;
            _currentUser = currentUser;
        }
        public async Task<IEnumerable<CoordinatorViewModel>> Get()
        {
            var model = new List<CoordinatorViewModel>();

            var result = await _coordinatorRepository.Get();

            foreach (var item in result)
            {
                model.Add(new CoordinatorViewModel
                {
                    Id = item.Id,               
                    Email = item.Email,                  
                    Name = item.Name                  
                });
            }
            return model;
        }

        public async Task Save(CoordinatorViewModel model)
        {
            var module = new Coordinator
            {              
                Name = model.Name,                
                Email = model.Email,               
                Id = model.Id,
                UserId = await _currentUser.GetCurrentId(),
                CreatedDate = DateTime.UtcNow,
            };
            await _coordinatorRepository.Save(module);
        }
        public async Task Remove(Guid id)
        {
            await _coordinatorRepository.Remove(id);
        }
        public async Task<CoordinatorViewModel> GetById(Guid id)
        {
            var coordinator = await _coordinatorRepository.GetById(id);
            var coordinatorViewModel = new CoordinatorViewModel
            {
                
                Id = coordinator.Id,
                Name = coordinator.Name,                
                Email = coordinator.Email,              
            };
            return coordinatorViewModel;
        }
        public async Task Update(CoordinatorViewModel model)
        {
            var coordinator = await _coordinatorRepository.GetById(model.Id);
            if (coordinator != null)
            {
                coordinator.Name = model.Name;
                coordinator.Email = model.Email;
                coordinator.Id = model.Id;
                coordinator.UserId = await _currentUser.GetCurrentId();
                coordinator.UpdatedDate = DateTime.UtcNow;
                await _coordinatorRepository.Update(coordinator);
            }
            await _coordinatorRepository.Get();
        }
    }
}
