package com.example.studentapplication;

import androidx.annotation.NonNull;
import androidx.annotation.Nullable;
import androidx.appcompat.app.AppCompatActivity;

import android.Manifest;
import android.app.DatePickerDialog;
import android.content.Intent;
import android.content.SharedPreferences;
import android.content.pm.PackageManager;
import android.graphics.Bitmap;
import android.graphics.BitmapFactory;
import android.net.Uri;
import android.os.Build;
import android.os.Bundle;
import android.util.Base64;
import android.util.Log;
import android.util.SparseBooleanArray;
import android.view.View;
import android.widget.AdapterView;
import android.widget.ArrayAdapter;
import android.widget.Button;
import android.widget.DatePicker;
import android.widget.EditText;
import android.widget.ImageView;
import android.widget.ListView;
import android.widget.Spinner;
import android.widget.TextView;
import android.widget.Toast;

import com.example.studentapplication.api.API;
import com.example.studentapplication.api.ApiInterface;
import com.example.studentapplication.model.CourseDto;
import com.example.studentapplication.model.StudentDto;
import com.example.studentapplication.model.studentsdto;
import com.example.studentapplication.response.UserResponse;
import com.google.gson.Gson;

import java.io.ByteArrayOutputStream;
import java.io.FileNotFoundException;
import java.io.InputStream;
import java.text.SimpleDateFormat;
import java.util.ArrayList;
import java.util.Calendar;
import java.util.List;

import retrofit2.Call;
import retrofit2.Callback;
import retrofit2.Response;

