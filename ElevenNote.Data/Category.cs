using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ElevenNote.Data
{
    public class Category
    {
        [Key]
        public int CatId { get; set; }
        [Required]
        public string Name { get; set; }
        public virtual List<Note> Notes { get; set; }
    }
}
