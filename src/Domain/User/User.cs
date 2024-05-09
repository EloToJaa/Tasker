using Domain.Common.Models;
using Domain.Trainer;

namespace Domain.User;

public sealed class User : AggregateRoot<UserId, Guid>
{
    public TrainerId TrainerId { get; set; }

    public User(UserId id, TrainerId trainerId) : base(id, id.Value)
    {
        TrainerId = trainerId;
    }

    public static User Create(Guid userId, TrainerId trainerId)
    {
        return new User(UserId.Create(userId), trainerId);
    }

    public void Update(TrainerId trainerId, Guid userId)
    {
        base.Update(userId);

        TrainerId = trainerId;
    }
}