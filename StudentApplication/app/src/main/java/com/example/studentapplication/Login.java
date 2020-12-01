package com.example.studentapplication;

import androidx.annotation.NonNull;
import androidx.appcompat.app.AppCompatActivity;

import android.app.NotificationChannel;
import android.app.NotificationManager;
import android.content.Intent;
import android.content.SharedPreferences;
import android.os.Build;
import android.os.Bundle;
import android.util.Log;
import android.view.View;
import android.widget.Button;
import android.widget.EditText;
import android.widget.Toast;

import com.example.studentapplication.api.API;
import com.example.studentapplication.api.ApiInterface;
import com.example.studentapplication.response.UserResponse;
import com.google.android.gms.tasks.OnCompleteListener;
import com.google.android.gms.tasks.Task;
import com.google.firebase.messaging.FirebaseMessaging;
import com.google.gson.Gson;

import retrofit2.Call;
import retrofit2.Callback;
import retrofit2.Response;

public class Login extends AppCompatActivity {
   EditText email,password;
   Button Loginbtn;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_login);
        email=findViewById(R.id.email);
        password=findViewById(R.id.phonenumber);
        Loginbtn=findViewById((R.id.loginbtn));
        email.setText("Hamza@gmail.com");
        password.setText("Hamza12@");
        Loginbtn.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                ApiInterface service = API.getRetrofitInstance().create( ApiInterface.class);

                String getEmail = email.getText().toString();
                String getPassword = password.getText().toString();

                try {
                    Call<UserResponse> stringCall = service.login(getEmail,getPassword,"password");
                    stringCall.enqueue( new Callback<UserResponse>() {
                        @Override
                        public void onResponse(Call<UserResponse> call, Response<UserResponse> response) {
                            if (response.isSuccessful()) {

                                if(response.body().getRoles().equals("SuperAdmin")) {
                                    SharedPreferences.Editor editor = getSharedPreferences("studentapplication", MODE_PRIVATE).edit();
                                    Gson gson = new Gson();
                                    String json = gson.toJson(response.body());
                                    editor.putString("loginResponse", json);
                                    editor.apply();
                                    Intent i=new Intent(Login.this,dashboard.class);
                                    startActivity(i);

                                  //  getUserDetail("bearer " + response.body().getAccess_token(), response.body().getUserId());


                                }

                            }
                        }
                        @Override
                        public void onFailure(Call<UserResponse> call, Throwable t) {
                            Toast.makeText(getApplicationContext(),"Request Fail  " + t ,Toast.LENGTH_LONG).show();
                        }
                    } );
                }
                catch (Exception e){
                    Log.d( "exceptionABC",e.toString() );
                }
                Toast.makeText(getApplicationContext(),"hamza aslam",Toast.LENGTH_LONG).show();
                Toast.makeText(getApplicationContext(),getEmail,Toast.LENGTH_LONG).show();
            }
        });


        if(Build.VERSION.SDK_INT>=Build.VERSION_CODES.O)
        {
            NotificationChannel channel=new NotificationChannel("Mynotification","Mynotification", NotificationManager.IMPORTANCE_DEFAULT);
            NotificationManager manager=getSystemService(NotificationManager.class);
            manager.createNotificationChannel(channel);
        }
        FirebaseMessaging.getInstance().subscribeToTopic("general")
                .addOnCompleteListener(new OnCompleteListener<Void>() {
                    @Override
                    public void onComplete(@NonNull Task<Void> task) {
                        String msg = "successfully";
                        if (!task.isSuccessful()) {
                            msg ="fail";
                        }

                        Toast.makeText(Login.this, msg, Toast.LENGTH_SHORT).show();
                    }
                });


    }
}