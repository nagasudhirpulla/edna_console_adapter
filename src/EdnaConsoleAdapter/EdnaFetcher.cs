using InStep.eDNA.EzDNAApiNet;
using System;
using System.Collections.Generic;

namespace EdnaConsoleAdapter
{
    public class EdnaFetcher
    {
        public static List<double> FetchHistData(string pnt, DateTime startTime, DateTime endTime, int secs, string type, bool includeQuality)
        {
            int nret = 0;
            List<double> historyResults = new List<double>();
            try
            {
                uint s = 0;
                double dval = 0;
                DateTime timestamp = DateTime.Now;
                string status = "";
                TimeSpan period = TimeSpan.FromSeconds(secs);
                // history request initiation
                if (type == "snap")
                { nret = History.DnaGetHistSnap(pnt, startTime, endTime, period, out s); }
                else if (type == "average")
                { nret = History.DnaGetHistAvg(pnt, startTime, endTime, period, out s); }
                else if (type == "min")
                { nret = History.DnaGetHistMin(pnt, startTime, endTime, period, out s); }
                else if (type == "max")
                { nret = History.DnaGetHistMax(pnt, startTime, endTime, period, out s); }
                else { nret = History.DnaGetHistRaw(pnt, startTime, endTime, out s); }

                while (nret == 0)
                {
                    nret = History.DnaGetNextHist(s, out dval, out timestamp, out status);
                    if (status != null)
                    {
                        historyResults.Add(TimeUtils.ToMillisSinceUnixEpoch(timestamp));
                        historyResults.Add(dval);
                        if (includeQuality)
                        {
                            DataQuality qual = DataQuality.GOOD;
                            if (status == "GOOD" || status == "OK")
                            {
                                qual = DataQuality.GOOD;
                            }
                            else if (status == "BAD")
                            {
                                qual = DataQuality.BAD;
                            }
                            else if (status == "SUSPECT")
                            {
                                qual = DataQuality.SUSPECT;
                            }
                            else if (status == "REPLACED")
                            {
                                qual = DataQuality.REPLACED;
                            }
                            historyResults.Add((int)qual);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Console.WriteLine("Error while fetching history results " + ex.Message);
                historyResults = new List<double>();
            }
            return historyResults;
        }

        public static List<double> FetchHistDataTest(string pnt, DateTime startTime, DateTime endTime, int secs, string type, bool includeQuality)
        {
            List<double> historyResults = new List<double>();
            Random r = new Random();
            for (DateTime currTime = startTime; currTime <= endTime; currTime += TimeSpan.FromSeconds(secs))
            {
                historyResults.Add(TimeUtils.ToMillisSinceUnixEpoch(currTime));
                historyResults.Add(r.Next(10, 50));
                if (includeQuality)
                {
                    historyResults.Add(0);
                }
            }
            return historyResults;
        }
    }
}
