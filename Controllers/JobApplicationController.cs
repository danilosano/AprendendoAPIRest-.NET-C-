namespace AprendendoAPI.API.Controllers{
    using AprendendoAPI.API.Models;
    using AprendendoAPI.API.Pesistence;
    using AprendendoAPI.Entities;
    using Microsoft.AspNetCore.Mvc;

[Route("api/job-vacancies/{id}/applications")]
[ApiController]
public class JobApplicationController : ControllerBase
{
    private readonly AprendendoAPIContext _context;
    
    [HttpPost]
    public IActionResult Post(int id, AddJobApplicationInputModel model)
    {
        var jobVacancy = _context.JobVacancies.SingleOrDefault(jv => jv.Id == id);
        if (jobVacancy == null)
        {
            return NotFound();
        }
        var application = new JobApplication(model.ApplicantName, model.applicantEmail, id);

        _context.JobApplication.Add(application);
        return NoContent();
    }
}

}