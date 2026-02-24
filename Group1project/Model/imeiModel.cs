using System;
using System.Collections.Generic;
using System.Text;

namespace Group1project.Model
{
    public class imeiModel
    {
        // 来自 tblimei 的字段
        public string imei { get; set; }
        public string status { get; set; }
        public string SKUcode { get; set; }

        // 来自 tblproduct 的字段（你想要在页面上显示的）
        public string SPUcode { get; set; }
        public string SPUname { get; set; }
        public string brand { get; set; }
        public string SKUspec { get; set; }
        public string SKUname { get; set; }
    }
}
