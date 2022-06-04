package com.example.lab311;

import android.content.Context;
import android.database.sqlite.SQLiteDatabase;
import android.database.sqlite.SQLiteOpenHelper;
import android.provider.BaseColumns;


public class OurDB extends SQLiteOpenHelper{
    public static int DATABASE_VERSION = 1;
    public static final String DATABASE_NAME = "OurDB.db";

    final String SQL_CREATE_ENTRIES =
            "CREATE TABLE " + OurContractTest.FeedEntry.TABLE_NAME + " (" +
                    OurContractTest.FeedEntry._ID + " INTEGER PRIMARY KEY AUTOINCREMENT," +
                    OurContractTest.FeedEntry.LastName + " TEXT," +
                    OurContractTest.FeedEntry.FirstName + " TEXT," +
                    OurContractTest.FeedEntry.Patronymic + " TEXT,"+
    OurContractTest.FeedEntry.DateRecording + " DATETIME);";

    final String SQL_CREATE_ENTRIES_V2 =
            "CREATE TABLE " + OurContractTest.FeedEntry.TABLE_NAME + " (" +
                    OurContractTest.FeedEntry._ID + " INTEGER PRIMARY KEY AUTOINCREMENT," +
                    OurContractTest.FeedEntry.Name + " TEXT," +
                    OurContractTest.FeedEntry.DateRecording + " DATETIME);";

    private static final String SQL_DELETE_ENTRIES =
            "DROP TABLE IF EXISTS " + OurContractTest.FeedEntry.TABLE_NAME;


    public OurDB(Context context) {
        super(context, DATABASE_NAME, null, DATABASE_VERSION);
    }

    public void onCreate(SQLiteDatabase db) {
        if(DATABASE_VERSION==1) {
            db.execSQL(SQL_CREATE_ENTRIES);
        }
        else if (DATABASE_VERSION==2)
        {
            db.execSQL(SQL_CREATE_ENTRIES_V2);
        }
    }

    public void onUpgrade(SQLiteDatabase db, int oldVersion, int newVersion) {
        db.execSQL(SQL_DELETE_ENTRIES);
        DATABASE_VERSION = newVersion;
    }

    public void onDowngrade(SQLiteDatabase db, int oldVersion, int newVersion) {
        onUpgrade(db, oldVersion, newVersion);
    }

}
