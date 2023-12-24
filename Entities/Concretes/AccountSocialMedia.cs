﻿using Core.Entities;
using Microsoft.Identity.Client;

namespace Entities.Concretes;

public class AccountSocialMedia : Entity<Guid>
{
    public Guid AccountId { get; set; }
    public Guid SocialMediaId { get; set; }
    public string Url { get; set; }    

}