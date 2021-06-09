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
    public class TeacherRepository : ITeacherRepository
    {
        private readonly AppDbContext _context;

        public TeacherRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Teacher>> Get()
        {
            var teacher = _context.Teacher.ToList();
            return await Task.FromResult(teacher);
        }
        public async Task Save(Teacher model)
        {
            _context.Add(model);
            await _context.SaveChangesAsync();           
        }
        public async Task Remove(Guid id)
        {
            var teacher = _context.Teacher.Where(x => x.Id == id).FirstOrDefault();
            _context.Remove(teacher);
            var result = await _context.SaveChangesAsync();
        }
        public async Task<Teacher> GetById(Guid id)
        {
            var teacher = _context.Teacher.Where(x => x.Id == id).FirstOrDefault();
            return await Task.FromResult(teacher);
        }
        public async Task<Teacher> Update(Teacher teacher)
        {
            var teach = _context.Update(teacher);
            await _context.SaveChangesAsync();
            return teach.Entity;
        }
    }
}
