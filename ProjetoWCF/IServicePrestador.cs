using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace ProjetoWCF
{
    [ServiceContract]
    public interface IServicePrestador
    {
        [OperationContract]
        [ReferencePreservingDataContractFormat]

        List<Prestador> FindAll();

        [OperationContract]
        [ReferencePreservingDataContractFormat]

        Prestador Find(int id);

        [OperationContract]
        Prestador New(Prestador prestador);

        [OperationContract]
        [ReferencePreservingDataContractFormat]

        Prestador Update(int id, Prestador prestador);

        [OperationContract]
        Prestador Delete(int id);
    }
}
