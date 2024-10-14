# EasyNotification

The `EasyNotification` library provides a simple and customizable way to display notifications in a Windows Forms application. It includes a base `Notification` class and three predefined notification types: `ErrorNotification`, `InfoNotification`, and `SuccessNotification`.

## Classes

### Notification

The `Notification` class is the base class for creating custom notifications. It provides properties and methods to customize the appearance and behavior of the notifications.

#### Properties

- **CheckIcon**: Gets the check icon image.
- **ErrorIcon**: Gets the error icon image.
- **InfoIcon**: Gets the info icon image.
- **NotificationInterval**: Gets or sets the interval (in milliseconds) before the notification closes automatically.
- **NotificationPosition**: Gets or sets the position of the notification on the screen.
- **NotificationMarginX**: Gets or sets the horizontal margin of the notification.
- **NotificationMarginY**: Gets or sets the vertical margin of the notification.
- **NotificationIcon**: Gets or sets the icon of the notification.
- **NotificationTitle**: Gets or sets the title of the notification.
- **NotificationText**: Gets or sets the text of the notification.
- **NotificationTextColor**: Gets or sets the text color of the notification message.
- **NotificationTitleColor**: Gets or sets the text color of the notification title.
- **NotificationBackColor**: Gets or sets the background color of the notification.

#### Methods

- **Notification()**: Initializes a new instance of the `Notification` class.
- **Notify()**: Displays the notification and starts the timer to close it after the specified interval.
- **UpdatePosition()**: Updates the position of the notification on the screen based on the specified position and margins.
- **AdjustFormSize()**: Adjusts the size of the form based on the size of the message label.
- **CloseTimer_Tick(object sender, EventArgs e)**: Handles the Tick event of the close timer, stopping the timer and closing the notification.

#### Enum

- **ScreenPosition**: Specifies the possible positions for the notification on the screen.

### Predefined Notifications

The library includes three predefined notification classes that inherit from the `Notification` class:

- **ErrorNotification**: A notification for displaying error messages.
- **InfoNotification**: A notification for displaying informational messages.
- **SuccessNotification**: A notification for displaying success messages.

## Usage Example

```csharp
using EasyNotification;
using System;
using System.Drawing;

class Program
{
    static void Main()
    {
        // Create a custom notification
        var customNotification = new Notification
        {
            NotificationIcon = customIcon,
            NotificationTitleColor = Color.White,
            NotificationTextColor = Color.White,
            NotificationBackColor = Color.AliceBlue,
            NotificationTitle = "Custom Title",
            NotificationText = "Custom Message"
        };
        customNotification.Notify();

        // Create an error notification
        var errorNotification = new ErrorNotification
        {
            NotificationText = "An error has occurred."
        };
        errorNotification.Notify();

        // Create an info notification
        var infoNotification = new InfoNotification
        {
            NotificationText = "This is an informational message."
        };
        infoNotification.Notify();

        // Create a success notification
        var successNotification = new SuccessNotification
        {
            NotificationText = "Operation completed successfully."
        };
        successNotification.Notify();
    }
}
```

## License

This project is licensed under the terms of the MIT license. See the LICENSE file for more details.
