using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class T_Stock_InBLL
    {
        public bool Add(book.Model.T_Stock_In in_stock)
        {
            book.DAL.T_Stock_InHead dalHead = new book.DAL.T_Stock_InHead();
            in_stock.Head.Id = dalHead.Add(in_stock.Head);  //返回的数据为第几条，所以相当于id

            book.DAL.T_Stock_InItems dalitems = new book.DAL.T_Stock_InItems();
            foreach (book.Model.T_Stock_InItems item in in_stock.items)
            {
                item.HeadId = in_stock.Head.Id;
                dalitems.Add(item);
            }
            return true;
        }
    }

}
