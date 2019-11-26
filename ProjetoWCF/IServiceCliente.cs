using Entity;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Description;
using System.ServiceModel.Dispatcher;
using System.Xml;

namespace ProjetoWCF
{
    [ServiceContract]
    public interface IServiceCliente
    {
        [OperationContract]
        [ReferencePreservingDataContractFormat]
        List<Cliente> FindAll();

        [OperationContract]
        [ReferencePreservingDataContractFormat]
        Cliente Find(int id);

        [OperationContract]
        [ReferencePreservingDataContractFormat]
        IEnumerable<ComboboxDto> FindAllCombobox();


        [OperationContract]
        Cliente New(Cliente cliente);

        [OperationContract]
        [ReferencePreservingDataContractFormat]
        Cliente Update(int id, Cliente cliente);

        [OperationContract]
        Cliente Delete(int id);
    }

    public class ReferencePreservingDataContractFormatAttribute
   : Attribute, IOperationBehavior
    {
        #region IOperationBehavior Members
        public void AddBindingParameters(OperationDescription description,
            BindingParameterCollection parameters)
        {
        }

        public void ApplyClientBehavior(OperationDescription description,
            ClientOperation proxy)
        {
            IOperationBehavior innerBehavior =
              new ReferencePreservingDataContractSerializerOperationBehavior(description);
            innerBehavior.ApplyClientBehavior(description, proxy);
        }

        public void ApplyDispatchBehavior(OperationDescription description,
            DispatchOperation dispatch)
        {
            IOperationBehavior innerBehavior =
              new ReferencePreservingDataContractSerializerOperationBehavior(description);
            innerBehavior.ApplyDispatchBehavior(description, dispatch);
        }

        public void Validate(OperationDescription description)
        {
        }

        #endregion
    }



    public class ReferencePreservingDataContractSerializerOperationBehavior :
        DataContractSerializerOperationBehavior
    {
        #region Ctor
        public ReferencePreservingDataContractSerializerOperationBehavior(
            OperationDescription operationDescription)
            : base(operationDescription) { }
        #endregion

        #region Public Methods

        public override XmlObjectSerializer CreateSerializer(Type type,
               XmlDictionaryString name, XmlDictionaryString ns,
               IList<Type> knownTypes)
        {
            return new DataContractSerializer(type, name, ns, knownTypes,
                2147483646 /*maxItemsInObjectGraph*/,
                false/*ignoreExtensionDataObject*/,
                true/*preserveObjectReferences*/,
                null/*dataContractSurrogate*/);
        }
        #endregion
    }

}
