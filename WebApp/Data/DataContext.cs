﻿using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WebApp.Data.Entities;
using WebApp.Models;

namespace WebApp.Data;
public class DataContext(DbContextOptions<DataContext> options) : IdentityDbContext<AppUser>(options)
{
    public DbSet<ProjectEntity> Projects { get; set; }
}
