using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace GarciaExamenP3.Models
{
    public class AGThumbnail
    {
        public string Path { get; set; }
        public string Extension { get; set; }

        public string FullPath => $"{Path}.{Extension}";
    }
}
