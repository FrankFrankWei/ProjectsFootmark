/******************************************************************
** auth: wei.huazhong
** date: 11/30/2018 10:47:21 AM
** desc:
******************************************************************/

using System;
using System.Collections.Generic;
using System.Text;

namespace Entity
{
    public class Project
    {
	    public Project()
	    {}

        public int ID { get; set; }
        public string Name { get; set; }
        public DateTime CreateTime { get; set; }
        public bool Validity { get; set; }
    }
}
