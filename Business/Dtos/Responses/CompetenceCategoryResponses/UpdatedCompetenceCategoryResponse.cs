﻿using Entities.Concretes;

namespace Business.Dtos.Responses.CompetenceResponses;

public class UpdatedCompetenceCategoryResponse
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public virtual ICollection<CompetenceQuestion>? CompetenceQuestions { get; set; }
}