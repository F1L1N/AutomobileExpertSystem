using System;
using System.Collections.Generic;
using System.Text;

namespace AutomobileExpertSystem.TestModule
{
    class Test
    {
        public string topic;

        public int numberQuestions;

        public int numberAnswers;

        public string name;

        public int rightAnswers;

        public List<int> wrongAnswers;

        public DateTime startTestTime;

        public DateTime finishTestTime;

        public Test(string name, string topic)
        {
            this.name = name;
            this.topic = topic;
        }

        public void writeStartTime()
        {
            startTestTime = DateTime.Now;
        }

        public void writeFinishTime()
        {
            finishTestTime = DateTime.Now;
        }
    }
}
