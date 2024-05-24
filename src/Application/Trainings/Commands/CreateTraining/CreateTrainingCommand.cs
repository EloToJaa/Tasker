using Domain.Common.ValueObjects;
using Domain.TrainingAggregate;
using Domain.TrainingAggregate.Entities;
using ErrorOr;
using MediatR;

namespace Application.Trainings.Commands.CreateTraining;

public record CreateTrainingCommand(
    string Name,
    string Description,
    UserId UserId,
    List<TrainingSet> Sets
) : IRequest<ErrorOr<TrainingId>>;