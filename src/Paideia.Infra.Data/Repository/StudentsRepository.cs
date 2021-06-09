using Paideia.Domain.Interfaces;
using Paideia.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Text;

namespace Paideia.Infra.Data.Repository
{
    public class StudentsRepository : IStudentsRepository
    {
        private readonly AppDbContext _context;

        public StudentsRepository(AppDbContext context)
        {
            _context = context;
        }
    }
}
