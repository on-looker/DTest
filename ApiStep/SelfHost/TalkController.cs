﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace SelfHost
{
   public class TalkController:ApiController
    {
       public string Get()
       {
           return "OK";
       }

    }
}
