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
    public class ChurchAppService : IChurchAppService
    {
        private readonly ICurrentUser _currentUser;
        private readonly IChurchRepository _churchRepository;

        public ChurchAppService(IChurchRepository churchRepository,
            ICurrentUser currentUser)
        {
            _churchRepository = churchRepository;
            _currentUser = currentUser;
        }
        public async Task<IEnumerable<ChurchViewModel>> Get()
        {
            var model = new List<ChurchViewModel>();

            var result = await _churchRepository.Get();

            foreach (var item in result)
            {
                model.Add(new ChurchViewModel
                {
                    Id = item.Id,
                    Name = item.Name,                    
                    Street = item.Street,
                    Cep = item.Cep,
                    City = item.City,
                    Neighborhood = item.Neighborhood,
                    Number = item.Number,
                    Shepherd = item.Shepherd,
                    State = item.State,
                });
            }
            return model;
        }

        public async Task Save(ChurchViewModel model)
        {
            var module = new Church
            {
                Id = model.Id,
                Name = model.Name,                
                Street = model.Street,
                Cep = model.Cep,
                City = model.City,
                Neighborhood = model.Neighborhood,
                Number = model.Number,
                Shepherd = model.Shepherd,
                State = model.State,
                UserId = await _currentUser.GetCurrentId(),
                CreatedDate = DateTime.UtcNow,
            };
            await _churchRepository.Save(module);
        }
        public async Task Remove(Guid id)
        {
            await _churchRepository.Remove(id);
        }
        public async Task<ChurchViewModel> GetById(Guid id)
        {
            var church = await _churchRepository.GetById(id);
            var churchViewModel = new ChurchViewModel
            {                
                Name = church.Name,               
                Street = church.Street,
                Cep = church.Cep,
                City = church.City,
                Neighborhood = church.Neighborhood,
                Number = church.Number,
                Shepherd = church.Shepherd,
                State = church.State                
            };
            return churchViewModel;
        }
        public async Task Update(ChurchViewModel model)
        {
            var church = await _churchRepository.GetById(model.Id);
            if (church != null)
            {
                church.Name = model.Name;                
                church.Street = model.Street;
                church.Cep = model.Cep;
                church.City = model.City;
                church.Neighborhood = model.Neighborhood;
                church.Number = model.Number;
                church.Shepherd = model.Shepherd;
                church.State = model.State;
                church.UserId = await _currentUser.GetCurrentId();
                church.UpdatedDate = DateTime.UtcNow;
                await _churchRepository.Update(church);
            }
            await _churchRepository.Get();
        }
    }
}
