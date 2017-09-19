using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShiTiImportTool.Entity
{
    public class ShiJuanSearchEntity:PageSearchEntity
    {
        public string shiJuanName { get; set; }
        public DateTime beginTime { get; set; }
        public DateTime endTime { get; set; }
    }
}