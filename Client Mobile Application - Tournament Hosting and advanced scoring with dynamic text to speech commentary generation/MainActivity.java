                      /* Conceptualized and created by Mohit Kishor Mulchandani & Dhrumil Kishor Panchal */

package android.theopentutorials.com.scoringclientapp;

import android.app.ProgressDialog;
import android.content.Intent;
import android.content.SharedPreferences;
import android.os.AsyncTask;
import android.preference.PreferenceManager;
import android.support.v7.app.AppCompatActivity;
import android.os.Bundle;
import android.util.Log;
import android.view.View;
import android.widget.AdapterView;
import android.widget.ArrayAdapter;
import android.widget.ListView;
import android.widget.TextView;
import android.widget.Toast;

public class MainActivity extends AppCompatActivity {

    public static final String url = "http://10.0.2.112/TournamentWeb/ClientAndroid.aspx";
    private ListView lvAvailableLiveMatches;
    private TextView tvNoLiveMatches;
    ArrayAdapter<String> aa;
    String[] fixtureNames, fixtureId;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);

        lvAvailableLiveMatches = (ListView)findViewById(R.id.lvAvailableLiveMatches);
        tvNoLiveMatches = (TextView)findViewById(R.id.tvNoLiveMatches);

        MainTask fixtures = new MainTask();
        fixtures.execute();

        lvAvailableLiveMatches.setOnItemClickListener(new AdapterView.OnItemClickListener() {
            @Override
            public void onItemClick(AdapterView<?> parent, View view, int position, long id) {
                Intent I = new Intent(MainActivity.this, LiveScoresActivity.class);
                I.putExtra("FixtureID",fixtureId[position]);
                startActivity(I);
            }
        });

    }

    class MainTask extends AsyncTask<String,String,String> {
        ProgressDialog pd;
        String response;

        @Override
        protected void onPreExecute() {
            super.onPreExecute();
            pd = new ProgressDialog(MainActivity.this);
            pd.setIndeterminate(true);
            pd.setMessage("Please wait a moment");
            pd.setCancelable(false);
            pd.show();

        }

        @Override
        protected String doInBackground(String... params) {
            RequestPackage rp = new RequestPackage();
            rp.setMethod("GET");
            rp.setUri(MainActivity.url);
            rp.setParam("type", "GetLiveMatches");

            response = HttpManager.getData(rp).trim();
            Log.e("String",response);
            /*String Response = response.split("<!--")[0];
            */
            return response;
        }

        @Override
        protected void onPostExecute(String s) {
            if(response.startsWith("Failed")){
                pd.dismiss();
                tvNoLiveMatches.setVisibility(View.VISIBLE);
            }
            else{
                try {
                    pd.dismiss();
                    fixtureNames = s.split(";");
                    fixtureId = new String[fixtureNames.length];
                    for (int i = 0; i < fixtureNames.length; i++) {
                        fixtureId[i] = fixtureNames[i].substring(fixtureNames[i].indexOf(":") + 1);
                        fixtureNames[i] = fixtureNames[i].substring(0, fixtureNames[i].indexOf(":"));
                    }
                    aa = new ArrayAdapter<String>(MainActivity.this, android.R.layout.simple_list_item_1, fixtureNames);
                    lvAvailableLiveMatches.setAdapter(aa);
                }catch (Exception e){
                    Toast.makeText(MainActivity.this,"Some problem",Toast.LENGTH_LONG).show();
                }
            }

        }

    }
}
