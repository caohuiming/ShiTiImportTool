using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShiTiImportTool.Entity
{
    public class PageSearchEntity
    {
        public int pageIndex { get; set; }//从1开始
        public int pageSize { get; set; }
        public int rowCount { get; set; }
    }
}
