/******************************************************************
** auth: wei.huazhong
** date: 11/30/2018 11:02:05 AM
** desc:
******************************************************************/

using System;
using System.Collections.Generic;
using System.Text;

namespace Entity
{
    public class Footmark
    {
        public Footmark()
        { }
        public int ID { get; set; }
        public int ProjectID { get; set; }
        public string Content { get; set; }
        public int Year { get; set; }
        public int Month { get; set; }
        public int Day { get; set; }
        public int Hour { get; set; }
        public int Minute { get; set; }
        public DateTime CreateTime { get; set; }
    }
}
