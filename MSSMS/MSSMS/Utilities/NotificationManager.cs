using MSSMS.Enums;
using MSSMS.Properties;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MSSMS.Utilities
{
    public class NotificationManager
    {

        public static void showInAppNotification(Panel inAppNotificationContainer, Label inAppNotificationMessage, PictureBox inAppNotificationIcon, String notification, NotificationStates notificationState)
        {

            inAppNotificationIcon.Image = null;
            if (notification != null)
            {

                if (notificationState == NotificationStates.WARNING)
                {
                    inAppNotificationContainer.Visible = true;
                    inAppNotificationIcon.BackgroundImage = Resources.warnC;
                    inAppNotificationIcon.BackgroundImageLayout = ImageLayout.Zoom;
                    inAppNotificationContainer.BackColor = Color.FromArgb(245, 124, 0);
                }
                else if (notificationState == NotificationStates.ERROR)
                {
                    inAppNotificationContainer.Visible = true;
                    inAppNotificationIcon.BackgroundImage = Resources.closeC;
                    inAppNotificationIcon.BackgroundImageLayout = ImageLayout.Zoom;
                    inAppNotificationContainer.BackColor = Color.FromArgb(192, 57, 43);
                }
                else if (notificationState == NotificationStates.SUCCESS)
                {
                    inAppNotificationContainer.Visible = true;
                    inAppNotificationIcon.BackgroundImage = Resources.tickC;
                    inAppNotificationIcon.BackgroundImageLayout = ImageLayout.Zoom;
                    inAppNotificationContainer.BackColor = Color.FromArgb(67, 160, 71);
                }
                else if (notificationState == NotificationStates.INFORMATION)
                {
                    inAppNotificationContainer.Visible = true;
                    inAppNotificationIcon.BackgroundImage = Resources.infoC;
                    inAppNotificationIcon.BackgroundImageLayout = ImageLayout.Zoom;
                    inAppNotificationContainer.BackColor = Color.FromArgb(25, 118, 210);
                }
                else
                {
                    inAppNotificationContainer.Visible = false;
                }

                inAppNotificationMessage.Text = notification;
                inAppNotificationMessage.ForeColor = Color.White;
            }
            else
            {
                inAppNotificationContainer.Visible = false;
            }
        }

        public static void showInAppNotification(Panel inAppNotificationContainer, Label inAppNotificationMessage, PictureBox inAppNotificationIcon, Button closeButton, String notification, NotificationStates notificationState)
        {
            closeButton.FlatAppearance.MouseDownBackColor = Color.Black;
            if (notification != null)
            {
                showInAppNotification(inAppNotificationContainer, inAppNotificationMessage, inAppNotificationIcon, notification, notificationState);

                if (notificationState == NotificationStates.WARNING)
                {
                    closeButton.BackColor = Color.FromArgb(255, 179, 0);
                    closeButton.FlatAppearance.MouseOverBackColor = Color.FromArgb(224, 170, 40);
                }
                else if (notificationState == NotificationStates.ERROR)
                {
                    closeButton.BackColor = Color.FromArgb(231, 76, 60);
                    closeButton.FlatAppearance.MouseOverBackColor = Color.FromArgb(199, 69, 56);
                }
                else if (notificationState == NotificationStates.SUCCESS)
                {
                    closeButton.BackColor = Color.FromArgb(76, 175, 80);
                    closeButton.FlatAppearance.MouseOverBackColor = Color.FromArgb(77, 150, 80);
                }
                else if (notificationState == NotificationStates.INFORMATION)
                {
                    closeButton.BackColor = Color.FromArgb(2, 136, 209);
                    closeButton.FlatAppearance.MouseOverBackColor = Color.FromArgb(16, 118, 173);
                }
                else
                {
                    inAppNotificationContainer.Visible = false;
                }

                inAppNotificationMessage.Text = notification;

            }
            else
            {
                inAppNotificationContainer.Visible = false;
            }
        }

        public static void hideInAppNotification(Panel inAppNotificationContainer)
        {
            inAppNotificationContainer.Hide();
        }

        public static void showLoader (Panel inAppNotificationContainer, Label inAppNotificationMessage, PictureBox inAppNotificationIcon, String notification)
        {
            inAppNotificationContainer.Visible = true;
            inAppNotificationContainer.BackColor = Color.FromArgb(0,8,30);
            inAppNotificationIcon.BackgroundImage = null;
            inAppNotificationIcon.BackgroundImageLayout = ImageLayout.Zoom;
            inAppNotificationIcon.Image = Resources.loadersq;
            inAppNotificationIcon.SizeMode = PictureBoxSizeMode.Zoom;
            inAppNotificationMessage.Text = notification;
        }

        public static void showLoader(Panel inAppNotificationContainer, Label inAppNotificationMessage, PictureBox inAppNotificationIcon, Button inAppNotificationCloseButton, String notification)
        {
            showLoader(inAppNotificationContainer, inAppNotificationMessage, inAppNotificationIcon, notification);
            inAppNotificationCloseButton.BackColor = Color.FromArgb(18, 23, 36);
            inAppNotificationCloseButton.FlatAppearance.MouseOverBackColor = Color.FromArgb(34, 39, 51);
        }

        public static void hideLoader(PictureBox inAppNotificationIcon)
        {
            inAppNotificationIcon.BackgroundImage = null;
            inAppNotificationIcon.BackgroundImageLayout = ImageLayout.Zoom;
            inAppNotificationIcon.Image = null;
            inAppNotificationIcon.SizeMode = PictureBoxSizeMode.Zoom;
        }
    }
}
