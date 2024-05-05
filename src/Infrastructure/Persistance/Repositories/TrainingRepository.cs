using Application.Common.Interfaces.Persistance;
using Domain.Training;

namespace Infrastructure.Persistance.Repositories;

public sealed class TrainingRepository : ITrainingRepository
{
    private readonly ApplicationDbContext _context;

    public TrainingRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Training?> GetTrainingByIdAsync(Guid id)
    {
        return await _context.Trainings.FindAsync(id);
    }

    public async Task AddTrainingAsync(Training training)
    {
        await _context.Trainings.AddAsync(training);
    }

    public void DeleteTraining(Training training)
    {
        _context.Trainings.Remove(training);
    }
}