using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.Model
{
    public class Pager<T>
    {
        public int PageIndex { get; set; }

        public int PageSize { get; set; }

        public string Fields { get; set; }

        public T Where { get; set; }

        public string Order { get; set; }

        public string Sort { get; set; }

        public int RecordTotal { get; set; }

        public int PageCount { get; set; }

        public DataTable DataTableSource { get; set; }



    }
}
