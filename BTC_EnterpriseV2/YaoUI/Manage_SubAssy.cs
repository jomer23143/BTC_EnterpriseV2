namespace BTC_EnterpriseV2.YaoUI
{
    internal class Manage_SubAssy
    {

        private Button currentButton;
        private Form AForm;
        private Panel Panel_menubar;
        private Panel panel_main_display;

        public Manage_SubAssy(Panel panelMenubar, Panel panelMainContent)
        {
            this.Panel_menubar = panelMenubar;
            this.panel_main_display = panelMainContent;
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
                panel_main_display.Controls.Add(childForm);
                panel_main_display.Tag = childForm;
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
