using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace EasyCapFrontend {
    public struct DirectShowOptions {
        public string pixel_format;
        public string vcodec;
        public int width;
        public int height;
        public double framerate;

        public static bool TryParse(string str, out DirectShowOptions value) {
            value = new DirectShowOptions();

            var r = Regex.Match(str, "max s=([0-9]+)x([0-9]+) fps=([0-9]+)");
            if (!r.Success) return false;
            
            value.width = int.Parse(r?.Groups?[1]?.Value);
            value.height = int.Parse(r?.Groups?[2]?.Value);
            value.framerate = int.Parse(r?.Groups?[3]?.Value);

            var r2 = Regex.Match(str, "pixel_format=([^ ]+)");
            value.pixel_format = r2.Success ? r2.Groups[1].Value : null;
            var r3 = Regex.Match(str, "vcodec=([^ ]+)");
            value.vcodec = r3.Success ? r3.Groups[1].Value : null;
            if (value.pixel_format == null && value.vcodec == null) return false;

            return true;
        }

        public override string ToString() {
            StringBuilder sb = new StringBuilder();
            if (pixel_format != null) sb.Append(" -pixel_format " + pixel_format);
            if (vcodec != null) sb.Append(" -vcodec " + vcodec);
            sb.Append($" -framerate {framerate} -video_size {width}x{height}");
            return sb.ToString();
        }
    }
}
