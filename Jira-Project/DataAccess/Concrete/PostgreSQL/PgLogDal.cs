using Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccess.Abstract;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace DataAccess.Concrete.PostgreSQL
{
    public class PgLogDal : ILogDal
    {
        private readonly AppDbContext _context;

        public PgLogDal(AppDbContext context)
        {
            _context = context;
        }


        public List<Log> ListLogs()       //GET ALL
        {
            return _context.Logs.ToList();
        }


        public Log ListLog(int id)        //GET
        {
            return _context.Logs.Find(id);
        }


        public bool Add(List<Log> Logs)
        {
            try
            {
                foreach (Log log in Logs)
                {
                    _context.Logs.Add(log);
                    _context.SaveChanges();
                }
                return true;
            }

            catch
            {
                return false;
            }
        }  //INSERT


        public void ClearLogs()
        {
            _context.RemoveRange(_context.Logs);
            _context.SaveChanges();
        }          //TRUNCATE



    }
}
