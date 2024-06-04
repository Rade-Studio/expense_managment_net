namespace rade.expense_managment.Application.CreditCards.Queries.GetCreditCards;

public class CreditCardsVm
{
   public IList<CreditCardDto> CreditCards { get; set; } = Array.Empty<CreditCardDto>();
}
