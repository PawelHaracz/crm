using CRM.Protobuf.Commons.V1;
using HotChocolate.Types;

namespace CRM.Personal.GraphType
{
    public class AddressType : ObjectType<StreetAddressDto>
    {
        protected override void Configure(IObjectTypeDescriptor<StreetAddressDto> descriptor)
        {
            descriptor.Field(t => t.CalculateSize()).Ignore();
            descriptor.Field(t => t.Clone()).Ignore();
            descriptor.Field(t => t.Equals(null)).Ignore();
        }
    }
}