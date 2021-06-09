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
    public class FilterRepository : IFilterRepository
    {
        private readonly AppDbContext _context;

        public FilterRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<CandidateStatus>> GetByIdStatus(string id)
        {
            var convert = new Guid(id);
            var model = _context.CandidateStatus
                .Include(c => c.Candidate)
                .Include(o => o.Status)
                .Include(c => c.Candidate.Training)
                .Where(x => x.StatusId == convert)
                .ToList();
            return await Task.FromResult(model);
        }
        public async Task<IEnumerable<CandidateStatus>> GetCandidateStatus()
        {            
            var model = _context.CandidateStatus
                .Include(c => c.Status)
                .Include(x => x.Candidate)
                .Include(x => x.Candidate.Training)
                .ToList();
            return await Task.FromResult(model);
        }             
    }
}
