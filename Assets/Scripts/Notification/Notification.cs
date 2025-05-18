using UnityEngine;
using System;

using Unity.Notifications.Android;
using UnityEngine.Android;

public class Notification : MonoBehaviour
{
    private const string defaultChannelId = "default_channel";
    private const string highScoreChannelId = "highscore_channel";

    private void Start()
    {
#if UNITY_ANDROID
        RequestAuthorization();
        RegisterNotificationChannels();
#endif
    }

#if UNITY_ANDROID
    private void RequestAuthorization()
    {
        if (!Permission.HasUserAuthorizedPermission("android.permission.POST_NOTIFICATIONS"))
        {
            Permission.RequestUserPermission("android.permission.POST_NOTIFICATIONS");
        }
    }

    private void RegisterNotificationChannels()
    {
        AndroidNotificationChannel defaultChannel = new AndroidNotificationChannel()
        {
            Id = defaultChannelId,
            Name = "Rondas",
            Importance = Importance.Default,
            Description = "Notificaciones de fin de ronda"
        };
        AndroidNotificationCenter.RegisterNotificationChannel(defaultChannel);

        // Canal para nuevo r�cord (Nuevo Puntaje M�ximo)
        AndroidNotificationChannel highScoreChannel = new AndroidNotificationChannel()
        {
            Id = highScoreChannelId,
            Name = "R�cord",
            Importance = Importance.High,
            Description = "Notificaciones de nuevo puntaje m�ximo"
        };
        AndroidNotificationCenter.RegisterNotificationChannel(highScoreChannel);
    }

    /// <summary>
    /// Notificaci�n al terminar la ronda, muestra el puntaje actual.
    /// </summary>
    public void SendRoundEndedNotification()
    {
        AndroidNotification notification = new AndroidNotification();
        notification.Title = "Ronda Terminada";
        notification.FireTime = DateTime.Now.AddSeconds(1);
        notification.SmallIcon = "icon_0";
        notification.LargeIcon = "icon_0";

        AndroidNotificationCenter.SendNotification(notification, defaultChannelId);
    }

    /// <summary>
    /// Notificaci�n al superar el r�cord, muestra el nuevo puntaje m�ximo.
    /// </summary>
    public void SendNewHighScoreNotification()
    {
        AndroidNotification notification = new AndroidNotification();
        notification.Title = "Nuevo Puntaje M�ximo";
        notification.FireTime = DateTime.Now.AddSeconds(1);
        notification.SmallIcon = "icon_1";
        notification.LargeIcon = "icon_1";

        AndroidNotificationCenter.SendNotification(notification, highScoreChannelId);
    }
#endif
}