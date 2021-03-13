using System;

namespace Business.CCS
{
    public class DatabaseLogger : ILogger
    {
        public void Logger()
        {
            Console.WriteLine("Dosyaya loglandı");
        }
    }
}