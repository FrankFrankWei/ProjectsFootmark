/******************************************************************
** auth: wei.huazhong
** date: 11/30/2018 10:48:09 AM
** desc:
******************************************************************/

using System;
using System.Collections.Generic;
using System.Text;

namespace Entity
{
    public class Log
    {
        public Log()
        { }
        public int ID { get; set; }
        public int UserID { get; set; }
        public int ProjectID { get; set; }
        public string Action { get; set; }
        public int FootmarkID { get; set; }
    }
}
