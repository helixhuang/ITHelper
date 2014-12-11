using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace ITHelper
{
    /// <summary>
    /// EventHanlder for adding items.
    /// </summary>
    public delegate void AddedEventHandler();

    /// <summary>
    /// EventHandler for inserting items.
    /// </summary>
    public delegate void InsertEventHandler(int index);

    /// <summary>
    /// ArrayList with OnItemInserted event.
    /// </summary>
    public class ListBoxList
    {
        /// <summary>
        /// Internal messages list.
        /// </summary>
        private ArrayList _alMessages;

        /// <summary>
        /// Internal information about the messages.
        /// </summary>
        private ArrayList _alMessagesInfo;

        /// <summary>
        /// Number of items in the list.
        /// </summary>
        /// <returns></returns>
        public int Count
        {
            get { return _alMessages.Count; }
        }


        /// <summary>
        /// Item at index.
        /// </summary>
        public ParseMessageEventArgs this[int index]
        {
            get { return (ParseMessageEventArgs)_alMessages[index]; }
        }


        /// <summary>
        /// Item has been added.
        /// </summary>
        public event AddedEventHandler OnItemAdded;

        /// <summary>
        /// Item has been inserted.
        /// </summary>
        public event InsertEventHandler OnItemInserted;

        /// <summary>
        /// Constructor.
        /// </summary>
        public ListBoxList()
        {
            _alMessages = new ArrayList();
            _alMessagesInfo = new ArrayList();
        }


        /// <summary>
        /// Add an item.
        /// </summary>
        /// <param name="pmea"></param>
        /// <returns></returns>
        public int Add(ParseMessageEventArgs pmea)
        {
            int index = _alMessages.Add(pmea);
            _alMessagesInfo.Add(new ItemInfo(pmea));
            OnAdd();
            return index;
        }


        /// <summary>
        /// Clears the list.
        /// </summary>
        public void Clear()
        {
            _alMessages.Clear();
            _alMessagesInfo.Clear();
        }


        /// <summary>
        /// Index of the object.
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public int IndexOf(object obj)
        {
            return _alMessages.IndexOf(obj);
        }


        /// <summary>
        /// Index of the item.
        /// </summary>
        /// <param name="pmea"></param>
        /// <returns></returns>
        public int IndexOf(ParseMessageEventArgs pmea)
        {
            return _alMessages.IndexOf(pmea);
        }


        /// <summary>
        /// Returns more information (ItemInfo object) about an item.
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public ItemInfo Info(int index)
        {
            return (ItemInfo)_alMessagesInfo[index];
        }


        /// <summary>
        /// Insert an item.
        /// </summary>
        /// <param name="index"></param>
        /// <param name="pmea"></param>
        public void Insert(int index, ParseMessageEventArgs pmea)
        {
            _alMessages.Insert(index, pmea);
            _alMessagesInfo.Insert(index, new ItemInfo(pmea));
            OnInsert(index);
        }


        /// <summary>
        /// Raises the 'OnItemAdded' event.
        /// </summary>
        private void OnAdd()
        {
            if (OnItemAdded != null)
                OnItemAdded();
        }


        /// <summary>
        /// Raises the 'OnItemInserted' event.
        /// </summary>
        /// <param name="index"></param>
        private void OnInsert(int index)
        {
            if (OnItemInserted != null)
                OnItemInserted(index);
        }

    }
}
