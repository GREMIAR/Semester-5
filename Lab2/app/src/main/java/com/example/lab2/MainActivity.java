package com.example.lab2;

import androidx.appcompat.app.AppCompatActivity;

import android.content.Intent;
import android.os.Bundle;
import android.view.View;

public class MainActivity extends AppCompatActivity {

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);
    }

    public void onClickFirstButton(View view)
    {
        StartActivity(FirstActivity.class);
    }

    public void onClickSecondButton(View view)
    {
        StartActivity(SecondActivity.class);
    }

    public void onClickThirdButton(View view)
    {
        StartActivity(ThirdActivity.class);
    }

    public  void onClickExit(View view)
    {
        android.os.Process.killProcess(android.os.Process.myPid());
    }

    void StartActivity(Class<?> cls)
    {
        Intent intent = new Intent(MainActivity.this,cls);
        startActivity(intent);
    }
}