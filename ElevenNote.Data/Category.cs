using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElevenNote.Data
{
    public class Category
    {
        [Key]
        public int? CatId { get; set; }
        public string Name { get; set; }
       // public int NoteId { get; set; }
       // [ForeignKey(nameof(NoteId))]
       // public virtual Note Note { get; set; }
    }
}
