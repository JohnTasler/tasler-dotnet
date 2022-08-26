namespace Tasler.Windows.ApplicationFramework
{
    using System;
    using System.Drawing;
    using System.Collections;
    using System.ComponentModel;
    using System.Windows.Forms;

    /// <summary>
    /// Base class for application framework UI forms. Only forms that derive from 
    /// this type will be automatically hooked up to the rest of the application framework.
    /// </summary>
    public class UserForm : Form
    {
        /// <summary>
        /// Creates a new UserForm.
        /// </summary>
        public UserForm() 
        {
            if (UserApplicationContext.Current != null)
            {
                UserApplicationContext.Forms.Add(this);
            }
        }

        /// <summary>
        /// Overrides the <see cref="Form.OnClosed"/> method.
        /// </summary>
        /// <param name="e">Event data</param>
        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);
            if (UserApplicationContext.Current != null)
            {
                UserApplicationContext.Forms.Remove(this);
            }
        }
    }
}
