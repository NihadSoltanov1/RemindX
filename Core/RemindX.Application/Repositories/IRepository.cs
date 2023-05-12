﻿using Microsoft.EntityFrameworkCore;
using RemindX.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RemindX.Application.Repositories
{
    public interface IRepository<T> where T:BaseEntity
    {
        public DbSet<T> Table { get; }
    }
}