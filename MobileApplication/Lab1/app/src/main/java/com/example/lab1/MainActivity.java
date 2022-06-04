package com.example.lab1;

import androidx.appcompat.app.AppCompatActivity;

import android.app.Activity;
import android.content.Intent;
import android.os.Bundle;
import android.view.View;
import android.widget.EditText;

public class MainActivity extends AppCompatActivity {

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);
    }

    public void ShowTwoActivity(View view)
    {
        Intent secondActivity = new Intent(MainActivity.this,MainActivity2.class);
        EditText editText = (EditText)findViewById(R.id.editTextTextPersonName);
        secondActivity.putExtra("lastName",editText.getText().toString());
        startActivity(secondActivity);
    }
}