package com.example.studentapplication;

import androidx.appcompat.app.AppCompatActivity;
import androidx.core.widget.NestedScrollView;

import android.content.Intent;
import android.content.SharedPreferences;
import android.graphics.Color;
import android.os.Bundle;
import android.util.Log;
import android.util.SparseBooleanArray;
import android.view.View;
import android.widget.AdapterView;
import android.widget.ArrayAdapter;
import android.widget.Button;
import android.widget.LinearLayout;
import android.widget.ListView;
import android.widget.TextView;
import android.widget.Toast;


import com.example.studentapplication.api.API;
import com.example.studentapplication.api.ApiInterface;
import com.example.studentapplication.model.CourseDto;
import com.example.studentapplication.model.FullStudentDto;
import com.example.studentapplication.model.StudentDto;
import com.example.studentapplication.model.studentsdto;
import com.example.studentapplication.response.UserResponse;
import com.google.gson.Gson;

import java.util.ArrayList;
import java.util.List;

import retrofit2.Call;
import retrofit2.Callback;
import retrofit2.Response;

public class showallstudent extends AppCompatActivity {
    LinearLayout linearlayout;
    ArrayList arrayList;
    NestedScrollView nestedScrollView;
    List<StudentDto> fullstudentList;
    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_showallstudent);
        linearlayout= findViewById(R.id.linearlayout);
        nestedScrollView=findViewById(R.id.nestedScrollView);
        Getallstudent();

    }
    void Getallstudent()
    {
        ApiInterface service = API.getRetrofitInstance().create(ApiInterface.class);
        SharedPreferences prefs = getSharedPreferences("studentapplication", MODE_PRIVATE);
        Gson gson = new Gson();
        String json = prefs.getString("loginResponse", "");
        UserResponse userObj = gson.fromJson(json, UserResponse.class);
        String token = userObj.getAccess_token();
        try {
            Call<studentsdto> student = service.GetAllStudent("bearer " + token );
            student.enqueue(new Callback<studentsdto>() {
                @Override
                public void onResponse(Call<studentsdto> call, Response<studentsdto> response) {
                    if (response.isSuccessful()) {
                        studentsdto students=response.body();
                        fullstudentList = new ArrayList<StudentDto>();
                        arrayList= new ArrayList<StudentDto>();


                      //  fullstudentList=response.body();
                        for(StudentDto student : students.getData())
                        {
                            String content = "";
                            content += "Student Name: \t" + student.getStudentname()+"\n";
                            content += "Student Email: \t" + student.getStudentEmail()+ "\n";
                            content += "Student DOB: \t" + student.getDateOfBirth()+ "\n";
                            content += "Student Phone: \t" + student.getPhoneNumber()+ "\n";
                            content += "Student Password: \t" + student.getPassword()+ "\n";
                            content += "Student Courses: \t" + student.getStudentCourseCount()+ "\n";
                            TextView studentTextView = new TextView(showallstudent.this);
                            LinearLayout.LayoutParams lparams = new LinearLayout.LayoutParams(
                                    LinearLayout.LayoutParams.WRAP_CONTENT, LinearLayout.LayoutParams.WRAP_CONTENT);

                            studentTextView.setLayoutParams(lparams);
                            studentTextView.setText(content);
                            linearlayout.addView(studentTextView);
                            addButton("Edit",linearlayout,lparams, student.getStudentId());
                            addButton("Delete",linearlayout,lparams,student.getStudentId());

                        }

                    } else {
                        Log.d("categortyrror", "Response Unsuccessful " + response.body());
                    }
                }
                @Override
                public void onFailure(Call<studentsdto> call, Throwable t) {
                    Toast.makeText(getApplicationContext()," Fail error  " + t ,Toast.LENGTH_LONG).show();
                }
            });
        } catch (Exception e) {
            e.printStackTrace();
        }
    }
    public void addButton(String dataToDisplay, LinearLayout linearLayout, LinearLayout.LayoutParams lparams, int studentId){
        Button button = new Button(showallstudent.this);
        button.setText(dataToDisplay);
        //  button.setTextColor(getResources().getColor().);

        button.setTextColor(Color.WHITE);

        if(dataToDisplay == "Delete"){
            button.setOnClickListener(new View.OnClickListener() {
                @Override
                public void onClick(View v) {
                    delete(studentId);
                }
            });
        }else{
            button.setOnClickListener(new View.OnClickListener() {
                @Override
                public void onClick(View v) {
                    edit(studentId);
                }
            });
        }

        linearLayout.addView(button);
    }
    public void edit(int id){
        Intent intent = new Intent(showallstudent.this,AddStudentActivity.class);
        intent.putExtra("id",id);
        startActivity(intent);
        finish();
    }
    public void delete(int id){
        ApiInterface service = API.getRetrofitInstance().create(ApiInterface.class);
        SharedPreferences prefs = getSharedPreferences("studentapplication", MODE_PRIVATE);
        Gson gson = new Gson();
        String json = prefs.getString("loginResponse", "");
        UserResponse userObj = gson.fromJson(json, UserResponse.class);
        String token = userObj.getAccess_token();
        Call<Boolean> student = service.Deletestudent("bearer " + token , id);
        student.enqueue(new Callback<Boolean>() {
            @Override

            public void onResponse(Call<Boolean> call, Response<Boolean> response) {
                if(response.isSuccessful()) {
                    Intent intent = new Intent(showallstudent.this, showallstudent.class);
                    startActivity(intent);
                    finish();
                }
            }

            @Override
            public void onFailure(Call<Boolean> call, Throwable t) {
                Log.e("Error", t.getMessage());
            }
        });
    }
}