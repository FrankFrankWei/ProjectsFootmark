/******************************************************************
** auth: wei.huazhong
** date: 11/30/2018 10:47:16 AM
** desc:
******************************************************************/

using System;
using System.Collections.Generic;
using System.Text;

namespace Entity
{
    public class User
    {
	    public User()
	    {}

        public int ID { get; set; }
        public string Name { get; set; }
        public string NickName { get; set; }
        public string Password { get; set; }
        public DateTime CreateTime { get; set; }
        public bool Validity { get; set; }
    }
}
