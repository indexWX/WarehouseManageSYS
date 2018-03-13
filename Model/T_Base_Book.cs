using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace book.Model
{
    public class T_Base_Book
    {
        /// <summary>
        /// 主键
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// 编码
        /// </summary>
        public string Code { get; set; }
        /// <summary>
        ///  作者
        /// </summary>
        public String Author { get; set; }
        /// <summary>
        /// 价格
        /// </summary>

        public decimal Price { get; set; }
        /// <summary>
        /// 出版年月
        /// </summary>
        public DateTime PYear { get; set; }
        /// <summary>
        /// 书名
        /// </summary>
        public string BookName { get; set; }
        /// <summary>
        /// 版本
        /// </summary>
        public string Version { get; set; }
        /// <summary>
        /// 封面
        /// </summary>
        public string Pic { get; set; }
    }
}
