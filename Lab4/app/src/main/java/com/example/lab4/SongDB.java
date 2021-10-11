package com.example.lab4;

import android.content.Context;
import android.database.sqlite.SQLiteDatabase;
import android.database.sqlite.SQLiteOpenHelper;

public class SongDB extends SQLiteOpenHelper {
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
