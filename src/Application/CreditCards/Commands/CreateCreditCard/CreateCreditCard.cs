using rade.expense_managment.Application.Common.Interfaces;
using rade.expense_managment.Domain.Entities;

namespace rade.expense_managment.Application.CreditCards.Commands.CreateCreditCard;

public record CreateCreditCardCommand : IRequest<int>
{
    public int UserId { get; init; }

    public string? Title { get; init; }

    public decimal InterestRate { get; init; }

    public decimal ManagementFee { get; init; }

    public decimal Credit { get; init; }

    public int CutOffDay { get; init; }

    public int PaymentDay { get; init; }
}

public class CreateCreditCardCommandValidator : AbstractValidator<CreateCreditCardCommand>
{
    public CreateCreditCardCommandValidator()
    {
        RuleFor(r => r.Title)
            .MaximumLength(200)
            .NotEmpty();

        RuleFor(r => r.PaymentDay)
            .NotEmpty()
            .GreaterThan(0)
            .LessThan(32);

        RuleFor(r => r.InterestRate)
            .NotEmpty();
    }
}

public class CreateCreditCardCommandHandler : IRequestHandler<CreateCreditCardCommand, int>
{
    private readonly IApplicationDbContext _context;

    public CreateCreditCardCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<int> Handle(CreateCreditCardCommand request, CancellationToken cancellationToken)
    {
        var credit = new CreditCard {
            UserId = request.UserId,
            Title = request.Title,
            InterestRate = request.InterestRate,
            ManagementFee = request.ManagementFee,
            Credit = request.Credit,
            CutOffDay = request.CutOffDay,
            PaymentDay = request.PaymentDay
        };
        
        _context.CreditCards.Add(credit);
        
        await _context.SaveChangesAsync(cancellationToken);
        
        return credit.Id;
    }
}
