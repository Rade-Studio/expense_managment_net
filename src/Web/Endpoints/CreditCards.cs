
using rade.expense_managment.Application.CreditCards.Queries.GetCreditCards;

namespace rade.expense_managment.Web.Endpoints;

public class CreditCards : EndpointGroupBase
{
    public override void Map(WebApplication app)
    {
        app.MapGroup(this)
            .MapGet(GetCreditCards);
    }

    public Task<CreditCardsVm> GetCreditCards(ISender sender)
    {
        return sender.Send(new GetCreditCardsQuery());
    }
}
