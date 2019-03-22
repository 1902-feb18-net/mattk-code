using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace MySoapService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService2" in both code and config file together.
    [ServiceContract]
    public interface IService2
    {
        [OperationContract]
        List<Question> GetQuestionList(QuestionList questionList);

        [OperationContract]
        QuestionList CreateQuestionList();

        [OperationContract]
        void UpdateQuestionList(QuestionList questionList, int index, Question newQ);

        [OperationContract]
        void DeleteQuestionList(QuestionList questionList);

    }
}
