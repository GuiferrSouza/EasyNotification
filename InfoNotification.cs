using System.Drawing;

namespace EasyNotification
{
    public class InfoNotification : Notification
    {
        /// <summary>
        /// Initializes a new instance of the InfoNotification class.
        /// </summary>
        public InfoNotification()
        {
            NotificationIcon = Properties.Resources.infoIcon;
            NotificationTitleColor = Color.Black;
            NotificationTextColor = Color.Black;
            NotificationBackColor = Color.LightYellow;
            NotificationTitle = "Info";
        }
    }
}
