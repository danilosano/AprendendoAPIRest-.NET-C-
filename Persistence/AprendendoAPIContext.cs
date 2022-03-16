using AprendendoAPI.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace AprendendoAPI.API.Pesistence{
    public class AprendendoAPIContext : DbContext{
        public AprendendoAPIContext(DbContextOptions<AprendendoAPIContext> option) : base(option)
        {
            
        }
        public DbSet<JobVacancy> JobVacancies {get;set;}
        public DbSet<JobApplication> JobApplication { get; set; }
        protected override void OnModelCreating(ModelBuilder builder){
            builder.Entity<JobVacancy>(e => {
                e.HasKey(jv => jv.Id);
                e.HasMany(jv => jv.Applications).WithOne().HasForeignKey(ja => ja.IdJobVacancy).OnDelete(DeleteBehavior.Restrict);
            });

            builder.Entity<JobApplication>(e =>{
                e.HasKey(ja => ja.Id);
            });

        }
        
    }
}