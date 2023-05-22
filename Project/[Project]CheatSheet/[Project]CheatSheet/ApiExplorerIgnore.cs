namespace _Project_CheatSheet
{
    using Microsoft.AspNetCore.Mvc.ApplicationModels;

    public class ApiExplorerIgnore : IActionModelConvention
    {
        public void Apply(ActionModel action)
        {
            if (action.Controller.ControllerName.Equals("Pwa"))
            {
                action.ApiExplorer.IsVisible = false;
            }
        }
    }
}