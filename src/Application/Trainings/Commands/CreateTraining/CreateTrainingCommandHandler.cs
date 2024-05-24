using Domain.TrainingAggregate;
using ErrorOr;
using MediatR;

namespace Application.Trainings.Commands.CreateTraining;

public class CreateTrainingCommandHandler : IRequestHandler<CreateTrainingCommand, ErrorOr<TrainingId>>
{
    public async Task<ErrorOr<TrainingId>> Handle(CreateTrainingCommand request, CancellationToken cancellationToken)
    {
        var result = Training.Create(request.Name, request.Description, request.UserId, request.Sets);

        if (result is null) return Error.Failure(
            code: "Training.CannotCreate",
            description: "Cannot create training"
        );

        await Task.CompletedTask;
        return TrainingId.CreateUnique();
    }
}
