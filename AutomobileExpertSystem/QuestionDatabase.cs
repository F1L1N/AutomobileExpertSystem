using System;
using System.Collections.Generic;
using System.Text;

namespace AutomobileExpertSystem
{
    class QuestionDatabase
    {
        private LinkedList<Question> questions = new LinkedList<Question>();

        public LinkedList<Question> getQuestions()
        {
            return questions;
        }

        internal void Add(Question question)
        {
            questions.AddLast(question);
        }
    }
}
