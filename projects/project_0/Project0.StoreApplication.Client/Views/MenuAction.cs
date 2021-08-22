
using System;

namespace Project0.StoreApplication.Client.Views
{
    public class MenuAction
    {
        public string Description { get; set; }
        public Func<Context, View> DoAction { get; set; }
    }
}