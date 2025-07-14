using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using _07_entity_framework_web_app_mvc.Models;

    public class DbContext : Microsoft.EntityFrameworkCore.DbContext
    {
        public DbContext (DbContextOptions<DbContext> options)
            : base(options)
        {
        }

        public DbSet<_07_entity_framework_web_app_mvc.Models.Student> Student { get; set; } = default!;

public DbSet<_07_entity_framework_web_app_mvc.Models.Grade> Grade { get; set; } = default!;
    }
