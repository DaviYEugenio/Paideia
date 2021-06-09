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
    public class CandidateAppService : ICandidateAppService
    {
        private readonly IFilterRepository _filterRepository;
        private readonly ICurrentUser _currentUser;
        private readonly ICandidateRepository _candidateRepository;

        public CandidateAppService(ICandidateRepository candidateRepository, IFilterRepository filterRepository,
            ICurrentUser currentUser)
        {
            _filterRepository = filterRepository;
            _candidateRepository = candidateRepository;
            _currentUser = currentUser;
        }       
        public async Task<IEnumerable<CandidateViewModel>> GetByIdStatus(string id)
        {          
            var model = new List<CandidateViewModel>();                     
            if (id == default)
            {
                var getTrainingName = await _candidateRepository.Get();
                var result = await _filterRepository.GetCandidateStatus();
                foreach (var item in result)
                {                    
                    model.Add(new CandidateViewModel
                    {
                        Id = item.Candidate.Id,
                        IsFromIBPV = item.Candidate.IsFromIBPV,
                        ShepherdOrMissionary = item.Candidate.ShepherdOrMissionary,
                        SpouseTraining = item.Candidate.SpouseTraining,
                        Cell = item.Candidate.Cell,
                        Church = item.Candidate.Church,
                        Email = item.Candidate.Email,
                        FoneComercial = item.Candidate.FoneComercial,
                        DateInscription = item.Candidate.DateInscription,
                        Fone = item.Candidate.Fone,                        
                        Name = item.Candidate.Name,
                        TrainingName = item.Candidate.Training.Name,
                        Status = item.Status.Name
                    });                    
                }
            }
            else {
                var result = await _filterRepository.GetByIdStatus(id);
                foreach (var item in result)
                {                    
                        model.Add(new CandidateViewModel
                        {
                            Id = item.Candidate.Id,
                            IsFromIBPV = item.Candidate.IsFromIBPV,
                            ShepherdOrMissionary = item.Candidate.ShepherdOrMissionary,
                            SpouseTraining = item.Candidate.SpouseTraining,
                            Cell = item.Candidate.Cell,
                            Church = item.Candidate.Church,
                            Email = item.Candidate.Email,
                            FoneComercial = item.Candidate.FoneComercial,
                            DateInscription = item.Candidate.DateInscription,
                            Fone = item.Candidate.Fone,
                            Name = item.Candidate.Name,
                            TrainingName = item.Candidate.Training?.Name,  
                            Status = item.Status.Name
                        });
                   
                }
            }         
            return model;
        }

        public async Task<bool> Save(CandidateViewModel model)
        {
            var response = await _candidateRepository.ValidEmail(model.Email);
            if (response == 0)
            {
                
                var candidate = new Candidate
                {
                    DateInscription = DateTime.UtcNow,
                    IsFromIBPV = model.IsFromIBPV,
                    ShepherdOrMissionary = model.ShepherdOrMissionary,
                    SpouseTraining = model.SpouseTraining,
                    Name = model.Name,
                    Cell = model.Cell,
                    Church = model.Church,
                    Fone = model.Fone,
                    Email = model.Email,
                    FoneComercial = model.FoneComercial,
                    Id = model.Id,
                    TrainingId = model.TrainingId                      
                };
                await _candidateRepository.Save(candidate);
                await _candidateRepository.AddStatus(candidate.Id);
                return true;
            }
            else
            {
                return false;
            }
        }
        public async Task Remove(Guid id)
        {
            await _candidateRepository.Remove(id);
        }
        public async Task<CandidateViewModel> GetById(Guid id)
        {
            var candidate = await _candidateRepository.GetById(id);
            var candidateViewModel = new CandidateViewModel
            {
                IsFromIBPV = candidate.IsFromIBPV,
                ShepherdOrMissionary = candidate.ShepherdOrMissionary,
                SpouseTraining = candidate.SpouseTraining,
                Id = candidate.Id,
                Name = candidate.Name,
                Cell = candidate.Cell,
                FoneComercial = candidate.FoneComercial,
                Email = candidate.Email,
                Fone = candidate.Fone,
                Church = candidate.Church,
            };
            return candidateViewModel;
        }
        public async Task Update(CandidateViewModel model)
        {
            var candidate = await _candidateRepository.GetById(model.Id);
            if (candidate != null)
            {
                candidate.IsFromIBPV = model.IsFromIBPV;
                candidate.ShepherdOrMissionary = model.ShepherdOrMissionary;
                candidate.SpouseTraining = model.SpouseTraining;
                candidate.Name = model.Name;
                candidate.Church = model.Church;              
                candidate.Email = model.Email;
                candidate.Cell = model.Cell;
                candidate.Fone = model.Fone;
                candidate.FoneComercial = model.FoneComercial;
                candidate.Id = model.Id;
                await _candidateRepository.Update(candidate);
            }
            await _candidateRepository.Get();
        }
        public async Task UpdateStatus(Guid id)
        {
            var candidate = await _candidateRepository.GetByIdCandidate(id);
            if (candidate != null)
            {
                candidate.StatusId = new Guid("54c4d33d-f258-413c-8cbf-ad5adf8118c3");
                await _candidateRepository.UpdateStatus(candidate);
            }
            await _candidateRepository.Get();
        }
    }
}
