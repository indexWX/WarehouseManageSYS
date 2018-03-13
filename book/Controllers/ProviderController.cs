using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace book.Controllers
{
    public class ProviderController : Controller
    {
        // GET: Provider
        public ActionResult index(string keyword, int pageNum = 1)
        {
            string where = "";
            if (keyword == "")
            {
                where = "1 = 1";

            }
            else
            {
                where = " name like '%" + keyword + "%'";
            }
            int CurrentPageIndex = pageNum;
            book.DAL.T_Base_Provider dal = new DAL.T_Base_Provider();
            //获取数据

            int PageSize = Convert.ToInt32(System.Configuration.ConfigurationManager.AppSettings["PageSize"]);
            int RecordCount = dal.GetRecordCount(where);
            int startIndex = (CurrentPageIndex - 1) * PageSize + 1;
            int endIndex = CurrentPageIndex * PageSize;
            List<book.Model.T_Base_Provider> lst = dal.GetModelListByPage(where, " id desc", startIndex, endIndex);
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
        public ActionResult Addsave(book.Model.T_Base_Provider book)
        {
            DAL.T_Base_Provider dal = new DAL.T_Base_Provider();
            int result = dal.Add(book);
            string tmp;
            if (result>0)
            {
                tmp = "{ \"statusCode\":\"200\", \"message\":\"插入成功\", \"navTabId\":\"booklist\", \"rel\":\"booklist\",\"callbackType\":\"closeCurrent\",\"forwardUrl\":\"\"}";
                return Content(tmp);
            }
            else
            {
                tmp = "{ \"statusCode\":\"300\", \"message\":\"插入失败\", \"navTabId\":\"booklist\", \"rel\":\"booklist\",\"callbackType\":\"closeCurrent\",\"forwardUrl\":\"\"}";
            }
            return Content(tmp);
        }

        public ActionResult Delete(string ids)
        {
            DAL.T_Base_Provider dal = new DAL.T_Base_Provider();
            bool result = dal.DeleteList(ids);
            string tmp;
            if (result)
            {
                tmp = "{ \"statusCode\":\"200\", \"message\":\"删除成功\", \"navTabId\":\"booklist\", \"rel\":\"booklist\",\"callbackType\":\"\",\"forwardUrl\":\"\"}";
                return Content(tmp);
            }
            else
            {
                tmp = "{ \"statusCode\":\"300\", \"message\":\"删除失败\", \"navTabId\":\"booklist\", \"rel\":\"booklist\",\"callbackType\":\"\",\"forwardUrl\":\"\"}";
            }
            return Content(tmp);
        }

        public ActionResult Update(int id)
        {
            DAL.T_Base_Provider dal = new DAL.T_Base_Provider();
            book.Model.T_Base_Provider book = new Model.T_Base_Provider();
            book = dal.GetModel(id);
            ViewBag.book = book;
            if (book == null)
            {
                return Content("资料不存在");
            }
            return View();
        }
        public ActionResult UpdateSave(book.Model.T_Base_Provider book)
        {
            DAL.T_Base_Provider dal = new DAL.T_Base_Provider();
            bool result = dal.Update(book);
            string tmp;
            if (result)
            {
                tmp = "{ \"statusCode\":\"200\", \"message\":\"修改成功\", \"navTabId\":\"booklist\", \"rel\":\"booklist\",\"callbackType\":\"closeCurrent\",\"forwardUrl\":\"\"}";
                return Content(tmp);
            }
            else
            {
                tmp = "{ \"statusCode\":\"300\", \"message\":\"修改失败\", \"navTabId\":\"booklist\", \"rel\":\"booklist\",\"callbackType\":\"closeCurrent\",\"forwardUrl\":\"\"}";
            }
            return Content(tmp);
        }
        public ActionResult GetAllProvider()
        {
            DAL.T_Base_Provider dal = new DAL.T_Base_Provider();
            List<Model.T_Base_Provider> lst = dal.GetModelList("1=1");
            String result = "[";
            foreach (var item in lst)
            {
                result += "{";
                result += "\"Name\":\"" + item.Name + "\",";
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