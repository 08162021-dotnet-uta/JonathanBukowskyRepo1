
using System.Collections.Generic;

namespace Project0.StoreApplication.Client.Views.Common
{
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
        /// Return false to repeat prompt and gather new input.
        /// </summary>
        /// <param name="input">User's input</param>
        /// <returns>True if input successfully passes validation</returns>
        bool HandleUserInput(string input);

        /// <summary>
        /// Get the next view to be run. Return `this` to re-run current menu.
        /// </summary>
        /// <value>Next IView object to be executed</value>
        IView NextView { get; }

        /// <summary>
        /// Return a string that will prompt the user for input.
        /// </summary>
        /// <returns></returns>
        string GetPrompt();
    }
}