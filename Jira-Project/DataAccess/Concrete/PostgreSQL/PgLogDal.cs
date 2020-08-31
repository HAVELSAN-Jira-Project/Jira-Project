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


        public List<ListLogsViewModel> ListLogsbyID(string id)        //GETLOGS BY ID
        {
            var result = (from logs in _context.Logs
                          where logs.BugID == id
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


        public List<ListLogsViewModel> ListLogsFilterbyStatus(int statusID)
        {

            //SET DICTIONARIES
            Dictionary<int, string> fromString = new Dictionary<int, string>()
            {
                {1 , "To Do"},
                {2 , "To Do"},
                {3 , "In Progress"},
                {4 , "In Progress"},
                {5 , "Done"},
                {6 , "Done"}
            };

            Dictionary<int, string> toString = new Dictionary<int, string>()
            {
                {1 , "In Progress"},
                {2 , "Done"},
                {3 , "To Do"},
                {4 , "Done"},
                {5 , "To Do"},
                {6 , "In Progress"}
            };


                var result = (from logs in _context.Logs
                where logs.FromString == fromString[statusID] && logs.toString == toString[statusID]
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
        }   //FILTER BY STATUS

    }
}
