                      /* Conceptualized and created by Mohit Kishor Mulchandani & Dhrumil Kishor Panchal */

package com.example.mohit.scoringapp;

import android.app.ProgressDialog;
import android.content.Intent;
import android.content.SharedPreferences;
import android.net.Uri;
import android.os.AsyncTask;
import android.preference.PreferenceManager;
import android.support.v7.app.AppCompatActivity;
import android.os.Bundle;
import android.util.Log;
import android.view.View;
import android.widget.Button;
import android.widget.EditText;
import android.widget.Toast;

public class LoginActivity extends AppCompatActivity {
    EditText etEmail,etPassword;
    Button btnLogin;
    static String email,password;
    public static String url = "http://10.0.2.112/TournamentWeb/AndroidSupport.aspx";
    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_login);

        etEmail = (EditText)findViewById(R.id.etEmail);
        etPassword = (EditText)findViewById(R.id.etPassword);
        btnLogin = (Button)findViewById(R.id.btnLogin);

        btnLogin.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                email = etEmail.getText().toString();
                password = etPassword.getText().toString();
                LoginTask l = new LoginTask();
                l.execute();

            }
        });

    }

    class LoginTask extends AsyncTask<String,String,String>{
        ProgressDialog pd;
        String response;

        @Override
        protected void onPreExecute() {
            super.onPreExecute();
            pd = new ProgressDialog(LoginActivity.this);
            pd.setIndeterminate(true);
            pd.setMessage("Please wait a moment");
            pd.setCancelable(false);
            pd.show();

        }

        @Override
        protected String doInBackground(String... params) {
            RequestPackage rp = new RequestPackage();
            rp.setMethod("GET");
            rp.setUri(url);
            rp.setParam("type", "Login");
            rp.setParam("email", LoginActivity.email);
            rp.setParam("password", LoginActivity.password);

            response = HttpManager.getData(rp).trim();
            /*String Response = response.split("<!--")[0];*/
            Log.e("string",response);
            return response;
        }

        @Override
        protected void onPostExecute(String s) {
            if(s.startsWith("Failed")){
                pd.dismiss();
                Toast.makeText(LoginActivity.this,"Invalid username or password",Toast.LENGTH_LONG).show();
            }
            else{
                try {
                    pd.dismiss();
                    SharedPreferences sp = PreferenceManager.getDefaultSharedPreferences(LoginActivity.this);
                    sp.edit().putInt("ScorerID", Integer.parseInt(s)).apply();
                    Intent I = new Intent(LoginActivity.this, ScorerHomeActivity.class);
                    startActivity(I);
                    finish();
                }catch (Exception e){
                    Toast.makeText(LoginActivity.this,"Some problem",Toast.LENGTH_LONG).show();
                }
            }

        }

    }
}
