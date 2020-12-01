package com.example.studentapplication;

import androidx.appcompat.app.AppCompatActivity;

import android.content.Intent;
import android.os.Bundle;
import android.view.View;
import android.widget.Button;
import android.widget.ImageButton;

public class dashboard extends AppCompatActivity {
    ImageButton addstudentbtn;
    Button allstudentbtn;
    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_dashboard);

        addstudentbtn=findViewById(R.id.addstudentbtn);
        allstudentbtn=findViewById(R.id.allstudentbtn);

        addstudentbtn.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                Intent i=new Intent(dashboard.this,AddStudentActivity.class);
                startActivity(i);
            }
        });
        allstudentbtn.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                   Intent i=new Intent(dashboard.this,showallstudent.class);
                   startActivity(i);
            }
        });
    }

}