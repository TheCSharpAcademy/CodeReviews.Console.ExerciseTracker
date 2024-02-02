using ExerciseTracker.LONCHANICK.Controllers;
using Spectre.Console;

namespace ExerciseTracker.LONCHANICK.Menu;

public class Menu : IMenu
{
    private readonly IExerciseController ExController; // = new();
    
    public Menu(IExerciseController _ExerciseController)
    {
        ExController = _ExerciseController;
    }

    public async Task MainMenu()
    {
        AnsiConsole.Status()
            .Start("Loading...", ctx =>
            {
                ctx.SpinnerStyle(Style.Parse("green"));
                Thread.Sleep(600);
            });

        bool AppIsRunningYet = true;
        while (AppIsRunningYet)
        {
            Clear();
            AnsiConsole.Write(new FigletText("Exercise-Tracker").LeftJustified().Color(Color.Blue));
            var options = new SelectionPrompt<MainMenuOptions>();

            options.AddChoices
                (
                    MainMenuOptions.StartNewSession,
                    MainMenuOptions.ShowSessions,
                    MainMenuOptions.UpdateSession,
                    MainMenuOptions.DeleteSession,
                    MainMenuOptions.Quit
                );

            var r = AnsiConsole.Prompt(options);

            switch (r)
            {
                case MainMenuOptions.StartNewSession:
                    Clear();
                    ExController.Add();
                    break;

                case MainMenuOptions.ShowSessions:
                    Clear();
                    ExController.GetAll();
                    break;

                case MainMenuOptions.UpdateSession:
                    Clear();
                    ExController.Update();
                    break;
                case MainMenuOptions.DeleteSession:
                    Clear();
                    ExController.Delete();
                    break; 
                    
                case MainMenuOptions.Quit:
                    AppIsRunningYet = false;
                    break;
            }
        }

    }
}

 public interface IMenu
 {
     Task MainMenu();
 }

public enum MainMenuOptions
{
	StartNewSession,
    ShowSessions,
    UpdateSession,
    DeleteSession,
	Quit,
}

 
