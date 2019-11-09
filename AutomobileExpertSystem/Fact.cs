using System;

namespace AutomobileExpertSystem
{
    class Fact
    {
        private string fact;

        public Fact()
        {

        }

        public Fact(string fact)
        {
            this.fact = fact;
        }

        public void show(double probality)
        {
            double probProcent = probality * 100;
            string probStr = (probality * 100).ToString() + "%";
            if (probProcent == 100)
            {
                Console.WriteLine("Однозначно диагностируема следующая проблема: {0}", fact);
            }
            else
            {
                Console.WriteLine("Возможное нарушение (вероятность {0}): {1}", probStr, fact);
            }
            
        }
    }
}
