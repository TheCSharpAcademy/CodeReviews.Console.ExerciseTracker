using ExerciseTrackerUI;

AppEngine app = new();

while (app.IsRunning)
{
  await app.MainMenu();
}