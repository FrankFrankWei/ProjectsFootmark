/******************************************************************
** auth: wei.huazhong
** date: 12/4/2018 3:59:54 PM
** desc:
******************************************************************/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel
{
    public class ProjectVM
    {
        public ProjectVM()
        {
            FootmarkList = new List<FootmarkVM>();
        }

        public int ID { get; set; }
        public string Name { get; set; }
        public DateTime CreateTime { get; set; }
        public List<FootmarkVM> FootmarkList { get; set; }
    }
}
