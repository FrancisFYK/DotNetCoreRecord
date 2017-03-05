using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetCoreRecord.Models
{

    [NotMapped]
    public class Persion
    {
        //public long Id { get; set; }
        public int PersionId { get; set; }

        [MaxLength(50)]
        [Required]
        public string UserName { get; set; }

        [Required]
        public int Age { get; set; }
    }
}
