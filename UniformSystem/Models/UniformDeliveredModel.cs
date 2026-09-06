using Microsoft.EntityFrameworkCore;

namespace UniformSystem.Models;

public class UniformDelivered
{
    public int Id { get; init; }
    public required int UniformId { get; init; }
    public required int ToEmployeeId  { get; init; }
    public required int DeliveredById  { get; init; }
    public required DateTime DeliveredAt { get; init; }
    public required int Amount { get; init; }
    
    public required Uniform Uniform { get; init; }
    public required User DeliveredBy { get; init; }
    public required Employee ToEmployee { get; init; }
    
}