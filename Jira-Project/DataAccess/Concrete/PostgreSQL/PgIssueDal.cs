using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using DataAccess.Abstract;
using DataAccess.ViewModels;
using Entities.Entities;

namespace DataAccess.Concrete.PostgreSQL
{
    public class PgIssueDal : IIssueDal
    {
        private readonly AppDbContext _context;


        public PgIssueDal(AppDbContext context)
        {
            _context = context;
        }



        
        //TÜM ISSUE'LARI LİSTELE
        public List<ListIssuesViewModel> ListIssuesWithRebound()
        {
            List<ListIssuesViewModel> listBugs = new List<ListIssuesViewModel>();


            foreach (JiraIssue issue in _context.JiraIssues.ToList())      //TÜM BUGLARIN HEPSİNİN REBOUNDUNU BUL
            {

                listBugs.Add(new ListIssuesViewModel  //HER BUGU TEKER TEKER MODELE SETLE
                    {
                        IssueID = issue.IssueID,
                        Summary = issue.Summary,
                        Type =  issue.Type,
                        Created = issue.Created,
                        Creator = issue.Creator,
                        Status = issue.Status,
                        Severity = issue.Severity,

                        //!!!!!
                        Rebound = GetRebound(issue.IssueID)
                    });
                

            }
            return listBugs;   //MODELİ DÖNDÜR
        }




        //VERİLEN ISSUE TİPİNE GÖRE LİSTELE (METHOD OVERLOAD)
        public List<ListIssuesViewModel> ListIssuesWithRebound(int id)  
        {
            Dictionary<int,string> IssueType = new Dictionary<int, string>()
            {
                {1 , "Bug"},
                {2 , "Task"},
                {3 , "Story"},
                {4 , "Epic"},

            };  

            List<ListIssuesViewModel> listBugs = new List<ListIssuesViewModel>();


            foreach (JiraIssue issue in _context.JiraIssues.ToList())      
            {
                if (issue.Type == IssueType[id])   
                {
                    listBugs.Add(new ListIssuesViewModel    //ISSUE TYPE, GELEN İD İLE UYUYORSA LİSTEYE EKLE
                    {
                        IssueID = issue.IssueID,
                        Summary = issue.Summary,
                        Type = issue.Type,
                        Created = issue.Created,
                        Creator = issue.Creator,
                        Status = issue.Status,
                        Severity = issue.Severity,

                        //!!!!!
                        Rebound = GetRebound(issue.IssueID)
                    });
                }
                


            }
            return listBugs;   //MODELİ DÖNDÜR
        }




        //TÜM ISSUE'LARI TARİHE GÖRE FİLTRELE
        public List<ListIssuesViewModel> ListIssuesFilterbyDate(DateTime targetTime)
        {
            List<ListIssuesViewModel> listBugs = new List<ListIssuesViewModel>();

            foreach (JiraIssue issue in _context.JiraIssues.ToList())      //TEK TEK HEPSİNİN REBOUNDUNU BUL
            {
                if (DateTime.Compare(issue.Created, targetTime) > 0)   
                {
                    listBugs.Add(new ListIssuesViewModel  //SADECE TARİH ŞARTINI SAĞLAYAN ISSUELARI SETLE
                    {
                        IssueID = issue.IssueID,
                        Summary = issue.Summary,
                        Type = issue.Type,
                        Created = issue.Created,
                        Creator = issue.Creator,
                        Status = issue.Status,
                        Severity = issue.Severity,


                        Rebound = GetRebound(issue.IssueID)
                    });
                }

            }
            return listBugs;   //MODELİ DÖNDÜR
        }




        //VERİLEN ISSUE TİPİNE VE TARİHE GÖRE FİLTRELE (METHOD OVERLOADİNG)
        public List<ListIssuesViewModel> ListIssuesFilterbyDate(DateTime targetTime,int id)
        {
            Dictionary<int, string> IssueType = new Dictionary<int, string>()
            {
                {1 , "Bug"},
                {2 , "Task"},
                {3 , "Story"},
                {4 , "Epic"},

            };


            List<ListIssuesViewModel> listIssues = new List<ListIssuesViewModel>();

            foreach (JiraIssue issue in _context.JiraIssues.ToList())      
            {
                if (issue.Type==IssueType[id] && DateTime.Compare(issue.Created, targetTime) > 0)
                {
                    listIssues.Add(new ListIssuesViewModel  //TARİH VE ISSUE TİPİNİ SAĞLAYAN ISSUELARI SETLE
                    {
                        IssueID = issue.IssueID,
                        Summary = issue.Summary,
                        Type = issue.Type,
                        Created = issue.Created,
                        Creator = issue.Creator,
                        Status = issue.Status,
                        Severity = issue.Severity,


                        Rebound = GetRebound(issue.IssueID)
                    });
                }

            }
            return listIssues;   //MODELİ DÖNDÜR
        }




