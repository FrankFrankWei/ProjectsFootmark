/******************************************************************
** auth: wei.huazhong
** date: 12/4/2018 2:53:02 PM
** desc:
******************************************************************/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel
{
    public class FootmarkVM 
    {
        public FootmarkVM()
        { }
        public int ID { get; set; }
        public int ProjectID { get; set; }
        public string Content { get; set; }
        public DateTime MarkTime { get; set; }
    }
}
