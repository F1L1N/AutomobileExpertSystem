using System;
using System.Collections.Generic;
using System.Text;

namespace AutomobileExpertSystem
{
    class QuestionManager
    {
        private QuestionDatabase questionDatabase = new QuestionDatabase();

        public QuestionManager()
        {
            init();
        }

        private void init()
        {
            string modifyQuestion = "У Вас ";
            int i = 1;
            questionDatabase.Add(new Question(i, "шкп", modifyQuestion + "шумы коробки передач?")); i++;
            questionDatabase.Add(new Question(i, "нцм", modifyQuestion + "ненормальный цвет масла?")); i++;
            questionDatabase.Add(new Question(i, "зввп", modifyQuestion + "затруднено включение / выключение передач?")); i++;
            questionDatabase.Add(new Question(i, "нппвд", modifyQuestion + "нормальное переключение передач при выключенном двигателе?")); i++;
            questionDatabase.Add(new Question(i, "шпдвп", modifyQuestion + "шумы при движении с включенной передачей?")); i++;
            questionDatabase.Add(new Question(i, "зпсош", modifyQuestion + "заедание или повреждение сателлитов и оконечной шестерни?")); i++;
            questionDatabase.Add(new Question(i, "шп", modifyQuestion + "шумы при поворотах?")); i++;
            questionDatabase.Add(new Question(i, "дндпп", modifyQuestion + "детонация при начале движения или при переключении передач?")); i++;
            questionDatabase.Add(new Question(i, "свп", modifyQuestion + "самопроизвольное выключение передачи?")); i++;
            questionDatabase.Add(new Question(i, "икп", modifyQuestion + "износ кромок протектора?")); i++;
            questionDatabase.Add(new Question(i, "нениш", modifyQuestion + "ненормальный износ шин?")); i++;
            questionDatabase.Add(new Question(i, "икпдс", modifyQuestion + "износ кромок протектора с двух сторон?")); i++;
            questionDatabase.Add(new Question(i, "икпос", modifyQuestion + "износ кромок протектора с одной стороны?")); i++;
            questionDatabase.Add(new Question(i, "ицп", modifyQuestion + "износ центра протектора?")); i++;
            questionDatabase.Add(new Question(i, "нериш", modifyQuestion + "неравномерный износ шин?")); i++;
            questionDatabase.Add(new Question(i, "ут", modifyQuestion + "утечка в топливопроводах?")); i++;
            questionDatabase.Add(new Question(i, "чцвг", modifyQuestion + "черный цвет выхлопных газов?")); i++;
            questionDatabase.Add(new Question(i, "бцвг", modifyQuestion + "белый цвет выхлопных газов?")); i++;
            questionDatabase.Add(new Question(i, "сд", modifyQuestion + "стук в двигателе?"));
        }

        public QuestionDatabase autoStart(FactManager factManager)
        {
            LinkedListNode<Question> firstNode = questionDatabase.getQuestions().First;
            for (LinkedListNode<Question> question = firstNode; question != null; question = question.Next)
            {
                question.Value.show();
            }
            return this.questionDatabase;
        }

        public QuestionDatabase manualStart(FactManager factManager) 
        {
            string signal;
            LinkedListNode<Question> firstNode = questionDatabase.getQuestions().First;
            for (LinkedListNode<Question> question = firstNode; question != null; question = question.Next)
            {
                signal = question.Value.show();
                while (signal == "back")
                {
                    if (question != firstNode)
                    {
                        question = question.Previous;   
                    }
                    updateQuestionList(signal);
                    
                    signal = question.Value.show();
                }
                updateQuestionList(signal);
            } 
            answersAnalysis(factManager);
            return questionDatabase;
        }

        private void updateQuestionList(string signal)
        {
            if (signal == "y")
            {

            }
        }

        private void answersAnalysis(FactManager factManager)
        {
            List<string> tags = new List<string>();
            for (LinkedListNode<Question> question = questionDatabase.getQuestions().First; question != null; question = question.Next)
            {
                Question node = question.Value;
                if (node.getAnswer())
                {
                    tags.Add(node.getTag());
                }
            }
            Dictionary<Fact, double> compareTags = factManager.getFactDatabase().Compare(tags);
            double max = 0.0;
            Fact maxFact = new Fact();
            foreach (var entry in compareTags)
            {
                if (entry.Value > max)
                {
                    max = entry.Value;
                    maxFact = entry.Key;
                }
            }
            maxFact.show(max);
        }
    }
}
