using System.Collections.Generic;

namespace StatesNLgas.Models
{
    public class StateLgas
    {
        public string State { get; set; }
        public IList<string> Lgas { get; set; }
    }
}
