using System;
using System.Collections.Generic;
using System.Text;

namespace AutomobileExpertSystem
{
    class FactDatabase
    {
        private Dictionary<List<string>, Fact> factBox = new Dictionary<List<string>, Fact>();

        public void Add(List<string> tags, Fact fact)
        {
            factBox.Add(tags, fact);
        }

        public Dictionary<Fact, double> Compare(List<string> tags)
        {
            Dictionary<Fact, double> compareCoeffs = new Dictionary<Fact, double>();
            foreach (var entry in factBox)
            {
                double coeff = 0.0;
                foreach (var tag in tags)
                {                 
                    if (entry.Key.Contains(tag))
                    {
                        coeff++;
                    }
                }
                coeff /= tags.Count;
                compareCoeffs.Add(entry.Value, coeff);
            }
            return compareCoeffs;
        }
    }
}
