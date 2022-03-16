
namespace AprendendoAPI.API.Controllers{
    using AprendendoAPI.API.Models;
    using AprendendoAPI.API.Pesistence;
    using AprendendoAPI.Entities;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;

    [Route("api/job-vacancies")]
[ApiController]
public class JobVacanciesController : ControllerBase
{
    private readonly AprendendoAPIContext _context;
    public JobVacanciesController(AprendendoAPIContext context)
    {
        _context = context;
    }
    
    [HttpGet]
    public IActionResult GetAll()
    {
        var JobVacancies = _context.JobVacancies;
        return Ok(JobVacancies);
    }

    [HttpGet("{id}")]
    public IActionResult GetById(int id){
        var jobVacancy = _context.JobVacancies.Include(jv => jv.Applications).SingleOrDefault(jv => jv.Id == id);
        if (jobVacancy == null)
        {
            return NotFound();
        }
        return Ok(jobVacancy);
    }

    [HttpPost]
    public IActionResult Post(AddJobVacancyInputModel model){
        var jobVacancy = new JobVacancy(model.Title, model.Description, model.Company, model.IsRemote, model.SalaryRange);
        _context.JobVacancies.Add(jobVacancy);
        _context.SaveChanges();
        return CreatedAtAction("GetById", new{id = jobVacancy.Id}, jobVacancy);
    }

    [HttpPut("{id}")]
    public IActionResult Put(int id,UpdateJobVacancyInputModel model){
        var jobVacancy = _context.JobVacancies.SingleOrDefault(jv => jv.Id == id);
        if (jobVacancy == null)
        {
            return NotFound();
        }

        jobVacancy.Update(model.Title, model.Description);
        _context.SaveChanges();
        
        return NoContent();
    }
}

}