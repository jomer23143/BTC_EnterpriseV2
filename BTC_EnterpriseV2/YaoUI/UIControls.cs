using BTCP_EnterpriseV2.Forms;

namespace BTCP_EnterpriseV2.YaoUI
{
    public static class UIControls
    {

        public static void SetupUI(MainDashboard form, EventHandler settingHandler, EventHandler logoutHandler)
        {
            // 1. Configure basic form appearance: no border, centered start, maximized window.
            form.FormBorderStyle = FormBorderStyle.None;
            form.StartPosition = FormStartPosition.CenterScreen;
            form.WindowState = FormWindowState.Maximized;

            // 2. Align the time and date labels (centering their text for consistent layout).
            form.lbl_time.TextAlign = ContentAlignment.MiddleCenter;
            form.lbl_currentdate.TextAlign = ContentAlignment.MiddleCenter;

            // 3. Initialize and start the timer to update time and date labels.
            //    The Tick event handler updates the labels each second.
            form.timer1.Tick += (sender, args) =>
            {
                form.lbl_time.Text = DateTime.Now.ToString("hh:mm:ss tt");
                form.lbl_currentdate.Text = DateTime.Now.ToString("dddd, MMMM dd yyyy");
            };
            form.timer1.Start();

            // 4. Create a context menu with items (e.g., "Settings" and "Logout").
            var contextMenu = new ContextMenuStrip();

            // Create "Settings" menu item
            var settingsItem = new ToolStripMenuItem("Settings", null, settingHandler)
            {
                BackColor = Color.LightBlue,
                ForeColor = Color.Black
            };

            // Create "Logout" menu item
            var logoutItem = new ToolStripMenuItem("Logout", null, logoutHandler)
            {
                BackColor = Color.Red,
                ForeColor = Color.White
            };

            // Add items to context menu
            contextMenu.Items.Add(settingsItem);
            contextMenu.Items.Add(logoutItem);

            // Show the context menu when the settings image is clicked.
            form.settingimage.Click += (sender, args) =>
            {
                contextMenu.Show(form.settingimage, new Point(0, form.settingimage.Height));
            };

            // 5. Apply rounded corners to panel1 using the YaoUI utility.
            var yui = new YaoUI.YUI();
            yui.RoundedPanelDocker(form.panel_sidebar, 10);
            yui.RoundedPanelDocker(form.panel_main_display, 10);
            yui.RoundedPanelDocker(form.panel_chart, 10);
        }



    }
}
