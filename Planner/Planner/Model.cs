namespace Planner
{
    using Planner.Models;
    using System;
    using System.Data.Entity;
    using System.Diagnostics;
    using System.Linq;

    [DbConfigurationType(typeof(MySql.Data.Entity.MySqlEFConfiguration))]
    public class Model : DbContext
    {
        public Model()
            : base("MyContext")            
        {            
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<System.Data.Entity.ModelConfiguration.Conventions.PluralizingTableNameConvention>();
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Event> Events { get; set; }
        public DbSet<Meeting> Meetings { get; set; }
    } 
}