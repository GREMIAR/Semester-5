package com.example.lab4;

import android.provider.BaseColumns;

public class SongContract
{
    private SongContract () {}

    public static class FeedEntry implements BaseColumns {
        public static final String TABLE_NAME = "SongTable";
        public static final String Singer = "singer";
        public static final String Song = "song";
        public static final String DateRecording = "dateRecording";
    }
}
