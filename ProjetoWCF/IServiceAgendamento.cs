using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace ProjetoWCF
{
    [ServiceContract]
    public interface IServiceAgendamento
    {
        [OperationContract]
        [ReferencePreservingDataContractFormat]

        List<Agendamento> FindAll();

        [OperationContract]
        [ReferencePreservingDataContractFormat]

        Agendamento Find(int id);

        [OperationContract]
        Agendamento New(Agendamento agendamento);

        [OperationContract]
        [ReferencePreservingDataContractFormat]

        Agendamento Update(int id, Agendamento agendamento);

        [OperationContract]
        Agendamento Delete(int id);
    }
}
