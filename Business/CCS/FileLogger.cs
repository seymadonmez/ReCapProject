using System;
using System.Collections.Generic;
using System.Text;

namespace Business.CCS
{
    public class FileLogger:ILogger
    {
        public void Logger()
        {
            Console.WriteLine("Dosyaya loglandı");
        }
    }
}
