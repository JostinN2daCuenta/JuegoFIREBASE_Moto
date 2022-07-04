using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Notifications.Android;

public class NotificationManager : MonoBehaviour
{
    AndroidNotificationChannel notificationChannel;
    void Start()
    {
        channelNregisterCreation();
    }

    public void channelNregisterCreation() 
    {
        notificationChannel = new AndroidNotificationChannel()
        {
            Id = "channel_id",
            Name = "Default Channel",
            Importance = Importance.Default,
            Description = "que onda papu",
        };

        AndroidNotificationCenter.RegisterNotificationChannel(notificationChannel);
    }

    public void sendNoti(string message) 
    {
        AndroidNotification notificationPrueba = new AndroidNotification()
        {
            Title = "TAN GOZU",
            Text = string.Format("Superaste tu record en {0}, bien ahí papu.", message),
            SmallIcon = "default",
            LargeIcon = "default",
            FireTime = System.DateTime.Now
        };
        AndroidNotificationCenter.SendNotification(notificationPrueba, notificationChannel.Id);
    }
}
