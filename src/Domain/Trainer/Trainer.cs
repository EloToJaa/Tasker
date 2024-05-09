using Domain.Common.Models;
using Domain.User;

namespace Domain.Trainer;

public sealed class Trainer : AggregateRoot<TrainerId, Guid>
{
    private readonly List<UserId> _users = new();
    public IReadOnlyList<UserId> Users => _users.AsReadOnly();

    private Trainer(TrainerId id) : base(id, id.Value)
    {
    }

    public static Trainer Create(Guid trainerId)
    {
        return new Trainer(TrainerId.Create(trainerId));
    }

    public void AddUser(UserId userId, Guid updatedBy)
    {
        base.Update(updatedBy);
        _users.Add(userId);
    }

    public void RemoveUser(UserId userId, Guid updatedBy)
    {
        base.Update(updatedBy);
        _users.Remove(userId);
    }
}