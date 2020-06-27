using System;

namespace EdnaConsoleAdapter
{
    public class ConsoleUtils
    {
        public static void FlushChunks(string outStr, int chunkSize = 50000)
        {
            for (int chunkIter = 0; chunkIter < outStr.Length; chunkIter += chunkSize)
            {
                Console.Write(outStr.Substring(chunkIter, Math.Min(chunkSize, outStr.Length - chunkIter)));
                Console.Out.Flush();
            }
        }
    }
}
