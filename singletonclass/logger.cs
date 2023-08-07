using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace singletonclass
{
    public class logger
    {
        private static logger _instance = null;
        private static object _lock = new object();
        public static int counter = 0;
        private logger()
        {
            counter++;
            Console.WriteLine(counter.ToString());
;        }

        public static logger getInstance()
        {
            if (_instance == null)
            {
                lock (_lock)
                {
                    if (_instance == null)
                    {
                        _instance = new logger();
                    }
                }
            }
            return _instance;
        }
        public static logger getInstance1()
        {     
            if (_instance == null)
            {
                _instance = new logger();
            }
            return _instance;
        }
    }
}
