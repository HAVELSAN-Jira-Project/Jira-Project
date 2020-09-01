using Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccess.Abstract;
using DataAccess.ViewModels;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ValueGeneration;

namespace DataAccess.Concrete.PostgreSQL
{
    public class PgBugDal : IBugDal
    {
        private readonly AppDbContext _context;


        public PgBugDal(AppDbContext context)
        {
            _context = context;

        }



        public JiraIssue ListBug(int id) //GET 
        {
            return _context.JiraIssues.Find(id);
        }



        public List<ListIssuesViewModel> ListBugsWithRebound()
        {
            List<ListIssuesViewModel> listBugs = new List<ListIssuesViewModel>();


            foreach (JiraIssue bug in _context.JiraIssues.ToList())      //TÜM BUGLARIN HEPSİNİN REBOUNDUNU BUL
            {
                if (bug.Type == "Bug")
                {
                    listBugs.Add(new ListIssuesViewModel  //HER BUGU TEKER TEKER MODELE SETLE
                    {
                        IssueID = bug.IssueID,
                        Summary = bug.Summary,
                        Created = bug.Created,
                        Creator = bug.Creator,
                        Status = bug.Status,
                        Severity = bug.Severity,

                        //!!!!!
                        Rebound = GetRebound(bug.IssueID)
                    });
                }
               
            }
            return listBugs;   //MODELİ DÖNDÜR
        }  //LİST ALL BUGS



        public List<ListIssuesViewModel> ListBugsWithReboundFilterbyDate(DateTime targetTime)
        {
            List<ListIssuesViewModel> listBugs = new List<ListIssuesViewModel>();

            foreach (JiraIssue bug in _context.JiraIssues.ToList())      //TEK TEK HEPSİNİN REBOUNDUNU BUL
            {
                if (bug.Type == "Bug" && DateTime.Compare(bug.Created, targetTime) > 0)   //CREATED, GELEN TARİHTEN İLERİ İSE
                {
                    listBugs.Add(new ListIssuesViewModel  //SADECE TARİH ŞARTINI SAĞLAYAN BUGLARI SETLE
                    {
                        IssueID = bug.IssueID,
                        Summary = bug.Summary,
                        Created = bug.Created,
                        Creator = bug.Creator,
                        Status = bug.Status,
                        Severity = bug.Severity,


                        Rebound = GetRebound(bug.IssueID)
                    });
                }

            }
            return listBugs;   //MODELİ DÖNDÜR
        }  //GET BUGS BY DATE



        public List<ListIssuesViewModel> ListBugsWithReboundFilterbySeverity(int severity)
        {
            List<ListIssuesViewModel> listBugs = new List<ListIssuesViewModel>();


            foreach (JiraIssue bug in _context.JiraIssues.ToList())
            {
                if (bug.Type == "Bug" && bug.Severity == severity)
                {
                    listBugs.Add(new ListIssuesViewModel  //SADECE SEVERİTY EŞLEŞEN KAYITLAR
                    {
                        IssueID = bug.IssueID,
                        Summary = bug.Summary,
                        Created = bug.Created,
                        Creator = bug.Creator,
                        Status = bug.Status,
                        Severity = bug.Severity,


                        Rebound = GetRebound(bug.IssueID)
                    });
                }

            }
            return listBugs;   //MODELİ DÖNDÜR
        }  //GET BUGS BY SEVERITY



        private int GetRebound(string bugID)
        {
            int reboundCount = _context.Logs.Where(x => x.IssueID == bugID && x.FromString == "Done" && x.toString == "In Progress").Count();
            return reboundCount;
        }  //GET REBOUNDS


        public List<ListIssuesViewModel> ListSearchedBugs(string text)
        {
            List<ListIssuesViewModel> listBugs = new List<ListIssuesViewModel>();


            foreach (JiraIssue bug in _context.JiraIssues.ToList())
            {
                if (bug.Type == "Bug" && bug.Summary.ToLower().Contains(text.ToLower()))   //SUMMARY, GELEN STRİNGİ İÇERİYORSA LİSTEYE EKLE
                {
                    listBugs.Add(new ListIssuesViewModel
                    {
                        IssueID = bug.IssueID,
                        Summary = bug.Summary,
                        Created = bug.Created,
                        Creator = bug.Creator,
                        Status = bug.Status,
                        Severity = bug.Severity,

                        //!!!!!
                        Rebound = GetRebound(bug.IssueID)
                    });
                }

            }

            return listBugs;
        }   //GET SEARCHED BUGS
    }
}
