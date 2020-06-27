using System;
using System.Collections.Generic;
using System.Linq;

namespace EdnaConsoleAdapter
{
    class Program
    {
        static void Main(string[] args)
        {
            // parse arguments
            AdapterParams ap = AdapterParams.ParseArgs(args);
            if (ap.MeasId == null)
            {
                ConsoleUtils.FlushChunks("");
                return;
            }

            // fetch data
            List<double> data = EdnaFetcher.FetchHistData(ap.MeasId, ap.FromTime, ap.ToTime, ap.Secs, ap.Type, ap.IncludeQuality);

            // create output string
            string outStr = string.Join(",", data.Select(d => d.ToString()));
            ConsoleUtils.FlushChunks(outStr);
        }
    }
}
