using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simle.System.Job
{
    class Program
    {
        static void Main(string[] args)
        {
            SyncData syncData = new SyncData();
            syncData.Run();
        }
    }
}
