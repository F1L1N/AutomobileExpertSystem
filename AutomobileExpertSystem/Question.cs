using System;

namespace AutomobileExpertSystem
{
    class Question
    {
        private int id;

        private string tag;

        private string question;

        private bool answer;

        private bool available = true;

        public bool getAnswer()
        {
            return answer;
        }

        public int getId()
        {
            return id;
        }

        public string getTag()
        {
            return tag;
        }

        public void setStatus(bool status)
        {
            available = status;
        }

        public bool getStatus()
        {
            return available;
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
                    break;
                case "n":
                    answer = false;
                    break;
                default:
                    break;
            }
            return currentAnswer;
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
