﻿using System;
namespace Business.Dtos.Requests.DeleteRequests;

public class DeleteCountryRequest
{
    public Guid Id { get; set; }
    public string Name { get; set; }
}