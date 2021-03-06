﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Planner
{
    [DbConfigurationType(typeof(MySql.Data.Entity.MySqlEFConfiguration))]
    public class PlannerContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public PlannerContext() : base("MyContext")
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<System.Data.Entity.ModelConfiguration.Conventions.PluralizingTableNameConvention>();
            base.OnModelCreating(modelBuilder);
        }

        public System.Data.Entity.DbSet<Planner.Models.Meeting> Meetings { get; set; }

        public System.Data.Entity.DbSet<Planner.Models.Event> Events { get; set; }

        public System.Data.Entity.DbSet<Planner.Models.Expense> Expenses { get; set; }

        public System.Data.Entity.DbSet<Planner.Models.Guest> Guests { get; set; }

        public System.Data.Entity.DbSet<Planner.Models.User> Users { get; set; }

        public System.Data.Entity.DbSet<Planner.Models.Status> Status { get; set; }

        public System.Data.Entity.DbSet<Planner.Models.Vote> Vote { get; set; }

        public System.Data.Entity.DbSet<Planner.Models.Voting> Voting { get; set; }

        public System.Data.Entity.DbSet<Planner.Models.VotingAnswer> VotingAnswer { get; set; }
    }
}
