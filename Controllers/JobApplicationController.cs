namespace AprendendoAPI.API.Controllers{
    using AprendendoAPI.API.Models;
    using AprendendoAPI.API.Persistence.Repositories;
    using AprendendoAPI.API.Pesistence;
    using AprendendoAPI.Entities;
    using Microsoft.AspNetCore.Mvc;

[Route("api/job-vacancies/{id}/applications")]
[ApiController]
public class JobApplicationController : ControllerBase
{
    private readonly IJobVacancyRepository _repository;
    public JobApplicationController(IJobVacancyRepository repository)
    {
        _repository = repository;
    }
    
    [HttpPost]
    public IActionResult Post(int id, AddJobApplicationInputModel model)
    {
        var jobVacancy = _repository.GetById(id);
        if (jobVacancy == null)
        {
            return NotFound();
        }
        var application = new JobApplication(model.ApplicantName, model.applicantEmail, id);

        _repository.AddApplication(application);
        return NoContent();
    }
}

}