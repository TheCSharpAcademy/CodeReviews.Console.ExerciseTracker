using Exercisetacker.Repositories;
using Exercisetacker.Services.Interfaces;

namespace Exercisetacker.Services;

public class JoggingService : JoggingServiceInterface
{
    private readonly JoggingRepository _joggingRepository;

    public JoggingService(JoggingRepository joggingRepository)
    {
        _joggingRepository = joggingRepository;
    }
}