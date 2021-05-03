using AutoMapper;

namespace rs_service.Application.Interfaces.Mapping
{
    // Any class with a custom mapping (for AutoMapper) must implement
    // this interface because MapperProfileHelper class uses this interface
    // on runtime and at service start to configure all mapping in the assembly
    public interface IHaveCustomMapping
    {
        void CreateMappings(Profile configuration);
    }
}
