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
    public class DropoutsAppService : IDropoutsAppService
    {
        private readonly ICurrentUser _currentUser;
        private readonly IDropoutsRepository _dropoutsRepository;

        public DropoutsAppService(IDropoutsRepository dropoutsRepository,
            ICurrentUser currentUser)
        {
            _dropoutsRepository = dropoutsRepository;
            _currentUser = currentUser;
        }
        public async Task<IEnumerable<DropoutsViewModel>> Get()
        {
            var model = new List<DropoutsViewModel>();

            var result = await _dropoutsRepository.Get();

            foreach (var item in result)
            {
                model.Add(new DropoutsViewModel
                {
                    Id = item.Id,
                    IsFromIBPV = item.IsFromIBPV,
                    ShepherdOrMissionary = item.ShepherdOrMissionary,
                    Reason = item.Reason,
                    Cell = item.Cell,
                    Church = item.Church,
                    Email = item.Email,
                    FoneComercial = item.FoneComercial,
                    DateInscription = item.DateInscription,
                    Fone = item.Fone,
                    Name = item.Name,
                    DateDropout = item.DateDropout,
                });
            }
            return model;
        }

        public async Task Save(DropoutsViewModel model)
        {
            var dropouts = new Dropouts
            {
                CandidateId = model.CandidateId,
                IsFromIBPV = model.IsFromIBPV,
                ShepherdOrMissionary = model.ShepherdOrMissionary,
                Reason = model.Reason,
                Name = model.Name,
                Cell = model.Cell,
                Church = model.Church,
                Fone = model.Fone,
                DateInscription = model.DateInscription,
                Email = model.Email,
                FoneComercial = model.FoneComercial,
                Id = model.Id,
                UserId = await _currentUser.GetCurrentId(),
                CreatedDate = DateTime.UtcNow,
                DateDropout = model.DateDropout,
            };
            await _dropoutsRepository.Save(dropouts);
        }
        public async Task Remove(Guid id)
        {
            await _dropoutsRepository.Remove(id);
        }
        public async Task<DropoutsViewModel> GetById(Guid id)
        {
            var dropouts = await _dropoutsRepository.GetById(id);
            var dropoutsViewModel = new DropoutsViewModel
            {
                IsFromIBPV = dropouts.IsFromIBPV,
                ShepherdOrMissionary = dropouts.ShepherdOrMissionary,
                DateDropout = dropouts.DateDropout,
                Reason = dropouts.Reason,
                Id = dropouts.Id,
                Name = dropouts.Name,
                Cell = dropouts.Cell,
                FoneComercial = dropouts.FoneComercial,
                Email = dropouts.Email,
                DateInscription = dropouts.DateInscription,
                Fone = dropouts.Fone,
                Church = dropouts.Church,
                CandidateId = dropouts.CandidateId,
            };
            return dropoutsViewModel;
        }
        public async Task<DropoutsViewModel> GetByName(string name)
        {
            var dropouts = await _dropoutsRepository.GetByName(name);
            var dropoutsViewModel = new DropoutsViewModel
            {
                IsFromIBPV = dropouts.IsFromIBPV,
                ShepherdOrMissionary = dropouts.ShepherdOrMissionary,
                Name = dropouts.Name,
                Cell = dropouts.Cell,
                FoneComercial = dropouts.FoneComercial,
                Email = dropouts.Email,
                DateInscription = dropouts.DateInscription,
                Fone = dropouts.Fone,
                Church = dropouts.Church,
            };
            return dropoutsViewModel;
        }
        public async Task Update(DropoutsViewModel model)
        {
            var dropouts = await _dropoutsRepository.GetById(model.Id);
            if (dropouts != null)
            {
                dropouts.IsFromIBPV = model.IsFromIBPV;
                dropouts.ShepherdOrMissionary = model.ShepherdOrMissionary;
                dropouts.Reason = model.Reason;
                dropouts.Name = model.Name;
                dropouts.DateDropout = model.DateDropout;
                dropouts.Church = model.Church;
                dropouts.Cell = model.Cell;
                dropouts.DateInscription = model.DateInscription;
                dropouts.Email = model.Email;
                dropouts.Fone = model.Fone;
                dropouts.FoneComercial = model.FoneComercial;
                dropouts.Id = model.Id;
                dropouts.UserId = await _currentUser.GetCurrentId();
                dropouts.UpdatedDate = DateTime.UtcNow;
                await _dropoutsRepository.Update(dropouts);
            }
            await _dropoutsRepository.Get();
        }
    }
}
