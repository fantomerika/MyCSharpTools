using JobScheduling;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoTest
{
    class Program
    {
        static void Main(string[] args)
        {
            var jobHelper = new JobHelper();
            jobHelper.addJob<HelloJob>(jobHelper.createTrigger("0/5 * * * * ? ", "hello"),"hello");
            jobHelper.JobList();
            //new JobScheduling.test().start();
            Console.ReadKey();
        }
    }
}
