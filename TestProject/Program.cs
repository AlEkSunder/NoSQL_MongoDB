using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Concrete;
using DAL.Interface;
using TestProject.Entity;
using TestProject.TestClass;

namespace TestProject
{
    class Program
    {
        static void Main(string[] args)
        {
            new MongoTry().Run();
        }
    }
}
