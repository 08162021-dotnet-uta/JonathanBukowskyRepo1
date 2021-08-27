
using System.Collections.Generic;

namespace Project0.StoreApplication.Client.Views.Common
{
    /// <summary>
    /// Actions available to a View upon receiving user input
    /// </summary>
    public enum Actions
    {
        /// <summary>
        /// Instructs caller to repeat prompt and input collection
        /// </summary>
        REPEAT_PROMPT = 0,
        /// <summary>
        /// Instructs caller to end current view's execution
        /// </summary>
        CLOSE_MENU,
        /// <summary>
        /// Instructs caller to execute nextView and return to this view
        /// </summary>
        OPEN_SUBMENU,
        /// <summary>
        /// Instructs caller to execute nextView instead of this view
        /// </summary>
        CHANGE_MENU,
        /// <summary>
        /// Instructs caller to continue executing current view
        /// </summary>
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