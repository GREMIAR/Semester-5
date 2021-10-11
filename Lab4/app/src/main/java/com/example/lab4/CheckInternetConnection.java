package com.example.lab4;

import android.content.Context;
import android.net.ConnectivityManager;
import android.net.NetworkInfo;
import android.os.AsyncTask;
import android.widget.Toast;

public class CheckInternetConnection extends AsyncTask<String, Integer, Void> {

    Context context;

    public CheckInternetConnection(Context c)
    {
        context = c;
    }

    public void setContext(Context c){
        context = c;
    }

    @Override
    protected Void doInBackground(String... strings) {
        while(true)
        {
            if (!HasConnection(context)) {
                publishProgress();
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
     Toast toast = Toast.makeText(context,
             "Нет подключения к интернету!", Toast.LENGTH_SHORT);
     toast.show();
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
