using Domain.Common.Models;
using Domain.Common.ValueObjects;

namespace Domain.Trainer;

public sealed class Trainer : AggregateRoot<UserId, Guid>
{
    private readonly List<UserId> _pupils = new();
    public IReadOnlyList<UserId> Pupils => _pupils.AsReadOnly();

    private Trainer(UserId trainerId) : base(trainerId, trainerId)
    {
    }

    public static Trainer Create(UserId trainerId)
    {
        return new Trainer(trainerId);
    }

    public void AddUser(UserId userId, UserId updatedBy)
    {
        base.Update(updatedBy);
        _pupils.Add(userId);
    }

    public void RemoveUser(UserId userId, UserId updatedBy)
    {
        base.Update(updatedBy);
        _pupils.Remove(userId);
    }
}