public class AddStudentActivity extends AppCompatActivity {
     EditText name,email,phonenumber,password,confirampassword,date;
     ListView courselist;
     ArrayList arrayList;
     ArrayAdapter arrayAdapter;
     ArrayList selectedCourse;
     List<CourseDto> course;
     Button savebtn,chooseimage;
     int year,month,day;
     ImageView image;
    String encImage="";
     private static final  int Image_Pick_Code=1000;
    private static final  int Permission_Code=1001;
    int id=0;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_add_student);
        name = findViewById(R.id.name);
        email= findViewById(R.id.email);
        phonenumber= findViewById(R.id.phonenumber);
        password= findViewById(R.id.password);
        confirampassword= findViewById(R.id.confirampassword);
        date= findViewById(R.id.date);
        savebtn= findViewById(R.id.savebtn);
        courselist=findViewById(R.id.courselist);
        chooseimage=findViewById(R.id.chooseimage);
        image=findViewById(R.id.image);

        setCources();
        getCalendar();
        ChooseImage();
        id = getIntent().getIntExtra("id", 0);
        if (id != 0) {
            editStudentRecord(id);
        }
        savebtn.setOnClickListener(new View.OnClickListener() {
            @Override


            public void onClick(View view) {
                StudentDto stdo=new StudentDto();
                String StudentName=name.getText().toString();
                String StudentEmail=email.getText().toString();
                String PhoneNumber=phonenumber.getText().toString();
                String DateOfBirth=date.getText().toString();
                String Password=password.getText().toString();
                String ConfiramPassword=confirampassword.getText().toString();
                stdo.setStudentname(StudentName);
                stdo.setStudentEmail(StudentEmail);
                stdo.setPhoneNumber(PhoneNumber);
                stdo.setDateOfBirth(DateOfBirth);
                stdo.setPassword(Password);
                stdo.setConfirmPawword(ConfiramPassword);
                stdo.setBase64string(encImage);
                ApiInterface service = API.getRetrofitInstance().create(ApiInterface.class);
                SharedPreferences prefs = getSharedPreferences("studentapplication", MODE_PRIVATE);
                Gson gson = new Gson();
                String json = prefs.getString("loginResponse", "");
                UserResponse userObj = gson.fromJson(json, UserResponse.class);
                String token =  userObj.getAccess_token();
                if(id != 0)
                {
                    stdo.setStudentId(id);
                    try {
                        Call<Boolean> student = service.UpadteStudent( "bearer " + token, stdo , selectedCourse.toString());
                        student.enqueue(new Callback<Boolean>() {
                            @Override
                            public void onResponse(Call<Boolean> call, Response<Boolean> response) {
                                if (response.isSuccessful()) {
                                    Toast.makeText(getApplicationContext(),"Update Record Successfull"  ,Toast.LENGTH_LONG).show();
                                    resetField();
                                } else {
                                    Log.d("categortyrror", "Response Unsuccessful " + response.body());
                                }
                            }
                            @Override
                            public void onFailure(Call<Boolean> call, Throwable t) {
                                Log.d("categortyrror", "" + t.toString());
                            }
                        });
                    } catch (Exception e) {
                        e.printStackTrace();
                    }

                }

              else
                  {
                    try {
                        Call<Integer> student = service.AddNewStudent("bearer " + token,stdo, selectedCourse.toString());
                        student.enqueue(new Callback<Integer>() {
                            @Override
                            public void onResponse(Call<Integer> call, Response<Integer> response) {
                                if (response.isSuccessful()) {
                                    Toast.makeText(getApplicationContext(), "Successfully  added student", Toast.LENGTH_LONG).show();

                                    resetField();
                                } else {
                                    Log.d("categortyrror", "Response Unsuccessful " + response.body());
                                }
                            }

                            @Override
                            public void onFailure(Call<Integer> call, Throwable t) {
                                Log.d("categortyrror", "" + t.toString());
                            }
                        });
                    } catch (Exception e) {
                        e.printStackTrace();
                    }
                }
            }
        });
    }
    public void setCources()
    {
        ApiInterface service = API.getRetrofitInstance().create(ApiInterface.class);
        try {
            Call<List<CourseDto>> student = service.GetCourses();
            student.enqueue(new Callback<List<CourseDto>>() {
                @Override
                public void onResponse(Call<List<CourseDto>> call, Response<List<CourseDto>>response) {
                    if (response.isSuccessful()) {
                         course=new ArrayList<CourseDto>();
                        arrayList= new ArrayList<String>();
                        course=response.body();
                            for(CourseDto c : course)
                            {
                                arrayList.add(c.getCourseName());
                            }
                            arrayAdapter=new ArrayAdapter<String>(AddStudentActivity.this, android.R.layout.simple_list_item_multiple_choice,arrayList);
                            courselist.setAdapter(arrayAdapter);

                        courselist.setOnItemClickListener(new AdapterView.OnItemClickListener() {
                            @Override
                            public void onItemClick(AdapterView<?> adapterView, View view, int i, long l) {
                                SparseBooleanArray clickedItemPositions = courselist.getCheckedItemPositions();
                                selectedCourse = new ArrayList<Integer>();
                                for(int index=0;index<clickedItemPositions.size();index++){
                                    // Get the checked status of the current item
                                    boolean checked = clickedItemPositions.valueAt(index);

                                    if(checked){
                                        // If the current item is checked
                                        int key = clickedItemPositions.keyAt(index);
                                        for(CourseDto c : course)
                                        {
                                            if(c.getCourseName()==(String) arrayAdapter.getItem(key))
                                            {

                                                selectedCourse.add(c.getCoureseId());
                                            }
                                        }

                                    }
                                }
                            }
                        });

                        Toast.makeText(getApplicationContext()," Get cources Successfully  "  ,Toast.LENGTH_LONG).show();
                    } else {
                        Log.d("categortyrror", "Response Unsuccessful " + response.body());
                    }
                }
                @Override
                public void onFailure(Call<List<CourseDto>> call, Throwable t) {
                    Toast.makeText(getApplicationContext()," Fail error  " + t ,Toast.LENGTH_LONG).show();
                }
            });
        } catch (Exception e) {
            e.printStackTrace();
        }
    }
    public  void  ChooseImage()
    {
        chooseimage.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                if(Build.VERSION.SDK_INT >= Build.VERSION_CODES.M){
                    if(checkSelfPermission(Manifest.permission.READ_EXTERNAL_STORAGE )== PackageManager.PERMISSION_DENIED)
                    {
                        String[] Permission={Manifest.permission.READ_EXTERNAL_STORAGE};
                        requestPermissions(Permission,Permission_Code);
                    }else {
                         PickImageFromGallery();
                    }

                }else {
                    PickImageFromGallery();
                }
            }
        });
    }

    private void PickImageFromGallery() {
        Intent intent=new Intent(Intent.ACTION_PICK);
        intent.setType("image/*");
        startActivityForResult(intent, Image_Pick_Code);

    }

    @Override
    public void onRequestPermissionsResult(int requestCode, @NonNull String[] permissions, @NonNull int[] grantResults) {
        super.onRequestPermissionsResult(requestCode, permissions, grantResults);
        switch (requestCode)
        {
            case Permission_Code:{
                if(grantResults.length>0 && grantResults[0]==PackageManager.PERMISSION_GRANTED)
                {
                    PickImageFromGallery();
                }
                else {
                    Toast.makeText(AddStudentActivity.this,"Permissions Denied",Toast.LENGTH_LONG).show();
                }
            }
        }
    }

    @Override
    protected void onActivityResult(int requestCode, int resultCode, @Nullable Intent data) {
        super.onActivityResult(requestCode, resultCode, data);
        if(resultCode==RESULT_OK && requestCode==Image_Pick_Code)
        {
            image.setImageURI(data.getData());

            try {
                final Uri imageUri = data.getData();
                final InputStream imageStream = getContentResolver().openInputStream(imageUri);
                final Bitmap selectedImage = BitmapFactory.decodeStream(imageStream);
                ByteArrayOutputStream baos = new ByteArrayOutputStream();
                selectedImage.compress(Bitmap.CompressFormat.JPEG,100,baos);
                byte[] b = baos.toByteArray();
                encImage = Base64.encodeToString(b, Base64.DEFAULT);
            } catch (FileNotFoundException e) {
                e.printStackTrace();
            }


        }
    }

    public void getCalendar()
    {
        final Calendar calendar=Calendar.getInstance();
        date.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                year=calendar.get(Calendar.YEAR);
                month=calendar.get(Calendar.MONTH);
                day=calendar.get(Calendar.DAY_OF_MONTH);
                DatePickerDialog datePickerDialog=new DatePickerDialog(AddStudentActivity.this, new DatePickerDialog.OnDateSetListener() {
                    @Override
                    public void onDateSet(DatePicker datePicker, int i, int i1, int i2) {
                        date.setText(SimpleDateFormat.getDateInstance().format(calendar.getTime()));
                    }
                },year,month,day);
                datePickerDialog.show();
            }
        });
    }

    public  void resetField()
    {
        name.setText("");
        email.setText("");
        phonenumber.setText("");
        date.setText("");
        password.setText("");
        confirampassword.setText("");
        image.setImageResource(R.drawable.ic_baseline_image_24);
      
    }
    void editStudentRecord(int id)
    {
        ApiInterface service = API.getRetrofitInstance().create(ApiInterface.class);
        SharedPreferences prefs = getSharedPreferences("studentapplication", MODE_PRIVATE);
        Gson gson = new Gson();
        String json = prefs.getString("loginResponse", "");
        UserResponse userObj = gson.fromJson(json, UserResponse.class);
        String token = userObj.getAccess_token();
        try {
            Call<StudentDto> student = service.EditStudent("bearer " + token ,id);
            student.enqueue(new Callback<StudentDto>() {
                @Override
                public void onResponse(Call<StudentDto> call, Response<StudentDto> response) {
                    if (response.isSuccessful()) {
                        StudentDto students=response.body();
                        name.setText(students.getStudentname(), TextView.BufferType.EDITABLE);
                        email.setText(students.getStudentEmail(), TextView.BufferType.EDITABLE);
                        phonenumber.setText(students.getPhoneNumber(), TextView.BufferType.EDITABLE);
                        password.setText(students.getPassword(), TextView.BufferType.EDITABLE);
                        confirampassword.setText(students.getConfirmPawword(), TextView.BufferType.EDITABLE);
                        date.setText(students.getDateOfBirth(), TextView.BufferType.EDITABLE);

                        ByteArrayOutputStream byteArrayOutputStream = new ByteArrayOutputStream();
                        byte[] imageBytes = byteArrayOutputStream.toByteArray();
                        imageBytes = Base64.decode(students.getBase64string(), Base64.DEFAULT);
                        Bitmap bitmap = BitmapFactory.decodeByteArray(imageBytes, 0, imageBytes.length);
                        image.setImageBitmap(bitmap);

                    } else {
                        Log.d("categortyrror", "Response Unsuccessful " + response.body());
                    }
                }
                @Override
                public void onFailure(Call<StudentDto> call, Throwable t) {
                    Log.d("categortyrror", "" + t.toString());
                }
            });
        } catch (Exception e) {
            e.printStackTrace();
        }
    }

}