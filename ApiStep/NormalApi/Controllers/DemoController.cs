using NormalApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Controllers;

namespace NormalApi.Controllers
{
    public class DemoController : ApiController
    {
        public new void Initiliaze(HttpControllerContext context)
        {
            base.Initialize(context);
        }

        public dynamic Get()
        {
            return "你好";
        }
        [HttpGet]
        [Route("bind/bind1/{name}/{age}")]
        public void Bind1(User usr1, User usr2)
        {

        }
        [Route("bind/bind1/{usr1.name}/{usr1.age}/{usr2.name}/{usr2.age}")]
        /// <summary>
        /// 这个
        /// </summary>
        /// <param name="t1"></param>
        /// <param name="t2"></param>
        /// <param name="t3"></param>
        /// <returns></returns>
        [Route("GetResult/{t1}/{t2}/{t3}")]
        public Tuple<string, int, int?> GetResult(string t1,int t2,int ?t3)
        {
        
            return new Tuple<string, int, int?>(t1, t2, t3);
        }
    }
}
