using Exercisetacker.Data;
using Exercisetacker.UI;
using Microsoft.Extensions.Configuration;

var builder = new ConfigurationBuilder()
    .AddUserSecrets<Program>();

var configuration = builder.Build();


var menu = new Menu();
var runApplication = true;
while(runApplication)
{
    Console.Clear();
    var choice = menu.GetMainMenu();
    switch(choice)
    {
        case "View All Sessions":
            break;
        case "Add Jogging Session":
            break;
        case "Update Jogging Session":
            break;
        case "Delete Jogging Session":
            break;
        case "Exit":
            runApplication = false;
            break;
        default:
            break;
    }
}
