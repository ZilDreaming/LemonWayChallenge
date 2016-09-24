using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using log4net;

namespace LemonWayChallenge.Controllers
{
    public class FibonacciController : ApiController
    {
        private static readonly ILog Log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        // GET api/<controller>/n
        public long Get(int id)
        {
            long result = -1;

            if (id > 0 && id <= 100)
            {
                long fib_previous = 0;
                long fib = 1;

                for (int looper = 2; looper <= id; looper++)
                {
                    long temp = fib;
                    fib = fib + fib_previous;
                    fib_previous = temp;
                }

                result = (fib > 0) ? fib : 0;
            }

            Log.Debug("searched fibonacci of " + id + " and returned " + result);
            return result;
        }
    }
}