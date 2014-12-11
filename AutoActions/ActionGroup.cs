﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace cn.antontech.ITHelper.AutoActions
{
    public class ActionGroup
    {
        public ActionGroup(XmlElement node)
        {
            this.Name = node.Attributes["Name"].Value;
            this.ActionList = new List<XmlElement>();
            foreach (XmlNode actionNode in node.ChildNodes)
            {
                if (actionNode is XmlElement)
                {
                    XmlElement actionElement = actionNode as XmlElement;
                    this.ActionList.Add(actionElement);
                }
            }
        }
        public string Name { get; set; }
        public List<XmlElement> ActionList { get; set; }
    }
}
