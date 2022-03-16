using AprendendoAPI.Entities;

namespace AprendendoAPI.API.Persistence.Repositories{

    public interface IJobVacancyRepository{
        List<JobVacancy> GetAll();
        JobVacancy GetById(int id);
        void add(JobVacancy jobVacancy);
        void Update(JobVacancy jobVacancy);
        void AddApplication(JobApplication jobApplication);
    }

}