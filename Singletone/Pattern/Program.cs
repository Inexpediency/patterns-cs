using System;

namespace SingletonPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            var singleton1 = FileWorker.Instance;
            var singleton2 = FileWorker.Instance;

            // Create new instance of singletone cannot be created
            // var singleton = new FileWorkerSingleton(); 

            singleton1.WriteText("Hello, World!");
            singleton2.WriteText("Wassup :3");

            singleton1.Save();
            singleton2.Save();
        }
    }
}
