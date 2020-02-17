using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SuperHero.Models
{
    public class SuperHero
    {
        [Key]

        public int ID { get; set; }
        public string Name { get; set; }

        public string AlterEgo { get; set; }

        public string PrimaryAbilty { get; set; }

        public string SecondaryAbilty { get; set; }

        public string CatchPhrase { get; set; }
    }
}
