using Day5_DemoWCF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Windows.Forms;

namespace Day5_DemoWCF
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IService1
    {
        private readonly DatabaseContext db = new DatabaseContext();

        public Service1() { }

        public News GetNews(int id)
        {
            var newsFound = db.News.SingleOrDefault(x => x.Id == id);
            if (newsFound == null)
            {
                return null;
            }
            return newsFound;
        }

        public List<News> GetNewsList()
        {
            return db.News.ToList();
        }

        public bool PostNews(News news)
        {
            db.News.Add(news);
            var result = db.SaveChanges();
            if (result == 1)
            {
                return true;
            }
            return false;
        }
    }
}
