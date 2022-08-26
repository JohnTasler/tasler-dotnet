namespace Tasler.Windows.ApplicationFramework
{
    using System;
    using System.Collections;
    using System.ComponentModel;
    using System.Windows.Forms;

    /// <summary>Event data for the <see cref="UserMenuItem.DynamicMenuItemPopulate"/> event.</summary>
    public class DynamicMenuItemPopulateEventArgs : EventArgs
    {
        ICollection m_dynamicMenuItems;

        /// <summary>Creates a new DynamicMenuItemPopulateEventArgs</summary>
        public DynamicMenuItemPopulateEventArgs()
        {
        }
        /// <summary>
        /// The handler of the event should assign a collection of objects deriving
        /// from <see cref="DynamicMenuItem"/> to this property.
        /// </summary>
        public ICollection DynamicMenuItems
        {
            get 
            {
                return m_dynamicMenuItems;
            }
            set 
            {
                m_dynamicMenuItems = value;
            }
        }
    }

    /// <summary>
    /// Represents the method that will handle the <see cref="UserMenuItem.DynamicMenuItemPopulate"/> event.
    /// </summary>
    public delegate void DynamicMenuItemPopulateEventHandler(object sender, DynamicMenuItemPopulateEventArgs e);
}
