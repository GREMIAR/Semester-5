package com.example.lab311;

import static com.example.lab311.FirstActivity.InsertInto;

import androidx.appcompat.app.AppCompatActivity;

import android.content.ContentValues;
import android.content.Intent;
import android.database.Cursor;
import android.database.sqlite.SQLiteDatabase;
import android.os.Bundle;
import android.view.View;
import java.text.DateFormat;
import java.text.SimpleDateFormat;
import java.util.Date;
import java.util.Calendar;
public class MainActivity extends AppCompatActivity {

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);
        OurDB.DATABASE_VERSION = 2;
        OurDB dbHelper = new OurDB(this);
        SQLiteDatabase db = dbHelper.getWritableDatabase();

        db.delete(OurContractTest.FeedEntry.TABLE_NAME, null, null);
        Date date = Calendar.getInstance().getTime();
        DateFormat dateFormat = new SimpleDateFormat("yyyy-MM-dd hh:mm:ss");
        String strDate = dateFormat.format(date);
        db.execSQL("UPDATE SQLITE_SEQUENCE SET seq = 0 WHERE name = 'ClassMates';");
        InsertInto("'Фамилия1 Имя1 Отчество1'",strDate,db);
        InsertInto("'Фамилия2 Имя2 Отчество2'",strDate,db);
        InsertInto("'Фамилия3 Имя3 Отчество3'",strDate,db);
        InsertInto("'Фамилия4 Имя4 Отчество4'",strDate,db);
        InsertInto("'Фамилия5 Имя5 Отчество5'",strDate,db);
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
        OurDB dbHelper = new OurDB(this);
        SQLiteDatabase db = dbHelper.getWritableDatabase();
        ContentValues values = new ContentValues();
        values.put(OurContractTest.FeedEntry.Name, "Иванов Иван Иванович");
        String selection = "_id = (SELECT _id FROM "+OurContractTest.FeedEntry.TABLE_NAME+" ORDER BY _id DESC LIMIT 1)";
        db.update(OurContractTest.FeedEntry.TABLE_NAME, values, selection, null);
    }

    public void onClickExit(View view)
    {
        android.os.Process.killProcess(android.os.Process.myPid());
    }

    void StartActivity(Class<?> cls)
    {
        Intent intent = new Intent(MainActivity.this,cls);
        startActivity(intent);
    }
}