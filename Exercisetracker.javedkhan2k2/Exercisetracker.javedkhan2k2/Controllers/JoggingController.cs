using Exercisetacker.Services;

namespace Exercisetacker.Controllers;

public class JoggingController
{
    private readonly JoggingService _joggingService;

    public JoggingController(JoggingService joggingService)
    {
        _joggingService = joggingService;
    }
}