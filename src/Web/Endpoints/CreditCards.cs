
using rade.expense_managment.Application.CreditCards.Commands.CreateCreditCard;
using rade.expense_managment.Application.CreditCards.Queries.GetCreditCards;

namespace rade.expense_managment.Web.Endpoints;

public class CreditCards : EndpointGroupBase
{
    public override void Map(WebApplication app)
    {
        app.MapGroup(this)
            .MapGet(GetCreditCards)
            .MapPost(CreateCreditCard);
    }
    
    public Task<int> CreateCreditCard(ISender sender, CreateCreditCardCommand command) {
        return sender.Send(command);
    }

    public Task<CreditCardsVm> GetCreditCards(ISender sender)
    {
        return sender.Send(new GetCreditCardsQuery());
    }
}
