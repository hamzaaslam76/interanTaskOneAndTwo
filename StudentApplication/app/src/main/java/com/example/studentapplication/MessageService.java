package com.example.studentapplication;

import android.app.Notification;

import androidx.annotation.NonNull;
import androidx.core.app.NotificationCompat;
import androidx.core.app.NotificationManagerCompat;

import com.google.firebase.messaging.FirebaseMessagingService;
import com.google.firebase.messaging.RemoteMessage;

public class MessageService extends FirebaseMessagingService
{

    @Override
    public void onMessageReceived(@NonNull RemoteMessage remoteMessage) {
        super.onMessageReceived(remoteMessage);
        message(remoteMessage.getNotification().getTitle(),remoteMessage.getNotification().getBody());
    }
    public void message(String title,String message){
    Notification.Builder builder = new Notification.Builder(this,"Mynotification")
            .setContentTitle(title)
            .setAutoCancel(true)
            .setContentText(message);
    NotificationManagerCompat manager= NotificationManagerCompat.from(this);
        manager.notify(999,builder.build());
    }
}
