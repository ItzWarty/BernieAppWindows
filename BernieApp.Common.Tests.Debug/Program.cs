using BernieApp.Common.Tests.Http;
using System;
using System.Threading.Tasks;

namespace BernieApp.Common.Tests.Debug
{
    class Program
    {
        static void Main(string[] args)
        {
            var test = new ES4BSClientTests();
            var task = Task.Run(async () => await test.WithES4BSClient_Given404_ThrowHttpError404());
            try
            {
                task.Wait();
            }
            catch(Exception e)
            {
                if (task.IsFaulted)
                {
                    Console.WriteLine(task.Exception.GetBaseException().GetType());
                }
            }
        }
    }
}
