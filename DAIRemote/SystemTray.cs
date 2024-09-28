﻿using System;
using System.Drawing;
using System.Windows.Forms;

namespace DAIRemote
{
    public class TrayIconManager
    {
        private NotifyIcon trayIcon;
        private ContextMenuStrip trayMenu;
        private Form form;

        public TrayIconManager(Form form)
        {
            this.form = form;
            InitializeTrayIcon();
        }

        private void InitializeTrayIcon()
        {
            // Create a ContextMenuStrip
            trayMenu = new ContextMenuStrip();
            trayMenu.Items.Add("Show", null, OnShow);
            trayMenu.Items.Add("Exit", null, OnExit);

            // Set custom icon from Resources folder
            trayIcon = new NotifyIcon
            {
                Text = "DAIRemote",
                Icon = new Icon("Resources/SystemTrayIcon.ico"), // Use your custom icon
                ContextMenuStrip = trayMenu,
                Visible = true
            };

            // Handle double-click to open the application
            trayIcon.DoubleClick += (s, e) => ShowForm();
        }

        public void HideIcon()
        {
            trayIcon.Visible = false; // Hide tray icon
        }

        public void ShowIcon()
        {
            trayIcon.Visible = true; // Show tray icon
        }

        private void OnShow(object sender, EventArgs e)
        {
            ShowForm();
        }

        private void ShowForm()
        {
            form.Show(); // Show the form
            form.WindowState = FormWindowState.Normal; // Restore if minimized
            form.Activate(); // Bring to front
        }

        private void OnExit(object sender, EventArgs e)
        {
            HideIcon();
            Application.Exit(); // Exit the application
        }
    }
}