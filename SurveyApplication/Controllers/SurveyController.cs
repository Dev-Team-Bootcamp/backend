using Domain.Model;
using Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Models.Requests;

namespace WebApplication1.Controllers;

[ApiController]
[Route("api/surveys")]
public class SurveyController : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] SurveyCreateRequest request)
    {
        await using var dbContext = new SurveyAppDbContext();
        var options = request.Options.Select(x => new Option
        {
            Description = x.Description,
            Type = x.Type,
            Order = x.Order
        }).ToList();

        var survey = new Survey
        {
            CreatedBy = request.CreatedBy,
            Options = options,
            Question = request.Question,
            CreatedDate = DateTime.Now,
            DueDate = DateTime.Now.AddDays(1),
            Settings = request.Settings
        };

        await dbContext.Surveys.AddAsync(survey);
        await dbContext.SaveChangesAsync();
        
        return Ok("Başarıyla kaydedildi.");
    }
}