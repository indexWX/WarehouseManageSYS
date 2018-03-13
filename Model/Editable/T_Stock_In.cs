using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace book.Model
{
    public class T_Stock_In
    {
        public T_Stock_In()
        {
        }

        public T_Stock_InHead Head
        {
            get;
            set;
        }
        public List<T_Stock_InItems> items
        {
            get;
            set;
        }

    }
}
