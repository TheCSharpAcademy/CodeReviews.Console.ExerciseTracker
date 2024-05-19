namespace ExerciseTracker.Cactus.Model
{
    public class Exercise
    {
        public int Id { get; set; }
        public DateTime DateStart { get; set; }
        public DateTime DateEnd { get; set; }
        public TimeSpan Duration { get; set; }
        public string Comments { get; set; }

        public Exercise(DateTime dateStart, DateTime dateEnd, TimeSpan duration, string comments)
        {
            DateStart = dateStart;
            DateEnd = dateEnd;
            Duration = duration;
            Comments = comments;
        }
    }
}
