using CSbank.Domain.Request;
using CSBank.Application.Models;

namespace CSBank.Application.Mapper;

public static class CustomerMapper
{
    public static CustomerRequest MapToDomain(this CustomerDto dto) =>
        new(dto.Id, dto.FirstName, dto.LastName,
        dto.Suffix, dto.RegistrationDate, dto.MiddleInitial);

    public static CustomerDto MapToDto(this CustomerRequest dto) =>
        new(dto.Id, dto.FirstName, dto.LastName,
        dto.Suffix, dto.RegistrationDate, dto.MiddleInitial);
}