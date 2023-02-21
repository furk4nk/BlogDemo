﻿using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Concrete
{
    public class Context : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=FN-515AN_FURKAN;database=DbBlog;Integrated Security=True;");
        }
        public DbSet<About> abouts { get; set; }
        public DbSet<Blog> blogs { get; set; }
        public DbSet<Category> categories { get; set; }
        public DbSet<Comment> comments { get; set; }
        public DbSet<Contact> contacts { get; set; }
        public DbSet<Writer> writers { get; set; }
        public DbSet<Country> countries { get; set; }
        public DbSet<City> cities { get; set; }
        public DbSet<District> districts { get; set; }
        public DbSet<NewsLetter> newsLetters { get; set; }
        public DbSet<BlogRayting> blogRaytings { get; set; }
    }
}
