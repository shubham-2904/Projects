using AutoMapper;
using Entities;
using Shared.DTOs;

namespace Person_Api.Mapping {
    public class MappingProfile : Profile {
        public MappingProfile() {
            // Mapping rule for DTOPerson -> Person
            CreateMap<DTOPerson, Person>();

            // Mapping rule for Person => DTOPerson
            CreateMap<Person, DTOPerson>();
        }
    }
}
