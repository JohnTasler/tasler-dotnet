namespace Tasler.Windows.ApplicationFramework
{
    using System;

    /// <summary>Determines how dynamic menu items will be positioned.</summary>
    public enum DynamicMenuItemsPosition
    {
        /// <summary>Dynamic menu items will be added after the absolute position.</summary>
        Absolute,
        /// <summary>Dynamic menu items will be added after the relative item.</summary>
        Relative,
        /// <summary>Dynamic menu items will be added as the first item in the menu.</summary>
        First,
        /// <summary>Dynamic menu items will be added as the last item in the menu.</summary>
        Last,
    }
}
