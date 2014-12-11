using System;
using System.Collections.Generic;
using System.Text;

namespace ITHelper
{
    /// <summary>
    /// 
    /// </summary>
    public class ParseMessageEventArgs : System.EventArgs
    {
        private string m_MessageHeader;
        private string m_MessageText;
        private string m_ParseSource;
        private ParseMessageType m_Type = ParseMessageType.None;

        public ParseMessageEventArgs()
            : base()
        { }

        public ParseMessageEventArgs(ParseMessageType type, string MessageHeader, string MessageText)
            : this()
        {
            m_MessageHeader = MessageHeader;
            m_MessageText = MessageText;
            m_Type = type;
        }

        public ParseMessageEventArgs(ParseMessageType type, string LineHeader, string MessageText, string Source)
            : this(type, LineHeader, MessageText)
        {
            m_ParseSource = Source;
        }

        public string MessageText
        {
            get { return m_MessageText; }
            set { m_MessageText = value; }
        }

        public string Source
        {
            get { return m_ParseSource; }
            set { m_ParseSource = value; }
        }

        public string LineHeader
        {
            get { return m_MessageHeader; }
            set { m_MessageHeader = value; }
        }

        public ParseMessageType MessageType
        {
            get { return m_Type; }
            set { m_Type = value; }
        }
    }

    public enum ParseMessageType { None = -1, Info = 0, Warning = 1, Error = 2, Question = 3 };
}
