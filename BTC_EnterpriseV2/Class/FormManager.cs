namespace BTCP_EnterpriseV2.Class
{
    public class FormManager
    {
        private Button currentButton;
        private Form AForm;
        private Panel Panel_menubar;
        private Panel Panel_main_content;

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
        public FormManager(Panel panelMenubar, Panel panelMainContent)
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
        {
            this.Panel_menubar = panelMenubar;
            this.Panel_main_content = panelMainContent;
        }

        #region Button Activation
        public void ActivateButton(object btnSender)
        {
            if (btnSender != null && btnSender is Button)
            {
                Button senderButton = (Button)btnSender;
                if (currentButton == null || currentButton.Name != senderButton.Name)
                {
                    DisableButton();
                    currentButton = senderButton;
                    currentButton.ForeColor = Color.White;
                    currentButton.Font = new Font("Arial Narrow Bold", 8.0F, FontStyle.Bold, GraphicsUnit.Point, (byte)0);
                    // currentButton.BackColor = Color.Wheat;
                }
            }
        }

        private void DisableButton()
        {
            foreach (Control previousBtn in Panel_menubar.Controls)
            {
                if (previousBtn is Button)
                {
                    previousBtn.ForeColor = Color.DarkGray;
                    // previousBtn.BackColor = Color.White;
                    previousBtn.Font = new Font("Arial Narrow Bold", 8.0F, FontStyle.Bold, GraphicsUnit.Point, (byte)0);
                }
            }
        }
        #endregion

        #region Child Form Management
        public void OpenChildForm(Form childForm, object btnSender)
        {
            try
            {
                if (AForm != null) AForm.Close();
                ActivateButton(btnSender);
                AForm = childForm;
                childForm.TopLevel = false;
                childForm.FormBorderStyle = FormBorderStyle.None;
                childForm.Dock = DockStyle.Fill;
                Panel_main_content.Controls.Add(childForm);
                Panel_main_content.Tag = childForm;
                childForm.BringToFront();
                childForm.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error opening form: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void Reset()
        {
            DisableButton();
            currentButton = new Button();
        }

        public void closeAForm()
        {

            if (AForm != null)
            {
                AForm.Close();
            }
            Reset();
        }
        #endregion






    }
}
