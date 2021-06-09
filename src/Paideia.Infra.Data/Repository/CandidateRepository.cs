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
    public class CandidateRepository : ICandidateRepository
    {
        private readonly AppDbContext _context;

        public CandidateRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task Save(Candidate candidate)
        {
            _context.Add(candidate);
            await _context.SaveChangesAsync();
        }
        public async Task<IEnumerable<Candidate>> Get()
        {
            var model = _context.Candidate
                .Include(c => c.Training)                  
                .ToList();
            return await Task.FromResult(model);
        }      
        public async Task<int> ValidEmail(string email)
        {
            var query = _context.Candidate
                .Where(x => x.Email == email);
            var result = query.Count();
            return await Task.FromResult(result);
        }

        public async Task Remove(Guid id)
        {
            var candidate = _context.Candidate.Where(x => x.Id == id).FirstOrDefault();
            _context.Remove(candidate);
            var result = await _context.SaveChangesAsync();
        }
        public async Task<Candidate> GetById(Guid id)
        {
            var candidate = _context.Candidate.Where(x => x.Id == id).FirstOrDefault();
            return await Task.FromResult(candidate);
        }
        public async Task<CandidateStatus> GetByIdCandidate (Guid id)
        {
            var candidate = _context.CandidateStatus.Where(x => x.CandidateId == id).FirstOrDefault();
            return await Task.FromResult(candidate);
        }
        public async Task<CandidateStatus> UpdateStatus(CandidateStatus candidate)
        {
            var train = _context.Update(candidate);
            await _context.SaveChangesAsync();
            return train.Entity;
        }
        public async Task<Candidate> Update(Candidate candidate)
        {
            var train = _context.Update(candidate);
            await _context.SaveChangesAsync();
            return train.Entity;
        }
        public async Task AddStatus(Guid id)
        {
            var candidateStatus = new CandidateStatus
            {
                CandidateId = id,
                StatusId = new Guid("73aa8855-c2a5-459b-bcf3-32274f3cbfe4"),
                Id = new Guid()
            };
            _context.CandidateStatus.Add(candidateStatus);
            await _context.SaveChangesAsync();
        }
}
}