        //TÜM ISSUE'LARI SEVERİTY'YE GÖRE FİLTRELE
        public List<ListIssuesViewModel> ListIssuesFilterbySeverity(int severity)
        {
            List<ListIssuesViewModel> listIssue = new List<ListIssuesViewModel>();


            foreach (JiraIssue issue in _context.JiraIssues.ToList())
            {
                if (issue.Severity == severity)
                {
                    listIssue.Add(new ListIssuesViewModel  //SEVERİTY VE ISSUE TİPİNİ SAĞLAYAN ISSUELARI SETLE
                    {
                        IssueID = issue.IssueID,
                        Type = issue.Type,
                        Summary = issue.Summary,
                        Created = issue.Created,
                        Creator = issue.Creator,
                        Status = issue.Status,
                        Severity = issue.Severity,


                        Rebound = GetRebound(issue.IssueID)
                    });
                }

            }
            return listIssue;   //MODELİ DÖNDÜR
        }




        //VERİLEN İSSUE TİPİNE VE SEVERİTYE GÖRE FİLTRELE (METHOD OVERLOAD)
        public List<ListIssuesViewModel> ListIssuesFilterbySeverity(int severity,int id)
        {

            Dictionary<int, string> IssueType = new Dictionary<int, string>()
            {
                {1 , "Bug"},
                {2 , "Task"},
                {3 , "Story"},
                {4 , "Epic"},

            };


            List<ListIssuesViewModel> listIssue = new List<ListIssuesViewModel>();

            foreach (JiraIssue issue in _context.JiraIssues.ToList())
            {
                if (issue.Type==IssueType[id] && issue.Severity == severity)
                {
                    listIssue.Add(new ListIssuesViewModel  //
                    {
                        IssueID = issue.IssueID,
                        Type = issue.Type,
                        Summary = issue.Summary,
                        Created = issue.Created,
                        Creator = issue.Creator,
                        Status = issue.Status,
                        Severity = issue.Severity,


                        Rebound = GetRebound(issue.IssueID)
                    });
                }

            }
            return listIssue;   //MODELİ DÖNDÜR
        }




        //SUMMARY İÇERİĞİNE GÖRE FİLTRELE
        public List<ListIssuesViewModel> ListSearchedIssues(string text)
        {
            List<ListIssuesViewModel> listIssues = new List<ListIssuesViewModel>();


            foreach (JiraIssue issue in _context.JiraIssues.ToList())
            {
                if (issue.Summary.ToLower().Contains(text.ToLower()))   //SUMMARY, GELEN STRİNGİ İÇERİYORSA LİSTEYE EKLE
                {
                    listIssues.Add(new ListIssuesViewModel
                    {
                        IssueID = issue.IssueID,
                        Summary = issue.Summary,
                        Type = issue.Type,
                        Created = issue.Created,
                        Creator = issue.Creator,
                        Status = issue.Status,
                        Severity = issue.Severity,

                        //!!!!!
                        Rebound = GetRebound(issue.IssueID)
                    });
                }

            }

            return listIssues;
        }





        //SUMMARY İÇERİĞİNE GÖRE FİLTRELE
        public List<ListIssuesViewModel> ListSearchedIssues(string text,int id)
        {
            Dictionary<int, string> IssueType = new Dictionary<int, string>()
            {
                {1 , "Bug"},
                {2 , "Task"},
                {3 , "Story"},
                {4 , "Epic"},

            };


            List<ListIssuesViewModel> listIssues = new List<ListIssuesViewModel>();

            foreach (JiraIssue issue in _context.JiraIssues.ToList())
            {
                if (issue.Type==IssueType[id] && issue.Summary.ToLower().Contains(text.ToLower()))   
                {
                    listIssues.Add(new ListIssuesViewModel //ISSUE TYPE VE SUMMARY EŞLEŞİYORSA LİSTEYE EKLE
                    {
                        IssueID = issue.IssueID,
                        Summary = issue.Summary,
                        Type = issue.Type,
                        Created = issue.Created,
                        Creator = issue.Creator,
                        Status = issue.Status,
                        Severity = issue.Severity,

                        //!!!!!
                        Rebound = GetRebound(issue.IssueID)
                    });
                }

            }

            return listIssues;
        }






        public bool Add(List<JiraIssue> Issues) //INSERT
        {
            try
            {
                foreach (JiraIssue issue in Issues)
                {
                    _context.JiraIssues.Add(issue);

                }

                _context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }

        }



        public void ClearIssues() //TRUNCATE
        {

            _context.RemoveRange(_context.JiraIssues);
            _context.SaveChanges();

            //_context.Database.ExecuteSqlRaw("TRUNCATE TABLE Issues");

        }



        private int GetRebound(string IssueID)
        {
            int reboundCount = _context.Logs.Where(x => x.IssueID == IssueID && x.FromString == "Done" && x.toString == "In Progress").Count();
            return reboundCount;
        }   //REBOUND HESAPLA
    }
}
