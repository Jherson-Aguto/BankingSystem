using CSbank.Application.Models;

namespace CSbank.Application.Interfaces.Services;

public interface IDepositService
{
    Task<decimal> DepositBalance(DepositDto depositDto);
}