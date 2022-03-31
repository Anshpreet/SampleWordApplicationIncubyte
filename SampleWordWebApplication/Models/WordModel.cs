using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleWordWebApplication.Models
{
    public class WordModel
    {
        [Display(Name = "Id")]
        public int? WordId { get; set; }
        [Display(Name = "Word")]
        public string WordParam { get; set; }
        [Display(Name = "Last Updated")]
        public DateTimeOffset? UpdatedAt { get; set; }
        public DateTimeOffset? DeletedAt { get; set; }
        public bool? IsDeleted { get; set; }
    }
}
