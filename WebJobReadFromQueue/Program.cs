using Common;
using Microsoft.WindowsAzure.Jobs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebJobReadFromQueue
{
    class Program
    {
        static void Main(string[] args)
        {
            JobHost host = new JobHost();
            host.RunAndBlock();
        }

        public static void WaitForMessageInQueue([QueueInput("sendoutqueue")] Email email) 
        {
            Console.WriteLine("Send email to {0}", email.To);
        }
    }
}
