using Paideia.Application.Interfaces;
using Paideia.Domain.Entities;
using Paideia.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Paideia.Application.Services
{
    public class TeacherDisciplinesAppService : ITeacherDisciplinesAppService
    {
        private readonly ITeacherDisciplinesRepository _teacherDisciplinesRepository;
        public TeacherDisciplinesAppService(ITeacherDisciplinesRepository teacherDisciplinesRepository)
        {
            _teacherDisciplinesRepository = teacherDisciplinesRepository;
        }

        public async Task Save(TeacherViewModel model, Guid id)
        {
            foreach (var item in model.DisciplineIds)
            {
                var discipline = new TeacherDisciplines
                {
                    DisciplineId = item,
                    TeacherId = id
                };                
                    await _teacherDisciplinesRepository.Save(discipline);
               
            }
        }
        public async Task Remove(Guid id)
        {            
            await _teacherDisciplinesRepository.Remove(id);
        }
         public async Task<IEnumerable<TeacherDisciplinesViewModel>> GetByTeacherId(Guid teacherId)
        {
            var model = new List<TeacherDisciplinesViewModel>();

            var result = await _teacherDisciplinesRepository.GetByTeacherId(teacherId);
            foreach (var item in result)
            {
                model.Add(new TeacherDisciplinesViewModel
                {
                    DisciplineName = item.Discipline.Name,
                    TrainingName = item.Discipline.TrainingModel.Training.Name,
                    TrainingModelName = item.Discipline.TrainingModel.Module,
                    DisciplineId = item.Discipline.Id,    
                });
            }
            return model;
        }
    }
}
