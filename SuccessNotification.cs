using System.Drawing;

namespace EasyNotification
{
    public class SuccessNotification : Notification
    {
        /// <summary>
        /// Initializes a new instance of the SuccessNotification class.
        /// </summary>
        public SuccessNotification()
        {
            NotificationIcon = Properties.Resources.checkIcon;
            NotificationBackColor = Color.LimeGreen;
            NotificationTitleColor = Color.White;
            NotificationTextColor = Color.White;
            NotificationTitle = "Success!";
        }
    }
}
