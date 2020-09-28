using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Tp02SisWeb2.Models
{
    public class Container
    {
        [Key]
        public int IdContainer { get; set; }
        public int numContainer { get; set; }
        public string Tipo { get; set; }
        public string tamanho { get; set; }
        public int IdBl { get; set; }
        public BL BL { get; set; }
    }
}
