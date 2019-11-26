using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace ProjetoWCF
{
    [ServiceContract]
    public interface IServiceServico
    {
        [OperationContract]
        List<Servico> FindAll();

        [OperationContract]
        Servico Find(int id);

        [OperationContract]
        Servico New(Servico servico);

        [OperationContract]
        Servico Update(int id, Servico prestador);

        [OperationContract]
        Servico Delete(int id);
    }
}
