package com.example.lab4;

import java.text.DateFormat;
import java.text.SimpleDateFormat;
import java.util.Date;
import java.util.Calendar;
import androidx.appcompat.app.AppCompatActivity;

import android.content.Context;
import android.graphics.Color;
import android.os.Bundle;
import android.widget.TableLayout;
import android.widget.TableRow;
import android.widget.TextView;

public class MainActivity extends AppCompatActivity {

    int idx = 0;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);
        InsertRowIntoTable("1", "2", this);
    }

    void InsertRowIntoTable(String singer, String song, MainActivity context)
    {
        TableLayout tableLayout = (TableLayout) findViewById(R.id.table);
        TableRow row = new TableRow(this);
        row.setId(idx);
        idx++;
        row.setBackgroundColor(Color.GRAY);
        row.setLayoutParams(new TableLayout.LayoutParams(
                TableLayout.LayoutParams.MATCH_PARENT,
                TableLayout.LayoutParams.WRAP_CONTENT));
        InsertElementIntoTableRow(singer, context, row);
        InsertElementIntoTableRow(song, context, row);
        Date date = Calendar.getInstance().getTime();
        DateFormat dateFormat = new SimpleDateFormat("yyyy-MM-dd hh:mm:ss");
        InsertElementIntoTableRow(dateFormat.format(date), context, row);
        tableLayout.addView(row, new TableLayout.LayoutParams(
                TableLayout.LayoutParams.MATCH_PARENT,
                TableLayout.LayoutParams.WRAP_CONTENT));
    }

    void InsertElementIntoTableRow(String name, MainActivity context, TableRow tr_head)
    {
        TextView label = new TextView(context);
        label.setId(idx);
        label.setText(name);
        label.setTextColor(Color.WHITE);
        label.setPadding(5, 5, 5, 5);
        tr_head.addView(label);
        idx++;
    }
}