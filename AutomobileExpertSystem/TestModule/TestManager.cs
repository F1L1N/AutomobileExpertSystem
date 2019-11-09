using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace AutomobileExpertSystem.TestModule
{
    class TestManager
    {
        List<Test> tests;
        Dictionary<string, string[]> testFiles;

        public TestManager()
        {
            this.tests = new List<Test>();
            this.testFiles = new Dictionary<string, string[]>();
        }

        public void loadingTestFiles()
        {
            string[] pathes = Directory.GetFiles(Config.testFiles);
            foreach (string path in pathes)
            {
                using (var stream = new StreamReader(path))
                {
                    string name = Path.GetFileName(path);
                    string[] streamText = File.ReadAllLines(path, Encoding.UTF8);
                    testFiles.Add(name, streamText);
                }
            }
        }

        public Test initManualTest()
        {
            Console.Write("Введите ФИО: ");
            string name = Console.ReadLine();
            Console.Write("Введите тему: ");
            string topic = Console.ReadLine();
            Test test = new Test(name, topic);
            return test;
        }

        public void startManualTest()
        {
            Test test = initManualTest();
            FactManager factManager = new FactManager();
            QuestionManager questionManager = new QuestionManager();
            test.writeStartTime();
            QuestionDatabase handledDatabase = questionManager.manualStart(factManager);

            finishTest(test);
        }

        public Test initAutoTest()
        {
            Console.Write("ФИО:");
            string name = Config.adminName;
            Console.WriteLine(name);
            Console.Write("Тема:");
            string topic = Config.defaultTopic;
            Console.WriteLine(topic);
            Test test = new Test(name, topic);
            return test;
            //startAutoTest(test);
        }

        public void startAutoTest()
        {
            loadingTestFiles();
            foreach (KeyValuePair<string, string[]> entry in testFiles)
            {
                Test test = initAutoTest();
                FactManager factManager = new FactManager();
                QuestionManager questionManager = new QuestionManager();
                test.writeStartTime();
                QuestionDatabase handledDatabase = questionManager.autoStart(factManager);
                //TODO обработка ответов

                finishTest(test);
            }
            
        }

        public void finishTest(Test test)
        {
            test.writeFinishTime();
            logTest(test);
        }

        public void logTest(Test test)
        {
            using (StreamWriter output = File.AppendText(Config.log))
            {
                output.WriteLine("Проходящий тест: " + test.name);
                output.WriteLine("Тема теста: " + test.topic);
                output.WriteLine("Начало теста: " + test.startTestTime);
                output.WriteLine("Конец теста: " + test.finishTestTime);
                if (test.numberQuestions != 0) output.WriteLine("Количество заданных вопросов: " + test.numberQuestions);
                if (test.rightAnswers != 0) output.WriteLine("Количество правильных вопросов: " + test.rightAnswers);
                if (test.wrongAnswers != null) output.WriteLine("Список вопросов с неправильным ответом: " + test.wrongAnswers.ToString());

                output.WriteLine();
            }
        }
    }
}
