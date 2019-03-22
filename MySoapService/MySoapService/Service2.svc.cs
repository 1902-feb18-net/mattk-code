using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace MySoapService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service2" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service2.svc or Service2.svc.cs at the Solution Explorer and start debugging.
    public class Service2 : IService2
    {
        public QuestionList CreateQuestionList()
        {
            return new QuestionList();
        }

        public void DeleteQuestionList(QuestionList QLObject)
        {
            QLObject.Questions.Clear();
        }

        public List<Question> GetQuestionList(QuestionList QLObject)
        {
            return QLObject.Questions;
        }

        public void UpdateQuestionList(QuestionList QLObject, int index, Question newQ)
        {
            QLObject.Questions[index] = new Question
            {
                QuestionId = newQ.QuestionId,
                Category = newQ.Category,
                Rating = newQ.Rating
            };
        }
    }
}
