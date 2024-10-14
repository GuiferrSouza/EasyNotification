using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace EasyNotification
{
    public partial class Notification : Form
    {
        public Bitmap CheckIcon { get => Properties.Resources.checkIcon; }
        public Bitmap ErrorIcon { get => Properties.Resources.errorIcon; }
        public Bitmap InfoIcon { get => Properties.Resources.infoIcon; }

        private Timer _closeTimer;

        private ScreenPosition _position = ScreenPosition.BottomRight;

        private int _marginX = 10;
        private int _marginY = 10;

        public int NotificationInterval { get; set; } = 5000;

        /// <summary>
        /// Gets or sets the position of the notification on the screen.
        /// </summary>
        public ScreenPosition NotificationPosition
        {
            get => _position;
            set
            {
                _position = value;
                UpdatePosition();
            }
        }

        /// <summary>
        /// Gets or sets the horizontal margin of the notification.
        /// </summary>
        public int NotificationMarginX
        {
            get => _marginX;
            set
            {
                _marginX = value;
                UpdatePosition();
            }
        }

        /// <summary>
        /// Gets or sets the vertical margin of the notification.
        /// </summary>
        public int NotificationMarginY
        {
            get => _marginY;
            set
            {
                _marginY = value;
                UpdatePosition();
            }
        }

        /// <summary>
        /// Gets or sets the icon of the notification.
        /// </summary>
        public Image NotificationIcon
        {
            get => messageIcon.BackgroundImage;
            set => messageIcon.BackgroundImage = value;
        }

        /// <summary>
        /// Gets or sets the title of the notification.
        /// </summary>
        public string NotificationTitle
        {
            get => titleLabel.Text;
            set => titleLabel.Text = value;
        }

        /// <summary>
        /// Gets or sets the text of the notification.
        /// </summary>
        public string NotificationText
        {
            get => messageLabel.Text;
            set
            {
                messageLabel.Text = value;
                AdjustFormSize();
            }
        }

        /// <summary>
        /// Gets or sets the text color of the notification message.
        /// </summary>
        public Color NotificationTextColor
        {
            get => messageLabel.ForeColor;
            set => messageLabel.ForeColor = value;
        }

        /// <summary>
        /// Gets or sets the text color of the notification title.
        /// </summary>
        public Color NotificationTitleColor
        {
            get => titleLabel.ForeColor;
            set => titleLabel.ForeColor = value;
        }

        /// <summary>
        /// Gets or sets the background color of the notification.
        /// </summary>
        public Color NotificationBackColor
        {
            get => backgroundPanel.BackColor;
            set
            {
                backgroundPanel.BackColor = value;
                messageLabel.BackColor = value;
                titleLabel.BackColor = value;
            }
        }

        /// <summary>
        /// Initializes a new instance of the Notification class.
        /// </summary>
        public Notification()
        {
            InitializeComponent();
            UpdatePosition();
        }

        /// <summary>
        /// Updates the position of the notification on the screen based on the specified position and margins.
        /// </summary>
        private void UpdatePosition()
        {
            var screen = Screen.PrimaryScreen.WorkingArea;

            var positions = new Dictionary<ScreenPosition, Point>
            {
                { ScreenPosition.TopLeft, new Point(_marginX, _marginY) },
                { ScreenPosition.TopCenter, new Point((screen.Width - Width) / 2, _marginY) },
                { ScreenPosition.TopRight, new Point(screen.Width - Width - _marginX, _marginY) },
                { ScreenPosition.MiddleLeft, new Point(_marginX, (screen.Height - Height) / 2) },
                { ScreenPosition.MiddleCenter, new Point((screen.Width - Width) / 2, (screen.Height - Height) / 2) },
                { ScreenPosition.MiddleRight, new Point(screen.Width - Width - _marginX, (screen.Height - Height) / 2) },
                { ScreenPosition.BottomLeft, new Point(_marginX, screen.Height - Height - _marginY) },
                { ScreenPosition.BottomCenter, new Point((screen.Width - Width) / 2, screen.Height - Height - _marginY) },
                { ScreenPosition.BottomRight, new Point(screen.Width - Width - _marginX, screen.Height - Height - _marginY) }
            };

            if (positions.TryGetValue(_position, out var pos))
            {
                Location = pos;
            }
        }

        /// <summary>
        /// Displays the notification and starts the timer to close it after the specified interval.
        /// </summary>
        /// <returns>The current instance of the Notification class.</returns>
        public Notification Notify()
        {
            _closeTimer = new Timer { Interval = NotificationInterval };
            _closeTimer.Tick += CloseTimer_Tick;
            _closeTimer.Start();
            Show();
            return this;
        }

        /// <summary>
        /// Adjusts the size of the form based on the size of the message label.
        /// </summary>
        private void AdjustFormSize()
        {
            var labelBottom = messageLabel.Location.Y + messageLabel.Height + messageLabel.Margin.Bottom + messageLabel.Margin.Top;
            var labelRight = messageLabel.Location.X + messageLabel.Width + messageLabel.Margin.Right + messageLabel.Margin.Left;

            if (labelRight > ClientSize.Width)
            {
                ClientSize = new Size(labelRight + 20, ClientSize.Height);
            }

            if (labelBottom > ClientSize.Height)
            {
                ClientSize = new Size(ClientSize.Width, labelBottom + 20);
            }
        }

        /// <summary>
        /// Handles the Tick event of the close timer, stopping the timer and closing the notification.
        /// </summary>
        private void CloseTimer_Tick(object sender, EventArgs e)
        {
            _closeTimer.Stop();
            Close();
        }

        /// <summary>
        /// Specifies the possible positions for the notification on the screen.
        /// </summary>
        public enum ScreenPosition
        {
            TopLeft,
            TopCenter,
            TopRight,
            MiddleLeft,
            MiddleCenter,
            MiddleRight,
            BottomLeft,
            BottomCenter,
            BottomRight
        }
    }
}
