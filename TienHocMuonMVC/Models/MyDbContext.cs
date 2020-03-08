using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace TienHocMuonMVC.Models
{
    public class MyDbContext: DbContext
    {
        public MyDbContext() : base("MyConnectionString")
        {
        }

        public DbSet<DiHocMuon> DiHocMuons { get; set; }
    }
}