using Application.Trainings.Commands.CreateTraining;
using Contracts.Training;
using Domain.Common.ValueObjects;
using Domain.ExerciseAggregate;
using Domain.TrainingAggregate;
using Domain.TrainingAggregate.Entities;
using Mapster;

namespace Api.Common.Mapping;

public sealed class TrainingMappingConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<(CreateTrainingRequest Req, Guid UserId), CreateTrainingCommand>()
            .Map(dest => dest, src => src.Req)
            .Map(dest => dest.UserId, src => UserId.Create(src.UserId))
            .Map(dest => dest.Sets, src => src.Req.Sets);

        config.NewConfig<CreateTrainingRequestTrainingSet, TrainingSet>()
            .Map(dest => dest, src => src)
            .Map(dest => dest.ExerciseId, src => ExerciseId.Create(src.ExerciseId));

        config.NewConfig<TrainingId, TrainingIdResponse>()
            .Map(dest => dest.Id, src => src.Value);
    }
}