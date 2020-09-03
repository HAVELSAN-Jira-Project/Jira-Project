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



        //TÜM LOGLARI LİSTELE
        public List<ListLogsViewModel> ListLogs()       
        {
            var result = (from logs in _context.Logs
                          select new ListLogsViewModel
                            {
                                BugID = logs.IssueID,
                                Type = logs.LogType,
                                Author = logs.Author,
                                Created = logs.Created,
                                Field = logs.Field,
                                FromString = logs.FromString,
                                toString = logs.toString
                            }).ToList();

            return result;
        }




        //İSSUE TİPİ UYUŞAN TÜM LOGLARI LİSTELE   (METHOD OVERLOAD)
        public List<ListLogsViewModel> ListLogs(int id)
        {
            Dictionary<int, string> IssueType = new Dictionary<int, string>()
            {
                {1 , "Bug"},
                {2 , "Task"},
                {3 , "Story"},
                {4 , "Epic"},

            };


            var result = (from logs in _context.Logs
                where logs.LogType== IssueType[id]
                select new ListLogsViewModel      //ISSUE TİPİ UYUŞAN LOGLARI EKLE
                {
                    BugID = logs.IssueID,
                    Type = logs.LogType,
                    Author = logs.Author,
                    Created = logs.Created,
                    Field = logs.Field,
                    FromString = logs.FromString,
                    toString = logs.toString
                }).ToList();

            return result;
        }




        //TARİH ŞARTINI SAĞLAYAN LOGLARI LİSTELE
        public List<ListLogsViewModel> ListLogsFiltebyDate(DateTime limitDate)   
        {
            var result = (from logs in _context.Logs
                where DateTime.Compare(logs.Created, limitDate) > 0
                select new ListLogsViewModel   //TARİH ŞARTINI SAĞLAYANLARI EKLE
                {
                    BugID = logs.IssueID,
                    Author = logs.Author,
                    Type = logs.LogType,
                    Created = logs.Created,
                    Field = logs.Field,
                    FromString = logs.FromString,
                    toString = logs.toString
                }).ToList();

            return result;
        }





        //İSSUE TİPİNİ VE TARİH ŞARTINI SAĞLAYAN LOGLARI LİSTELE (METHOT OVERLOAD)
        public List<ListLogsViewModel> ListLogsFiltebyDate(DateTime limitDate,int id)
        {
            Dictionary<int, string> IssueType = new Dictionary<int, string>()
            {
                {1 , "Bug"},
                {2 , "Task"},
                {3 , "Story"},
                {4 , "Epic"},

            };

            var result = (from logs in _context.Logs
                where DateTime.Compare(logs.Created, limitDate) > 0
                && logs.LogType==IssueType[id]

                select new ListLogsViewModel   //TARİH ŞARTINI SAĞLAYAN VE ISSUE TİPİ UYAN KAYITLARI EKLE
                {
                    BugID = logs.IssueID,
                    Author = logs.Author,
                    Type = logs.LogType,
                    Created = logs.Created,
                    Field = logs.Field,
                    FromString = logs.FromString,
                    toString = logs.toString
                }).ToList();

            return result;
        }




        //STATÜ DURUMLARINA GÖRE LİSTELE
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
                    BugID = logs.IssueID,
                    Author = logs.Author,
                    Type = logs.LogType,
                    Created = logs.Created,
                    Field = logs.Field,
                    FromString = logs.FromString,
                    toString = logs.toString

                }).ToList();

            return result;
        }






        //STATÜ DURUMLARINA GÖRE LİSTELE  (METHOT OVERLOAD)
        public List<ListLogsViewModel> ListLogsFilterbyStatus(int statusID,int id)
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

            Dictionary<int, string> IssueType = new Dictionary<int, string>()
            {
                {1 , "Bug"},
                {2 , "Task"},
                {3 , "Story"},
                {4 , "Epic"},

            };


            var result = (from logs in _context.Logs
                where logs.FromString == fromString[statusID] && logs.toString == toString[statusID]
                && logs.LogType==IssueType[id]

                select new ListLogsViewModel  //ISSUE TİPİ VE STATÜ DURUMLARI SAĞLAYAN KAYITLARI EKLE
                {
                    BugID = logs.IssueID,
                    Author = logs.Author,
                    Type = logs.LogType,
                    Created = logs.Created,
                    Field = logs.Field,
                    FromString = logs.FromString,
                    toString = logs.toString

                }).ToList();

            return result;
        }






        //İDYE GÖRE LOGLARI LİSTELE
        public List<ListLogsViewModel> ListLogsbyID(string id)        
        {
            var result = (from logs in _context.Logs
                where logs.IssueID == id
                select new ListLogsViewModel
                {
                    BugID = logs.IssueID,
                    Author = logs.Author,
                    Type = logs.LogType,
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


       


        

    }
}
