using rade.expense_managment.Application.Common.Interfaces;

namespace rade.expense_managment.Application.CreditCards.Queries.GetCreditCards;

public record GetCreditCardsQuery : IRequest<CreditCardsVm>
{
}

public class GetCreditCardsQueryValidator : AbstractValidator<GetCreditCardsQuery>
{
    public GetCreditCardsQueryValidator()
    {
    }
}

public class GetCreditCardsQueryHandler : IRequestHandler<GetCreditCardsQuery, CreditCardsVm>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetCreditCardsQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<CreditCardsVm> Handle(GetCreditCardsQuery request, CancellationToken cancellationToken)
    {
        return new CreditCardsVm
        {
            CreditCards = await _context.CreditCards
                .ProjectTo<CreditCardDto>(_mapper.ConfigurationProvider)
                .OrderBy(t => t.Title)
                .ToListAsync(cancellationToken)
        };
    }
}
