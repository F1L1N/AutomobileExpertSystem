using System;

namespace AutomobileExpertSystem
{
    class Question
    {
        private int id;

        private string tag;

        private string question;

        private bool answer;

        public bool getAnswer()
        {
            return answer;
        }

        public string getTag()
        {
            return tag;
        }

        public Question(int id, string tag, string question)
        {
            this.id = id;
            this.tag = tag;
            this.question = question;
        }

        private string answerOnQuestion()
        {
            Console.Write("Answer: ");
            //answer = Console.ReadLine() == "y" ? true : false;
            string currentAnswer = Console.ReadLine();
            switch (currentAnswer)
            {
                case "y":
                    answer = true;
                    return string.Empty;
                case "n":
                    answer = false;
                    return string.Empty;
                default:
                    return currentAnswer;
            }
        }

        public string show()
        {
            Console.WriteLine(question);
            return answerOnQuestion();
        }

        public void showAnswer()
        {
            Console.WriteLine("На вопрос: ");
            showQuestion();
            Console.Write("Вы ответили ");
            if (answer)
            {
                Console.WriteLine("утвердительно.");
            }
            else
            {
                Console.WriteLine("отрицательно.");
            }
        }
        public void showQuestion()
        {
            Console.WriteLine(question);
        }
    }
}
