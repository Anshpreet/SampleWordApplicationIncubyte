using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleWord.Entities
{
    public class WordData
    {
        public int? WordId { get; set; }
        public string WordParam { get; set; }
        public DateTimeOffset? UpdatedAt { get; set; }
        public DateTimeOffset? DeletedAt { get; set; }
        public bool? IsDeleted { get; set; }
    }
}
