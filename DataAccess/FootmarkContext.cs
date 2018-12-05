/******************************************************************
** auth: wei.huazhong
** date: 12/3/2018 3:56:48 PM
** desc:
******************************************************************/

using Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class FootmarkContext : DbContext
    {
        public FootmarkContext() : base("FootmarkDB")
        { }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }

        public DbSet<Log> Log { get; set; }
        public DbSet<Footmark> Footmark { get; set; }
        public DbSet<Project> Project { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<UserProject> UserProject { get; set; }
    }
}
