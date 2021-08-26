
using System.Collections.Generic;

namespace Project0.StoreApplication.Client.Views.Common
{
    public enum Actions
    {
        REPEAT_PROMPT = 0,
        CLOSE_MENU,
        OPEN_SUBMENU,
        CHANGE_MENU,
        RERUN_MENU
    }
    public interface IView
    {
        /// <summary>
        /// Set the user context for the view
        /// </summary>
        /// <param name="context">Current user context</param>
        void SetContext(Context context);

        /// <summary>
        /// Return a list of the menu options for this view
        /// </summary>
        /// <returns>List of string (menu options)</returns>
        List<string> GetMenuOptions();

        /// <summary>
        /// Perform action based on user input.
        /// Return enum value to indicate next action
        /// </summary>
        /// <param name="input">User's input</param>
        /// <returns>Next action to perform</returns>
        Actions HandleUserInput(string input, out IView nextView);

        /// <summary>
        /// Return a string that will prompt the user for input.
        /// </summary>
        /// <returns></returns>
        string GetPrompt();
    }
}