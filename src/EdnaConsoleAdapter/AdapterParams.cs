using System;

namespace EdnaConsoleAdapter
{
    public class AdapterParams
    {
        public string MeasId { get; set; } = null;
        public string Type { get; set; } = "snap";
        public int Secs { get; set; } = 60;
        public bool IncludeQuality { get; set; } = false;
        public DateTime FromTime { get; set; } = DateTime.Now.AddDays(-2);
        public DateTime ToTime { get; set; } = DateTime.Now.AddDays(-1);

        public static AdapterParams ParseArgs(string[] args)
        {
            // read arguments for meas_id, from_time, to_time, host, port, path, username, password, ref_meas_id

            AdapterParams ap = new AdapterParams();

            for (int argIter = 0; argIter < args.Length; argIter++)
            {
                // Console.WriteLine(args[argIter]);
                if (args[argIter] == "--meas_id")
                {
                    ap.MeasId = args[argIter + 1];
                }
                else if (args[argIter] == "--from_time")
                {
                    ap.FromTime = TimeUtils.FromMillisecondsSinceUnixEpoch(long.Parse(args[argIter + 1]));
                }
                else if (args[argIter] == "--to_time")
                {
                    ap.ToTime = TimeUtils.FromMillisecondsSinceUnixEpoch(long.Parse(args[argIter + 1]));
                }
                else if (args[argIter] == "--type")
                {
                    ap.Type = args[argIter + 1];
                }
                else if (args[argIter] == "--secs")
                {
                    ap.Secs = int.Parse(args[argIter + 1]);
                }
                else if (args[argIter] == "--include_quality")
                {
                    ap.IncludeQuality = true;
                }
            }
            return ap;
        }
    }
}
