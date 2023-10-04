namespace ExerciseTracker.Forser.UI
{
    public class UserInterface : IUserInterface
    {
        public DateTime GetEndTime(DateTime startTime)
        {
            throw new NotImplementedException();
        }
        public int GetExerciseId()
        {
            throw new NotImplementedException();
        }
        public string GetExerciseOption()
        {
            throw new NotImplementedException();
        }
        public DateTime GetStartTime()
        {
            throw new NotImplementedException();
        }
        public static void DisplayExerciseTable(List<Exercise> exercises)
        {
            Table table = new Table();
            table.Expand();
            table.AddColumns("Date Started","Date Ended","Duration","Comments");

            foreach (Exercise exercise in exercises)
            {
                table.AddRow($"{exercise.DateStart}", $"{exercise.DateEnd}",$"{exercise.Duration}", $"{exercise.Comments}");
            }

            AnsiConsole.Write(table);
            AnsiConsole.WriteLine("Press any key to return to main menu");
            Console.ReadLine();
        }
    }
}