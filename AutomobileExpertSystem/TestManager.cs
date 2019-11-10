using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace AutomobileExpertSystem.TestModule
{
    class TestManager
    {
        public TestManager()
        {

        }

        public void startManualTest()
        {
            FactManager factManager = new FactManager();
            QuestionManager questionManager = new QuestionManager();
            questionManager.manualStart(factManager);
        }
       
    }
}
