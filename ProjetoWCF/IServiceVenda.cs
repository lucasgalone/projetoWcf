using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace ProjetoWCF
{
    [ServiceContract]
    public interface IServiceVenda
    {
        [OperationContract]
        [ReferencePreservingDataContractFormat]
        List<Venda> FindAll();

        [OperationContract]
        [ReferencePreservingDataContractFormat]
        VendaDto Find(int id);

        [OperationContract]
        Venda New(Venda venda);

        [OperationContract]
        [ReferencePreservingDataContractFormat]
        IEnumerable<ComboboxDto> FindAllComboboxCliente();

        [OperationContract]
        [ReferencePreservingDataContractFormat]
        IEnumerable<ComboboxDto> FindAllComboboxPrestador();

        [OperationContract]
        [ReferencePreservingDataContractFormat]
        IEnumerable<Produto> FindAllProdutos();

        [OperationContract]
        [ReferencePreservingDataContractFormat]
        IEnumerable<Servico> FindAllServicos();
    }
}
