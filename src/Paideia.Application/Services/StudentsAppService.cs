using Paideia.Application.Interfaces;
using Paideia.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Paideia.Application.Services
{
    public class StudentsAppService : IStudentsAppService
    {
        private readonly IStudentsRepository _StudentsRepository;

        public StudentsAppService(IStudentsRepository StudentsRepository)
        {
            _StudentsRepository = StudentsRepository;
        }
    }
}
