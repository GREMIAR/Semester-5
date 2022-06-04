package com.example.lab4;

import android.content.ContentValues;
import android.content.Context;
import android.database.sqlite.SQLiteDatabase;
import android.database.sqlite.SQLiteOpenHelper;

import java.text.DateFormat;
import java.text.SimpleDateFormat;
import java.util.Calendar;
import java.util.Date;

public class SongDB extends SQLiteOpenHelper {

    public static void InsertInto(String song,String singer,SQLiteDatabase db)
    {
        ContentValues values = new ContentValues();
        values.put(SongContract.FeedEntry.Song, song);
        values.put(SongContract.FeedEntry.Singer, singer);
        Date date = Calendar.getInstance().getTime();
        DateFormat dateFormat = new SimpleDateFormat("yyyy-MM-dd hh:mm:ss");
        values.put(SongContract.FeedEntry.DateRecording, dateFormat.format(date));
        db.insert(SongContract.FeedEntry.TABLE_NAME, null, values);
    }

    public static int DATABASE_VERSION = 1;
    public static final String DATABASE_NAME = "SongDB.db";

    final String SQL_CREATE_ENTRIES =
            "CREATE TABLE " + SongContract.FeedEntry.TABLE_NAME + " (" +
                    SongContract.FeedEntry._ID + " INTEGER PRIMARY KEY AUTOINCREMENT," +
                    SongContract.FeedEntry.Song + " TEXT," +
                    SongContract.FeedEntry.Singer + " TEXT," +
                    SongContract.FeedEntry.DateRecording + " DATETIME);";

    static final String SQL_DELETE_ENTRIES =
            "DROP TABLE IF EXISTS " + SongContract.FeedEntry.TABLE_NAME;

    public SongDB(Context context) {
        super(context, DATABASE_NAME, null, DATABASE_VERSION);
    }

    public void onCreate(SQLiteDatabase db) {
        db.execSQL(SQL_CREATE_ENTRIES);
    }

    public void onUpgrade(SQLiteDatabase db, int oldVersion, int newVersion) {
        db.execSQL(SQL_DELETE_ENTRIES);
        onCreate(db);
    }

    public void onDowngrade(SQLiteDatabase db, int oldVersion, int newVersion) {
        onUpgrade(db, oldVersion, newVersion);
    }
}
