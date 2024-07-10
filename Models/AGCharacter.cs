using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GarciaExamenP3.Models
{
    public class AGCharacter
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        [Indexed]
        public int ThumbnailId { get; set; }
        [Ignore]
        public AGThumbnail Thumbnail { get; set; }
    }
}
