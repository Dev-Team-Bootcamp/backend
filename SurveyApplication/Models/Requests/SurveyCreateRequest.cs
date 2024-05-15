using Domain.Model;

namespace WebApplication1.Models.Requests;

public class SurveyCreateRequest
{
    public string Question { get; set; }
    public string CreatedBy { get; set; }
    public List<OptionDto> Options { get; set; }
    public Settings Settings { get; set; }
}