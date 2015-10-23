using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace RuSpeak.Models.Things
{
    public class AudioContent
    {
        [Key]
        public int AudioContentId { get; set; }
        public string Name { get; set; }
        public virtual Post Post { get; set; }
        
        [Column(TypeName = "image")]
        [MaxLength]
        public virtual byte[] AudioStream { get; set; }
    }
}