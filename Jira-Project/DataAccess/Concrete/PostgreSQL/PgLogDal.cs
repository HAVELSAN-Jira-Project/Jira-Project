using Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccess.Abstract;
using DataAccess.ViewModels;
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


        public List<ListLogsViewModel> ListLogs()       //GET ALL
        {
            var result = (from logs in _context.Logs
                          select new ListLogsViewModel
                            {
                                BugID = logs.BugID,
                                Author = logs.Author,
                                Created = logs.Created,
                                Field = logs.Field,
                                FromString = logs.FromString,
                                toString = logs.toString
                            }).ToList();

            return result;
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


        public List<ListLogsViewModel> ListLogsFiltebyDate(DateTime limitDate)   //FILTER BY DATE
        {
            var result = (from logs in _context.Logs
                            where DateTime.Compare(logs.Created, limitDate) > 0
                            select new ListLogsViewModel
                            {
                                BugID = logs.BugID,
                                Author = logs.Author,
                                Created = logs.Created,
                                Field = logs.Field,
                                FromString = logs.FromString,
                                toString = logs.toString
                            }).ToList();

            return result;
        }

    }
}
