using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace pokemon_challenge.PokeHelper
{
    public class ContestType
    {
        public int id { get; set; }
        public string name { get; set; }
        public NamedAPIResource berry_flavor { get; set; }
        public List<ContestName> names { get; set; }
    }
}