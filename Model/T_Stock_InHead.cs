using System;
namespace book.Model
{
    /// <summary>
    /// T_Stock_InHead:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class T_Stock_InHead
    {
        public T_Stock_InHead()
        { }
        #region Model
        private int _id;
        private DateTime? _createtime;
        private int? _providerid;
        private string _creater;
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
        public DateTime? CreateTime
        {
            set { _createtime = value; }
            get { return _createtime; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? ProviderId
        {
            set { _providerid = value; }
            get { return _providerid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Creater
        {
            set { _creater = value; }
            get { return _creater; }
        }
        #endregion Model

    }
}

