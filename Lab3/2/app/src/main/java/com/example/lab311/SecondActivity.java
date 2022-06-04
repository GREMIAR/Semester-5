package com.example.lab311;

import static com.example.lab311.FirstActivity.InsertInto;

import androidx.appcompat.app.AppCompatActivity;

import android.database.sqlite.SQLiteDatabase;
import android.os.Bundle;
import android.view.View;
import android.widget.EditText;

public class SecondActivity extends AppCompatActivity {

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_second);
    }

    public void InsertIntoDB(View view)
    {
        OurDB dbHelper = new OurDB(this);
        SQLiteDatabase db = dbHelper.getWritableDatabase();
        EditText edit1 = (EditText) findViewById(R.id.editTextTextPersonName);
        EditText edit2 = (EditText) findViewById(R.id.editTextDate2);

        InsertInto(edit1.getText().toString(),edit2.getText().toString(),db);
    }
}