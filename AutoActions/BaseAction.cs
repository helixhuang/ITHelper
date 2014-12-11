using System;
using System.Collections.Generic;

namespace cn.antontech.ITHelper.AutoActions
{
    public abstract class BaseAction:IAction
    {
        public event EventHandler<ActionEventArgs> Notify;
        public abstract void Exec();
        protected void OnNotify(string message)
        {
            if (Notify != null)
            {
                Notify(this, new ActionEventArgs(message));
            }
        }
    }
}
