using Paideia.Application.Interfaces;
using Paideia.Domain.Entities;
using Paideia.Domain.Interfaces;
using Paideia.Infra.CrossCutting.Identity.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paideia.Application.Services
{
    public class TeacherAppService : ITeacherAppService
    {
        private readonly ICurrentUser _currentUser;
        private readonly ITeacherRepository _teacherRepository;        
        private readonly ITeacherDisciplinesAppService _teacherDisciplinesAppService;

        public TeacherAppService(ITeacherRepository teacherRepository,
            ICurrentUser currentUser,
            ITeacherDisciplinesAppService teacherDisciplinesAppService)
        {
            _teacherRepository = teacherRepository;
            _currentUser = currentUser;
            _teacherDisciplinesAppService = teacherDisciplinesAppService;
        }
        public async Task<IEnumerable<TeacherViewModel>> Get()
        {
            var model = new List<TeacherViewModel>();

            var result = await _teacherRepository.Get();

            foreach (var item in result)
            {
                model.Add(new TeacherViewModel
                {               
                    Id = item.Id.ToString(),
                    Name = item.Name,
                    Apresentation = item.Apresentation,                   
                });
            }
            return model;
        }
        public async Task Save(TeacherViewModel model)
        {
            var teacherVm = new Teacher
            {
                Name = model.Name,
                Apresentation = model.Apresentation,        
                UserId = await _currentUser.GetCurrentId(),
                CreatedDate = DateTime.UtcNow
            };
                await _teacherRepository.Save(teacherVm);
                await _teacherDisciplinesAppService.Save(model, teacherVm.Id);          
        }
        public async Task Remove(Guid id)
        {
            await _teacherRepository.Remove(id);            
        }
        public async Task<TeacherViewModel> GetById(Guid id)
        {           
            var teacher = await _teacherRepository.GetById(id);
            var teacherViewModel = new TeacherViewModel            
            {               
                Name = teacher.Name,
                Apresentation = teacher.Apresentation,             
                Id = teacher.Id.ToString(),                  
            };
            teacherViewModel.Disciplines =  _teacherDisciplinesAppService.GetByTeacherId(id).Result.ToList();            
            return teacherViewModel;
        }

        public async Task Update(TeacherViewModel model)                        
        {                   
            var teacher = await _teacherRepository.GetById(new Guid(model.Id));                 
            await _teacherDisciplinesAppService.Remove(new Guid(model.Id));           
            await _teacherDisciplinesAppService.Save(model, new Guid(model.Id));                              
            if (teacher != null)             
            {                  
                teacher.Name = model.Name;                                               
                teacher.Apresentation = model.Apresentation;           
                teacher.UserId = await _currentUser.GetCurrentId();                            
                teacher.UpdatedDate = DateTime.UtcNow;
                await _teacherRepository.Update(teacher);              
            }                        
            await _teacherRepository.Get();            
        }               
    }
}
