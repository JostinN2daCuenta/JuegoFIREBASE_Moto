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

        AndroidNotification notificationPrueba = new AndroidNotification()
        {
            Title = "TAN GOZU",
            Text = "Ganaste 1000$ y un auto nissan, recogelos en la bodega mas cerca",
            SmallIcon = "default",
            LargeIcon = "default",
            FireTime = System.DateTime.Now
        };
        AndroidNotificationCenter.SendNotification(notificationPrueba, notificationChannel.Id);
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
}
