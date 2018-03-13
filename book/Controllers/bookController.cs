using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace book.Controllers
{
    public class bookController : Controller
    {
        // GET: book
        public ActionResult Index()
        {          
            return View();
        }

        public ActionResult BuyerList(string keyword, int pageNum = 1)
        {          
            string where = "";
            if (keyword == "")
            {
                where = "1 = 1";

            }
            else
            {
                where = " bookname like '%" + keyword + "%'";
            }
            book.DAL.DalT_Base_Book dal = new DAL.DalT_Base_Book();
            //获取数据

            int CurrentPageIndex = pageNum;
            int PageSize = Convert.ToInt32(System.Configuration.ConfigurationManager.AppSettings["PageSize"]);
            int RecordCount = dal.GetRecord(where);
            List<book.Model.T_Base_Book> lst = dal.GetListByPageIndex(CurrentPageIndex, PageSize, where);
            //展示数据
            ViewBag.CurrentPageIndex = CurrentPageIndex;
            ViewBag.PageSize = PageSize;
            ViewBag.RecordCount = RecordCount;
            ViewBag.lst = lst;
            return View();
        }

        public ActionResult Add()
        {
            return View();
        }
        public ActionResult Addsave(book.Model.T_Base_Book book)
        {
            DAL.DalT_Base_Book dal = new DAL.DalT_Base_Book();
            bool result = dal.add(book);
            string tmp;
            if(result)
            {
                tmp = "{ \"statusCode\":\"200\", \"message\":\"插入成功\", \"navTabId\":\"buyer\", \"rel\":\"buyer\",\"callbackType\":\"closeCurrent\",\"forwardUrl\":\"\"}";
                return Content(tmp);
            }
            else
            {
                tmp = "{ \"statusCode\":\"300\", \"message\":\"插入失败\", \"navTabId\":\"buyer\", \"rel\":\"buyer\",\"callbackType\":\"closeCurrent\",\"forwardUrl\":\"\"}";
            }
            return Content(tmp);
        }

        public ActionResult Delete(string ids)
        {
            DAL.DalT_Base_Book dal = new DAL.DalT_Base_Book();
            bool result = dal.delete(ids);
            string tmp;
            if (result)
            {
                tmp = "{ \"statusCode\":\"200\", \"message\":\"删除成功\", \"navTabId\":\"buyer\", \"rel\":\"buyer\",\"callbackType\":\"\",\"forwardUrl\":\"\"}";
                return Content(tmp);
            }
            else
            {
                tmp = "{ \"statusCode\":\"300\", \"message\":\"删除失败\", \"navTabId\":\"buyer\", \"rel\":\"buyer\",\"callbackType\":\"\",\"forwardUrl\":\"\"}";
            }
            return Content(tmp);
        }

        public ActionResult Update(int id)
        {
            DAL.DalT_Base_Book dal = new DAL.DalT_Base_Book();
            book.Model.T_Base_Book book = new Model.T_Base_Book();
            book = dal.getModelById(id);
            ViewBag.book = book;
            return View();
        }
        public ActionResult UpdateSave(book.Model.T_Base_Book book)
        {
            DAL.DalT_Base_Book dal = new DAL.DalT_Base_Book();
            bool result = dal.Update(book);
            string tmp;
            if (result)
            {
                tmp = "{ \"statusCode\":\"200\", \"message\":\"修改成功\", \"navTabId\":\"buyer\", \"rel\":\"buyer\",\"callbackType\":\"closeCurrent\",\"forwardUrl\":\"\"}";
                return Content(tmp);
            }
            else
            {
                tmp = "{ \"statusCode\":\"300\", \"message\":\"修改失败\", \"navTabId\":\"buyer\", \"rel\":\"buyer\",\"callbackType\":\"closeCurrent\",\"forwardUrl\":\"\"}";
            }
            return Content(tmp);
        }

        public ActionResult GetAll()
        {
            DAL.DalT_Base_Book dal = new DAL.DalT_Base_Book();
            List<Model.T_Base_Book> lst = dal.GetList();
            String result = "[";
            foreach (var item in lst)
            {
                result += "{";
                result += "\"BookName\":\"" + item.BookName + "\",";
                result += "\"Price\":\"" + item.Price + "\",";
                result += "\"Author\":\"" + item.Author + "\",";
                result += "\"Version\":\"" + item.Version + "\",";
                result += "\"Id\":\"" + item.Id + "\"";

                result += "},";
            }
            if (lst.Count >= 1)
            {
                result = result.Substring(0, result.Length - 1);
            }
            result += "]";

            return Content(result);
        }
    }
}