using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Entity;
using ViewModel;

namespace Web.Controllers
{
    public class FootmarkController : BaseController
    {
        // GET: Footmark
        public ActionResult Index()
        {
            List<ProjectVM> projects = null;
            List<FootmarkVM> fvmList = null;

            using (FootmarkContext db = new FootmarkContext())
            {
                projects = (from p in db.Project
                            join up in db.UserProject
                            on p.ID equals up.ProjectID
                            where up.UserID == UserID && p.Validity
                            select new ProjectVM
                            {
                                ID = p.ID,
                                Name = p.Name,
                                CreateTime = p.CreateTime
                            }).ToList();

                foreach (var project in projects)
                {
                    fvmList = db.Footmark.Where(m => m.ProjectID == project.ID).Select(
                       m => new FootmarkVM
                       {
                           ID = m.ID,
                           ProjectID = m.ProjectID,
                           Content = m.Content,
                           MarkTime = m.MarkTime
                       }).OrderByDescending(m => m.MarkTime).Take(3).ToList();

                    project.FootmarkList.AddRange(fvmList);
                }
            }

            return View(projects);
        }

        public ActionResult Details(int id)
        {
            ProjectVM project = null;
            List<FootmarkVM> fvmList = null;

            using (FootmarkContext db = new FootmarkContext())
            {
                project = (from p in db.Project
                           where p.ID == id
                           select new ProjectVM
                           {
                               ID = p.ID,
                               Name = p.Name,
                               CreateTime = p.CreateTime
                           }).FirstOrDefault();

                fvmList = db.Footmark.Where(m => m.ProjectID == id).Select(
                    m => new FootmarkVM
                    {
                        ID = m.ID,
                        ProjectID = m.ProjectID,
                        Content = m.Content,
                        MarkTime = m.MarkTime
                    }).OrderByDescending(m => m.MarkTime).ToList();
            }

            project?.FootmarkList.AddRange(fvmList);
            return View(project);
        }

        public ActionResult AddFootmark(int id)
        {
            ProjectVM project = null;
            using (FootmarkContext db = new FootmarkContext())
            {
                project = (from p in db.Project
                           where p.ID == id
                           select new ProjectVM
                           {
                               ID = p.ID,
                               Name = p.Name,
                               CreateTime = p.CreateTime
                           }).FirstOrDefault();
            }

            return View(project);
        }

        public ActionResult AddProject()
        {
            return View();
        }

        [HttpPost]
        public ActionResult DoAddFootmark()
        {
            string projectID = Request["ID"];
            string content = Request["content"];
            string marktime = Request["marktime"];

            DateTime dt = Convert.ToDateTime(marktime);
            int id = Convert.ToInt32(projectID);

            Footmark footmark = new Footmark
            {
                ProjectID = id,
                Content = content,
                Year = dt.Year,
                Month = dt.Month,
                Day = dt.Day,
                Hour = dt.Hour,
                Minute = dt.Minute,
                MarkTime = dt
            };

            using (FootmarkContext db = new FootmarkContext())
            {
                db.Footmark.Add(footmark);
                db.SaveChanges();
            }

            return RedirectToAction("Details", new { id });
        }

        [HttpPost]
        public ActionResult DoAddProject()
        {
            string name = Request["name"];

            using (var db = new FootmarkContext())
            {
                using (var transaction = db.Database.BeginTransaction())
                {
                    Project p = new Project
                    {
                        Name = name,
                        CreateTime = DateTime.Now,
                        Validity = true
                    };

                    db.Project.Add(p);
                    db.SaveChanges();

                    UserProject up = new UserProject
                    {
                        UserID = UserID,
                        ProjectID = p.ID
                    };
                    db.UserProject.Add(up);
                    db.SaveChanges();
                    transaction.Commit();
                }
            }

            return RedirectToAction("Index");
        }
    }
}