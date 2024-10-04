namespace ExerciseTracker;

public class ExerciseRepositoryEf(ExerciseContext context) : EntityFrameworkRepository<Exercise>(context)
{
}