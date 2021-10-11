package com.example.lab311;

import android.provider.BaseColumns;

public final class OurContractTest {
    private OurContractTest() {}

    public static class FeedEntry implements BaseColumns {
        public static final String TABLE_NAME = "ClassMates";
        public static final String LastName = "lastName";
        public static final String FirstName = "firstName";
        public static final String Patronymic = "patronymic";
        public static final String DateRecording = "dateRecording";
        public static final String Name = "name";

    }
}

