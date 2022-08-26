namespace Tasler.Windows.ApplicationFramework
{
    using System;

    /// <summary>Determines what kind of dynamic menu items will be added.</summary>
    public enum DynamicMenuItems
    {
        /// <summary>Dynamic menu items will be determined from the <see cref="UserApplicationContext.Forms"/></summary>
        FormsCollection,
        /// <summary>Dynamic menu items will be determined from the list of MDI children.</summary>
        MdiChildren,
        /// <summary>Dynamic menu items will be determined from the <see cref="UserMenuItem.DynamicMenuItemPopulate"/></summary>
        Custom,
        /// <summary>No dynamic menu items will be displayed.</summary>
        None,
    }
}
