using Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccess.Abstract;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrete.PostgreSQL
{
    public class PgBugDal : IBugDal
    {
        private readonly AppDbContext _context;

        public PgBugDal(AppDbContext context)
        {
            _context = context;
        }


        public List<Bug> ListBugs() //GET ALL
        {
            return _context.Bugs.ToList();
        }

        public Bug ListBug(int id)  //GET 
        {
            return _context.Bugs.Find(id);
        }


        public bool Add(List<Bug> Bugs)  //INSERT
        {
            try
            {
                foreach (Bug bug in Bugs)
                {
                    _context.Bugs.Add(bug);
                    
                }
                _context.SaveChanges();



                return true;
            }
            catch
            {
                return false;
            }

        }
    }
}
