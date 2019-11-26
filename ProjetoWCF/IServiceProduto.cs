using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace ProjetoWCF
{
    [ServiceContract]
    public interface IServiceProduto
    {
        [OperationContract]
        List<Produto> FindAll();

        [OperationContract]
        Produto Find(int id);

        [OperationContract]
        Produto New(Produto produto);

        [OperationContract]
        Produto Update(int id, Produto produto);

        [OperationContract]
        Produto Delete(int id);
    }
}
