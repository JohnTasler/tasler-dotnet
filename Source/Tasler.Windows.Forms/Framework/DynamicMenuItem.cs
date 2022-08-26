namespace Tasler.Windows.ApplicationFramework
{
    using System;
    using System.Collections;
    using System.ComponentModel;
    using System.Windows.Forms;

    /// <summary>
    /// Base class for menu data for dynamic menu items.
    /// </summary>
    public abstract class DynamicMenuItem
    {
        /// <summary>
        /// Determines the text to be displayed for the item.
        /// <seealso cref="MenuItem.Text"/>
        /// </summary>
        public abstract string Text { get; }
        /// <summary>
        /// Determines the check state of the item.
        /// <seealso cref="MenuItem.Checked"/>
        /// </summary>
        public virtual bool Checked { get { return false; } }
        /// <summary>
        /// Determines if the item is enabled.
        /// <seealso cref="MenuItem.Enabled"/>
        /// </summary>
        public virtual bool Enabled { get { return true; } }
        /// <summary>
        /// Determines the action to occur when the user clicks this item.
        /// <seealso cref="MenuItem.Click"/>
        /// </summary>
        public abstract void PerformClick();
    }
}
