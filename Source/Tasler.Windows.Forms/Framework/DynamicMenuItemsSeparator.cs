namespace Tasler.Windows.ApplicationFramework
{
    using System;

    /// <summary>Determines where separators will be placed when dynamic menu items are added.</summary>
    public enum DynamicMenuItemsSeparator
    {
        /// <summary>No separators will be added.</summary>
        None,
        /// <summary>Separators will be added before the dynamic menu items.</summary>
        Before,
        /// <summary>Separators will be added after the dynamic menu items.</summary>
        After,
        /// <summary>Separators will be added both before and after the dynamic menu items.</summary>
        Both,
    }
}
