using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace MemeCollection.Domain.Entities
{
    public class Meme
    {
        [Key]
        public int MemeID { get; set; }
        public string Title { get; set; }
        public string ImageURI { get; set; }
        public string Description { get; set; }
        public string Genre { get; set; }

    }
}
