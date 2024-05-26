namespace Contracts.Training;

public record CreateTrainingRequest(
    string Name,
    string Description,
    List<CreateTrainingRequestTrainingSet> Sets
);

public record CreateTrainingRequestTrainingSet(
    string Description,
    int Repetitions,
    int Time,
    Guid ExerciseId
);