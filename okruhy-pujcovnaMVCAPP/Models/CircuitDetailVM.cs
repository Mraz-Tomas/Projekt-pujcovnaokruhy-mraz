using System.Collections.Generic;
using okruhy_pujcovnaMVCAPP.Entities;

namespace okruhy_pujcovnaMVCAPP.Models
{
    public class CircuitDetailVM
    {
        public circuit Circuit { get; set; }
        public List<car> AvailableCars { get; set; }
    }
}
