using Domain.Training;

namespace Application.Common.Interfaces.Persistance;

public interface ITrainingRepository
{
    Task<Training?> GetTrainingByIdAsync(Guid id);
    Task AddTrainingAsync(Training training);
    void DeleteTraining(Training training);
}