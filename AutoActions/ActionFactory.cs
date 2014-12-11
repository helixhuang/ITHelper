using System;
using System.Collections.Generic;
using System.Reflection;
using System.Xml;

namespace cn.antontech.ITHelper.AutoActions
{
    public class ActionFactory
    {
        public static BaseAction GetAction(XmlElement node)
        {
            string actionType = node.Name;
            Assembly asm = typeof(ActionFactory).Assembly;
            Type t = asm.GetType(string.Format("cn.antontech.ITHelper.AutoActions.{0}Action", actionType));
            return Activator.CreateInstance(t, node) as BaseAction;
        }
    }
}
