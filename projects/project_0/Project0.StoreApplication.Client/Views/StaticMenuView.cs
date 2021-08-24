
using System.Collections.Generic;

namespace Project0.StoreApplication.Client.Views
{
    public abstract class StaticMenuView : View
    {

        public override View Run(Context context)
        {
            int choice = SelectFromMenu(PrintMenu, _actions.Count);
            return _actions[choice - 1].DoAction(context);
        }
        private List<MenuAction> _actions = null;
        public StaticMenuView() : base() { _actions = new(); }
        // TODO: This RegisterAction function works as intended, but I would like to replace this with a better/more robust solution
        // that adheres better to SOLID principles. I'm thinking to create an interface for client code that requires GetActions() or
        // something similar
        protected void RegisterAction(MenuAction action)
        {
            _actions.Add(action);
        }
        protected void ClearActions()
        {
            _actions.Clear();
        }
        protected virtual string PrintMenu()
        {
            int i = 1;
            string output = "";
            foreach (var action in _actions)
            {
                output += (i++) + " - " + action.Description + "\n";
            }
            return output;
        }
    }
}