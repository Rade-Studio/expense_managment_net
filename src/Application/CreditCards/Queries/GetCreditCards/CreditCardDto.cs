using rade.expense_managment.Domain.Entities;

namespace rade.expense_managment.Application.CreditCards.Queries.GetCreditCards;

public class CreditCardDto
{
    public int Id { get; init; }
     
    public int UserId { get; init; }
    
    public string? Title { get; init; }
    
    public decimal InterestRate { get; init; }
    
    public decimal ManagementFee { get; init; }
    
    public decimal Credit { get; init; }
    
    public int CutOffDay { get; init; }
    
    public int PaymentDay { get; init; }
    
    private class Mapping : Profile 
    {
        public Mapping() 
        {
            CreateMap<CreditCard, CreditCardDto>();
        }
    }
}
