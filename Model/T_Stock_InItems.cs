using System;
namespace book.Model
{
    /// <summary>
    /// T_Stock_InItems:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class T_Stock_InItems
    {
        public T_Stock_InItems()
        { }
        #region Model
        private int _id;
        private int? _bookid;
        private int? _amount;
        private decimal? _discount;
        private int? _headid;
        /// <summary>
        /// 
        /// </summary>
        public int Id
        {
            set { _id = value; }
            get { return _id; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? BookId
        {
            set { _bookid = value; }
            get { return _bookid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? Amount
        {
            set { _amount = value; }
            get { return _amount; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? Discount
        {
            set { _discount = value; }
            get { return _discount; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? HeadId
        {
            set { _headid = value; }
            get { return _headid; }
        }
        #endregion Model

    }
}

