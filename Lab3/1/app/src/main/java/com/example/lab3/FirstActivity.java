package com.example.lab3;

import androidx.appcompat.app.AppCompatActivity;

import android.content.ContentValues;
import android.database.Cursor;
import android.database.sqlite.SQLiteDatabase;
import android.graphics.Color;
import android.os.Bundle;
import android.widget.TableLayout;
import android.widget.TableRow;
import android.widget.TextView;

import java.util.ArrayList;
import java.util.List;

public class FirstActivity extends AppCompatActivity {

    public static void InsertInto(String lastName,String firstName, String patronymic, String dateRecording,SQLiteDatabase db)
    {
        ContentValues values = new ContentValues();
        values.put(OurContractTest.FeedEntry.LastName, lastName);
        values.put(OurContractTest.FeedEntry.FirstName, firstName);
        values.put(OurContractTest.FeedEntry.Patronymic, patronymic);
        values.put(OurContractTest.FeedEntry.DateRecording, dateRecording);
        db.insert(OurContractTest.FeedEntry.TABLE_NAME, null, values);
    }

    public String GetData(String type,Cursor cursor)
    {
        return cursor.getString(cursor.getColumnIndexOrThrow(type));
    }

    public static void TableLayout(String name, FirstActivity context, int idx, TableRow tr_head)
    {
        TextView label = new TextView(context);
        label.setId(idx);
        label.setText(name);
        label.setTextColor(Color.WHITE);
        label.setPadding(5, 5, 5, 5);
        tr_head.addView(label);
    }

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_first);
        OurDB dbHelper = new OurDB(this);
        SQLiteDatabase db = dbHelper.getWritableDatabase();

        Cursor cursor = db.query(
                "ClassMates",   // The table to query
                 null,        // The array of columns to return (pass null to get all)
                 null ,       // The columns for the WHERE clause
                null,      // The values for the WHERE clause
                null,          // don't group the rows
                null,           // don't filter by row groups
                null           // The sort order
        );
        int i = cursor.getCount();
        if (cursor.moveToFirst()) {
            int idx = 5;
            while (!cursor.isAfterLast()) {

                TableLayout tableLayout = (TableLayout) findViewById(R.id.table);
                TableRow tr_head = new TableRow(this);
                tr_head.setId(idx);

                tr_head.setBackgroundColor(Color.GRAY);
                tr_head.setLayoutParams(new TableLayout.LayoutParams(
                        TableLayout.LayoutParams.MATCH_PARENT,
                        TableLayout.LayoutParams.WRAP_CONTENT));
                idx+=1;
                String data = GetData("_id",cursor);
                TableLayout(data,this,idx,tr_head);
                idx+=1;
                data = GetData("lastName",cursor);
                TableLayout(data,this,idx,tr_head);
                idx+=1;
                data = GetData("firstName",cursor);
                TableLayout(data,this,idx,tr_head);
                idx+=1;
                data = GetData("patronymic",cursor);
                TableLayout(data,this,idx,tr_head);
                idx+=1;
                data = GetData("dateRecording",cursor);
                TableLayout(data,this,idx,tr_head);
                idx+=1;

                tableLayout.addView(tr_head, new TableLayout.LayoutParams(
                        TableLayout.LayoutParams.MATCH_PARENT,
                        TableLayout.LayoutParams.WRAP_CONTENT));
                cursor.moveToNext();
            }
        }
        cursor.close();

    }
}