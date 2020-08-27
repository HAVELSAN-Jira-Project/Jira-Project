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


        private List<Bug> ListBugs() //GET ALL
        {
            return _context.Bugs.ToList();
        }


        public Bug ListBug(int id) //GET 
        {
            return _context.Bugs.Find(id);
        }


        public bool Add(List<Bug> Bugs) //INSERT
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


        public void ClearBugs() //TRUNCATE
        {

            _context.RemoveRange(_context.Bugs);
            _context.SaveChanges();

            //_context.Database.ExecuteSqlRaw("TRUNCATE TABLE Bugs");

        }


        public List<ListBugsViewModel> ListBugsWithRebound()
        {
            List<ListBugsViewModel> listBugs = new List<ListBugsViewModel>();

            List<Bug> allBugs = ListBugs();   //BUGLARI ÇEK
           
            foreach (Bug bug in allBugs)      //TEK TEK HEPSİNİN REBOUNDUNU BUL
            {
                listBugs.Add(new ListBugsViewModel  //HER BUGU TEKER TEKER MODELE SETLE
                {
                    BugID = bug.BugID,
                    Summary = bug.Summary,
                    Created = bug.Created,
                    Creator = bug.Creator,
                    Status = bug.Status,
                    Severity = bug.Severity,

                    //!!!!!
                    Rebound = GetRebound(bug.BugID)
                });
            }
            return listBugs;   //MODELİ DÖNDÜR
        }  //LİST ALL BUGS



        public List<ListBugsViewModel> ListBugsWithReboundFilterbyDate(DateTime targetTime)
        {
            List<ListBugsViewModel> listBugs = new List<ListBugsViewModel>();

            List<Bug> allBugs = ListBugs();   //BUGLARI ÇEK

            foreach (Bug bug in allBugs)      //TEK TEK HEPSİNİN REBOUNDUNU BUL
            {
                if (DateTime.Compare(bug.Created,targetTime) > 0)   //CREATED, GELEN TARİHTEN İLERİ İSE
                {
                    listBugs.Add(new ListBugsViewModel  //SADECE TARİH ŞARTINI SAĞLAYAN BUGLARI SETLE
                    {
                        BugID = bug.BugID,
                        Summary = bug.Summary,
                        Created = bug.Created,
                        Creator = bug.Creator,
                        Status = bug.Status,
                        Severity = bug.Severity,

                        
                        Rebound = GetRebound(bug.BugID)
                     });
                }

            }
            return listBugs;   //MODELİ DÖNDÜR
        }  //GET BUGS BY DATE



        public List<ListBugsViewModel> ListBugsWithReboundFilterbySeverity(int severity)
        {
            List<ListBugsViewModel> listBugs = new List<ListBugsViewModel>();

            List<Bug> allBugs = ListBugs();   //BUGLARI ÇEK

            foreach (Bug bug in allBugs)      
            {
                if (bug.Severity == severity)   
                {
                    listBugs.Add(new ListBugsViewModel  //SADECE SEVERİTY EŞLEŞEN KAYITLAR
                    {
                        BugID = bug.BugID,
                        Summary = bug.Summary,
                        Created = bug.Created,
                        Creator = bug.Creator,
                        Status = bug.Status,
                        Severity = bug.Severity,

                        
                        Rebound = GetRebound(bug.BugID)
                    });
                }

            }
            return listBugs;   //MODELİ DÖNDÜR
        }  //GET BUGS BY SEVERITY



        private int GetRebound(string bugID)
        {
            int reboundCount = _context.Logs.Where(x=>x.BugID==bugID && x.FromString=="Done" && x.toString=="In Progress").Count();
            return reboundCount;
        }  //GET REBOUNDS


        public List<ListBugsViewModel> ListSearchedBugs(string text)
        {
            List<ListBugsViewModel> listBugs = new List<ListBugsViewModel>();

            List<Bug> allBugs = ListBugs();   //BUGLARI ÇEK

            foreach (Bug bug in allBugs)      
            {
                if (bug.Summary.ToLower().Contains(text.ToLower()))   //SUMMARY, GELEN STRİNGİ İÇERİYORSA LİSTEYE EKLE
                {
                    listBugs.Add(new ListBugsViewModel  
                    {
                        BugID = bug.BugID,
                        Summary = bug.Summary,
                        Created = bug.Created,
                        Creator = bug.Creator,
                        Status = bug.Status,
                        Severity = bug.Severity,

                        //!!!!!
                        Rebound = GetRebound(bug.BugID)
                    });
                }

            }

            return listBugs;
        }   //GET SEARCHED BUGS
    }
}
