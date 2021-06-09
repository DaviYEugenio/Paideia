using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Paideia.Domain.Entities;


namespace Paideia.Infra.Data.Context
{
    public class AppDbContext : IdentityDbContext<IdentityUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        { }
        public DbSet<Training> Training {get;set;}
        public DbSet<TrainingModel> TrainingModel {get;set;}
        public DbSet<TrainingClass> TrainingClass {get;set;}
        public DbSet<Teacher> Teacher {get;set;}
        public DbSet<Coordinator> Coordinator {get;set;}
        public DbSet<Status> Status { get;set;}
        public DbSet<Church> Church {get;set;}
        public DbSet<Discipline> Discipline { get; set; }
        public DbSet<Dropouts> Dropouts { get; set; }
        public DbSet<Candidate> Candidate { get; set; }  
        public DbSet<TeacherDisciplines> TeacherDisciplines {get;set;}
        public DbSet<CandidateStatus> CandidateStatus { get; set; }

    }
}