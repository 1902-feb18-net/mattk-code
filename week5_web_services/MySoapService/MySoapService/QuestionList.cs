using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace MySoapService
{
    public class QuestionList
    {
        [DataMember]
        public List<Question> Questions { get; set; } = new List<Question>();
    }
}