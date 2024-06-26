﻿using System.Runtime.InteropServices.JavaScript;

namespace Domain.Model;

public class Survey
{
    public int Id { get; set; }
    public string Question { get; set; }
    public string CreatedBy { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime DueDate { get; set; }
    public Settings Settings { get; set; }
    
    public List<Option> Options { get; set; }
    public virtual List<Vote> Votes { get; set; }

}