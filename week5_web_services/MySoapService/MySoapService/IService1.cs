using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace MySoapService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IService1
    {
        // TODO: Add your service operations here
        [OperationContract] // Defines a service that will be exposed
        string GetServiceVersion();

        // Not all methods need to be exposed as a service
        [OperationContract]
        int DoubleNumber(int num);

        [OperationContract]
        [FaultContract(typeof(InvalidOperationException))]
        Question GetQuestion(int id);



    }


    // Use a data contract as illustrated in the sample below to add composite types to service operations.
   
}
