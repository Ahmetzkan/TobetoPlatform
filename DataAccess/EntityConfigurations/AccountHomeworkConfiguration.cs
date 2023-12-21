﻿using Entities.Concretes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.EntityConfigurations
{
    public class AccountHomeworkConfiguration : IEntityTypeConfiguration<AccountHomework>
    {
        public void Configure(EntityTypeBuilder<AccountHomework> builder)
        {
            builder.ToTable("AccountHomeworks").HasKey(a => a.Id);
            builder.Property(a => a.Id).HasColumnName("Id").IsRequired();
            builder.Property(a => a.HomeworkId).HasColumnName("HomeworkId").IsRequired();
            builder.Property(a => a.AccountId).HasColumnName("AccountId").IsRequired();
            builder.Property(a => a.Status).HasColumnName("Status").IsRequired();
            builder.HasQueryFilter(a => !a.DeletedDate.HasValue);
        }
    }
}