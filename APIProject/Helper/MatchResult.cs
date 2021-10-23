using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIProject.Helper
{
    public class MatchResult
    {
        public decimal HardSkillMatchPercentage { get; set; }
        public decimal SoftSkillMatchPercentage { get; set; }

        public decimal TotalMatchPercentage { get; set; }
    }
}
