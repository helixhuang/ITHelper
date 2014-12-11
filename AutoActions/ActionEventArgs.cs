using System;
using System.Collections.Generic;

namespace cn.antontech.ITHelper.AutoActions
{
    public class ActionEventArgs : EventArgs
    {
        public ActionEventArgs(string message)
            : this(ActionEventType.Info, message)
        {
        }
        public ActionEventArgs(ActionEventType type, string message)
        {
            this.EventType = type;
            this.Message = message;
        }
        public string Message { get; set; }
        public ActionEventType EventType { get; set; }
    }

    public enum ActionEventType { 
        None = -1, 
        Info = 0, 
        Warning = 1, 
        Error = 2, 
        Question = 3 
    };
}
