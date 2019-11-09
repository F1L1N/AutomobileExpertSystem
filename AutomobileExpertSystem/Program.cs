using AutomobileExpertSystem.TestModule;

namespace AutomobileExpertSystem
{
    class Start
    {
        static void Main(string[] args)
        {
            TestManager testManager = new TestManager();
            //testManager.startAutoTest();
            testManager.startManualTest();
        }
    }
}
