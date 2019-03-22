using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace MySoapService
{
    [DataContract]
    public class Question
    {
        [DataMember]
        public int QuestionId { get; set; }
        [DataMember]
        public string Category { get; set; }
        [DataMember]
        public int Rating { get; set; }

        public DateTime DateModified { get; set; }
    }
}