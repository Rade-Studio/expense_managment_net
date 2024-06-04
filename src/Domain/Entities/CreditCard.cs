
namespace rade.expense_managment.Domain.Entities;

public class CreditCard : BaseAuditableEntity
{
    public int UserId { get; set; }
    
    public string? Title { get; set; }
    
    public decimal InterestRate { get; set; }
    
    public decimal ManagementFee { get; set; }
    
    public decimal Credit { get; set; }
    
    public int CutOffDay { get; set; }
    
    public int PaymentDay { get; set; }
    
    private bool _active { get; set; }
    
    public bool Active
        {
            get => _active;
            set
            {
                if (value && !_active)
                {
                    // AddDomainEvent(new TodoItemCompletedEvent(this));
                }

                _active = value;
            }
        }    
}
