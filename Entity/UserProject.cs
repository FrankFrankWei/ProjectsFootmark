/******************************************************************
** auth: wei.huazhong
** date: 11/30/2018 10:47:56 AM
** desc:
******************************************************************/

using System;
using System.Collections.Generic;
using System.Text;

namespace Entity
{
    public class UserProject
    {
	    public UserProject()
	    {}

        public int ID { get; set; }
        public int UserID { get; set; }
        public int ProjectID { get; set; }
    }
}
