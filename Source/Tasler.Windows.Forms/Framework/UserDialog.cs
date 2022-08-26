namespace Tasler.Windows.ApplicationFramework
{
    using System;
    using System.Drawing;
    using System.Collections;
    using System.ComponentModel;
    using System.Windows.Forms;

    /// <summary>
    /// Base type for modal dialogs.
    /// </summary>
    public class UserDialog : UserForm
    {
        /// <summary>
        /// Creates a new modal dialog.
        /// </summary>
        public UserDialog() 
        {
            InitializeComponent();
        }

        #region Metadata overrides
        /// <summary>
        /// Provides new metadata for the <see cref="Form.FormBorderStyle"/> property.
        /// </summary>
        [DefaultValue(FormBorderStyle.FixedDialog)]
        public new FormBorderStyle FormBorderStyle
        {
            get 
            {
                return base.FormBorderStyle;
            }
            set
            {
                base.FormBorderStyle = value;
            }
        }

        /// <summary>
        /// Provides new metadata for the <see cref="Form.MaximizeBox"/> property.
        /// </summary>
        [DefaultValue(false)]
        public new bool MaximizeBox
        {
            get 
            {
                return base.MaximizeBox;
            }
            set
            {
                base.MaximizeBox= value;
            }
        }

        /// <summary>
        /// Provides new metadata for the <see cref="Form.MinimizeBox"/> property.
        /// </summary>
        [DefaultValue(false)]
        public new bool MinimizeBox
        {
            get 
            {
                return base.MinimizeBox;
            }
            set
            {
                base.MinimizeBox = value;
            }
        }

        /// <summary>
        /// Provides new metadata for the <see cref="Form.StartPosition"/> property.
        /// </summary>
        [DefaultValue(FormStartPosition.CenterParent)]
        public new FormStartPosition StartPosition
        {
            get 
            {
                return base.StartPosition;
            }
            set
            {
                base.StartPosition = value;
            }
        }
        #endregion

        private void InitializeComponent()
        {
            // 
            // UserDialog
            // 
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "UserDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
        }
    }
}
