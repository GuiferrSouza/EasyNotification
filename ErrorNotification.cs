using System.Drawing;

namespace EasyNotification
{
    public class ErrorNotification : Notification
    {
        /// <summary>
        /// Initializes a new instance of the ErrorNotification class.
        /// </summary>
        public ErrorNotification()
        {
            NotificationIcon = Properties.Resources.errorIcon;
            NotificationTitleColor = Color.White;
            NotificationTextColor = Color.White;
            NotificationBackColor = Color.Salmon;
            NotificationTitle = "Error!";
        }
    }
}
