using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Tp02SisWeb2.Models
{
    public class BL
    {
        [Key]
        public int IdBl { get; set; }
        public int Num { get; set; }
        public string Consigner { get; set; }
        public string Navio { get; set; }
        public List<Container> containers { get; } = new List<Container>();

       
    }
}
