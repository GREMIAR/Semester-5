package com.example.lab4;

import static com.example.lab4.SongDB.InsertInto;

import android.content.Context;
import android.database.Cursor;
import android.database.sqlite.SQLiteDatabase;
import android.graphics.Color;
import android.net.ConnectivityManager;
import android.net.NetworkInfo;
import android.os.AsyncTask;
import android.util.Log;
import android.widget.TableLayout;
import android.widget.TableRow;
import android.widget.TextView;
import android.widget.Toast;

import java.io.BufferedInputStream;
import java.io.BufferedReader;
import java.io.DataOutputStream;
import java.io.IOException;
import java.io.InputStream;
import java.io.InputStreamReader;
import java.io.UnsupportedEncodingException;
import java.net.HttpURLConnection;
import java.net.URL;
import java.net.URLEncoder;
import java.util.HashMap;

public class RadioHistory extends AsyncTask<String, Integer, Void> {

    int idx=0;
    Context context;
    TableLayout tableLayout;
    public String SendPOST()
    {
        String params = "login=4707login&password=4707pass";
        HttpURLConnection conn = null;
        StringBuilder result = new StringBuilder();
        try{
            String url = "https://media.itmo.ru/api_get_current_song.php";
            URL urlObj = new URL(url);
            conn = (HttpURLConnection) urlObj.openConnection();
            conn.setDoOutput(true);
            conn.setRequestMethod("POST");
            conn.setRequestProperty("Accept-Charset", "UTF-8");

            conn.setReadTimeout(10000);
            conn.setConnectTimeout(15000);

            conn.connect();

            DataOutputStream wr = new DataOutputStream(conn.getOutputStream());
            wr.writeBytes(params);
            wr.flush();
            wr.close();
            InputStream in = new BufferedInputStream(conn.getInputStream());
            BufferedReader reader = new BufferedReader(new InputStreamReader(in));
            String line;
            while ((line = reader.readLine()) != null) {
                result.append(line);
            }
        }
        catch (IOException e)
        {
            e.printStackTrace();
        }
        finally {
            if (conn != null)
            {
                conn.disconnect();
            }
        }
        return result.toString();
    }

    public RadioHistory(Context c, TableLayout tableLayout)
    {
        context = c;
        this.tableLayout=tableLayout;
    }
    public String[] SplitResult(String result)
    {
        if(result!="")
        {
            String[] song = result.split("\"");
            if(song.length==9)
            {
                String[] data = song[7].split("-");
                data[0] = data[0].replaceAll(" ","");
                data[1] = data[1].replaceAll(" ","");
                return data;
            }
        }
        return null;
    }

    @Override
    protected Void doInBackground(String... strings) {
        publishProgress(1);
        while(true)
        {
            if (!HasConnection(context)) {
                publishProgress(2);
            }
            else
            {
                String[] data = SplitResult(SendPOST());
                if(data!=null)
                {
                    SongDB dbHelper = new SongDB(context);
                    SQLiteDatabase db = dbHelper.getWritableDatabase();

                    Cursor cursor = db.query(
                            SongContract.FeedEntry.TABLE_NAME,   // The table to query
                            null,
                            null,       // The columns for the WHERE clause
                            null,      // The values for the WHERE clause
                            null,          // don't group the rows
                            null,           // don't filter by row groups
                            "_id DESC",        // The sort order
                            "1"
                    );
                    if(cursor.getCount()==1)
                    {
                        cursor.moveToFirst();
                        if( !GetData(SongContract.FeedEntry.Singer,cursor).equals(data[0])||
                                !GetData(SongContract.FeedEntry.Song,cursor).equals(data[1]))
                        {
                            InsertInto(data[1], data[0], db);
                            publishProgress(1);
                        }
                    }
                    else
                    {
                        InsertInto(data[1], data[0], db);
                        publishProgress(1);
                    }
                }
            }
            try {
                Thread.sleep(5000);
            } catch (InterruptedException e) {
                e.printStackTrace();
            }
        }
    }

    @Override
    protected void onProgressUpdate(Integer... values) {
     super.onProgressUpdate(values);
     if(values!=null &&values[0]==1)
     {
         tableLayout.removeAllViews();
         InsertRowIntoTable("Исполнитель","Композиция","Дата добавления", (MainActivity) context);
         SongDB dbHelper = new SongDB(context);
         SQLiteDatabase db = dbHelper.getWritableDatabase();
         Cursor cursor = db.query(
                 SongContract.FeedEntry.TABLE_NAME,   // The table to query
                 null,        // The array of columns to return (pass null to get all)
                 null ,       // The columns for the WHERE clause
                 null,      // The values for the WHERE clause
                 null,          // don't group the rows
                 null,           // don't filter by row groups
                 null           // The sort order
         );

         if (cursor.moveToFirst()) {
             while (!cursor.isAfterLast()) {
                 String singer=GetData(SongContract.FeedEntry.Singer,cursor);
                 String song = GetData(SongContract.FeedEntry.Song,cursor);
                 String dateRecording = GetData(SongContract.FeedEntry.DateRecording,cursor);
                 InsertRowIntoTable(singer, song, dateRecording, (MainActivity) context);
                 cursor.moveToNext();
             }
         }
         cursor.close();
     }
     else
     {
         Toast toast = Toast.makeText(context,
                 "Нет подключения к интернету!", Toast.LENGTH_SHORT);
         toast.show();
     }
    }

    public String GetData(String type,Cursor cursor)
    {
        return cursor.getString(cursor.getColumnIndexOrThrow(type));
    }

    public void InsertRowIntoTable(String singer, String song,String date, MainActivity context)
    {
        TableRow row = new TableRow(context);
        row.setId(idx);
        idx++;
        row.setBackgroundColor(Color.GRAY);
        row.setLayoutParams(new TableLayout.LayoutParams(
                TableLayout.LayoutParams.MATCH_PARENT,
                TableLayout.LayoutParams.WRAP_CONTENT));
        InsertElementIntoTableRow(singer, context, row);
        InsertElementIntoTableRow(song, context, row);
        InsertElementIntoTableRow(date, context, row);
        tableLayout.addView(row, new TableLayout.LayoutParams(
                TableLayout.LayoutParams.MATCH_PARENT,
                TableLayout.LayoutParams.WRAP_CONTENT));
    }

    public void InsertElementIntoTableRow(String name, MainActivity context, TableRow tr_head)
    {
        TextView label = new TextView(context);
        label.setId(idx);
        label.setText(name);
        label.setTextColor(Color.WHITE);
        label.setPadding(5, 5, 5, 5);
        tr_head.addView(label);
        idx++;
    }

    boolean HasConnection(Context context)
    {
        NetworkInfo network = ((ConnectivityManager)context.getSystemService(Context.CONNECTIVITY_SERVICE)).getActiveNetworkInfo();
        if (network != null && (
                network.getType()==ConnectivityManager.TYPE_WIFI ||
                        network.getType()==ConnectivityManager.TYPE_MOBILE))
        {
            return true;
        }
        return false;
    }
}
