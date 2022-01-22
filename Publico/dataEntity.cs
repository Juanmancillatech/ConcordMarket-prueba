using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Marketwebform.Publico
{
    public class dataEntity
    {
        public dataEntity()
        {
            Catid = 0;
            Catnombre = "";
        }
       

            public int Catid { get; set; }
            public string Catnombre { get; set; }

    }
}