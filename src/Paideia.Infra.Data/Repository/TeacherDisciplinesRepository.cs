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
    public class TeacherDisciplinesRepository : ITeacherDisciplinesRepository
    {       
        private readonly AppDbContext _context;

        public TeacherDisciplinesRepository(AppDbContext context)
        {            
            _context = context;
        }
        public async Task Save(TeacherDisciplines model)
        {           
                _context.Add(model);
                await _context.SaveChangesAsync();           
        }
        public async Task Remove(Guid id)
        {           
                var teacherDisciplines = _context.TeacherDisciplines.Where(x => x.TeacherId == id).ToList();
                _context.RemoveRange(teacherDisciplines);
                var result = await _context.SaveChangesAsync();          
        }        
        public async Task<IEnumerable<TeacherDisciplines>> GetByTeacherId(Guid theacherId)
        {
            var query = from teacherDisciplines in _context.Set<TeacherDisciplines>()
                            join discipline in _context.Set<Discipline>()
                            on teacherDisciplines.DisciplineId equals discipline.Id                          
                            where (teacherDisciplines.TeacherId == theacherId)
                            select new TeacherDisciplines
                            {   
                                Discipline = discipline,                               
                                DisciplineId = discipline.Id,                                
                            };
            var result = query.ToList();

            return await Task.FromResult(result);
        }
    }
}
