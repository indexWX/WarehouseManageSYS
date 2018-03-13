using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace book.Controllers
{
    public class StockInController : Controller
    {
        // GET: StockIn
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Add()
        {
            return View();
        }
        public ActionResult AddSave()
        {

            Model.T_Stock_In in_stock = new Model.T_Stock_In();
            //获得表头数据
            in_stock.Head = new book.Model.T_Stock_InHead();
            in_stock.Head.Creater = Request.Form["StockName"];
            in_stock.Head.CreateTime = Convert.ToDateTime(Request.Form["StockTime"]);          
            in_stock.Head.ProviderId = Convert.ToInt16(Request.Form["Provider.Id"]);


            //获取详细内容表数据
            in_stock.items = new List<Model.T_Stock_InItems>();
            int i = 0;
            while (Request.Form["items[" + i + "].item.BookName"] != null)
            {
                Model.T_Stock_InItems item = new Model.T_Stock_InItems();
                item.BookId = Convert.ToInt32(Request.Form["items[" + i + "].item.Id"].Replace(",", ""));
                item.Discount = Convert.ToDecimal(Request.Form["items[" + i + "].item.Discount"]);
                item.Amount = Convert.ToInt32(Request.Form["items[" + i + "].item.Amount"]);

                in_stock.items.Add(item);
                i++;
            }

            BLL.T_Stock_InBLL bllIn = new BLL.T_Stock_InBLL();
            bool result = bllIn.Add(in_stock);
            if (result)
            {
                Response.Write("{\"statusCode\":\"200\",\"message\":\"操作成功\",\"navTabId\":\"bookmanager\",\"rel\":\"bookmanager\",\"callbackType\":\"closeCurrent\",\"forwardUrl\":\"\"}");

            }
            else
            {
                Response.Write("{\"statusCode\":\"300\",\"message\":\"操作失败\",\"navTabId\":\"bookmanager\",\"rel\":\"bookmanager\",\"callbackType\":\"closeCurrent\",\"forwardUrl\":\"\"}");
            }
            return null;
        }

    }
}