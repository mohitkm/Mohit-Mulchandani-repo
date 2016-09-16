                      /* Conceptualized and created by Mohit Kishor Mulchandani & Dhrumil Kishor Panchal */

package android.theopentutorials.com.scoringclientapp;

import android.app.ProgressDialog;
import android.content.Context;
import android.net.Uri;
import android.os.AsyncTask;
import android.os.Bundle;
import android.os.Handler;
import android.speech.tts.TextToSpeech;
import android.support.v4.app.Fragment;
import android.util.Log;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.AdapterView;
import android.widget.ArrayAdapter;
import android.widget.ListView;
import android.widget.TextView;
import android.widget.Toast;

import java.util.ArrayList;
import java.util.Arrays;
import java.util.Locale;


public class FixtureHomeFragment extends Fragment {

    TextView tvFixtureName, tvBattingTeamName, tvOver, tvBattingTeamScore, tvBatsman1, tvBatsman2;
    ListView lvCommentary;
    ArrayAdapter<String> aa;
    ArrayList<String> commentary;
    public static String[] TeamNames;
    public static String[] TeamId;
    private TextToSpeech tts;

    public FixtureHomeFragment() {
        // Required empty public constructor
    }

    @Override
    public void onDestroy() {
        if(tts != null){
            tts.stop();
            tts.shutdown();
        }
        super.onDestroy();
    }

    @Override
    public View onCreateView(LayoutInflater inflater, ViewGroup container,
                             Bundle savedInstanceState) {
        // Inflate the layout for this fragment
        tts = new TextToSpeech(getActivity(), new TextToSpeech.OnInitListener() {
            @Override
            public void onInit(int status) {
                if (status == TextToSpeech.SUCCESS) {
                    int result = tts.setLanguage(Locale.US);
                    if (result == TextToSpeech.LANG_MISSING_DATA
                            || result == TextToSpeech.LANG_NOT_SUPPORTED) {
                        Log.e("TTS", "This Language is not supported");
                    } else {

                    }
                } else {
                    Log.e("Samay", "TTS initialization failed");
                }
            }
        });
        tts.setSpeechRate(0.8f);
        commentary = new ArrayList<>();

        View rootView = inflater.inflate(R.layout.fragment_fixture_home, container, false);
        tvFixtureName = (TextView) rootView.findViewById(R.id.tvFixtureName);
        tvOver = (TextView) rootView.findViewById(R.id.Over);
        tvBatsman1 = (TextView) rootView.findViewById(R.id.Batsman1);
        tvBatsman2 = (TextView) rootView.findViewById(R.id.Batsman2);
        tvBattingTeamName = (TextView) rootView.findViewById(R.id.BattingTeamName);
        tvBattingTeamScore = (TextView) rootView.findViewById(R.id.BattingTeamScore);
        lvCommentary = (ListView) rootView.findViewById(R.id.lvCommentary);

        GetFixtureData task = new GetFixtureData();
        task.execute();

        lvCommentary.setOnItemClickListener(new AdapterView.OnItemClickListener() {
            @Override
            public void onItemClick(AdapterView<?> parent, View view, int position, long id) {
                tts.speak(parent.getItemAtPosition(position).toString(), TextToSpeech.QUEUE_FLUSH, null);
            }
        });
        return rootView;
    }

    public class GetFixtureData extends AsyncTask<String, String, String> {
        ProgressDialog pd;
        String commentary, fixtureData;
        String batsmenScores;
        @Override
        protected void onPreExecute() {
            super.onPreExecute();
            pd = new ProgressDialog(getActivity());
            pd.setIndeterminate(true);
            pd.setMessage("Please wait a moment");
            pd.setCancelable(false);
            pd.show();

        }

        @Override
        protected String doInBackground(String... params) {
            RequestPackage rp = new RequestPackage();
            RequestPackage rp1 = new RequestPackage();
            RequestPackage rp2 = new RequestPackage();
            rp1.setMethod("GET");
            rp2.setMethod("GET");
            rp.setMethod("POST");
            rp.setUri(MainActivity.url);
            rp1.setUri(MainActivity.url);
            rp2.setUri(MainActivity.url);
            rp.setParam("type", "FixtureData");
            rp2.setParam("type", "GetBatsmenScore");
            rp1.setParam("type", "GetCommentary");
            rp.setParam("FixtureID", LiveScoresActivity.fixtureID);
            rp1.setParam("FixtureID", LiveScoresActivity.fixtureID);
            rp2.setParam("FixtureID", LiveScoresActivity.fixtureID);

            fixtureData = HttpManager.getData(rp).trim();
            //fixtureData = FixtureData.split("<!--")[0];
            Log.e("String",fixtureData);

            batsmenScores = HttpManager.getData(rp2).trim();
            //batsmenScores = BatsmenScores.split("<!--")[0];
            Log.e("String",batsmenScores);

            commentary = HttpManager.getData(rp1).trim();
            //commentary = Commentary.split("<!--")[0];
            Log.e("String",commentary);

            return "";
        }

        @Override
        protected void onPostExecute(String s) {
            super.onPostExecute(s);
            try {
                if (pd != null)
                    pd.dismiss();
                Log.e("FixtureData", s);
                String[] data = fixtureData.split(";");
                String[] batScores = batsmenScores.split(";");
                TeamNames = new String[]{"Select Team", data[0], data[2]};
                tvFixtureName.setText(String.format(getResources().getString(R.string.fixture_name), TeamNames[1], TeamNames[2]));
                tvBattingTeamName.setText(data[4] + " ");
                tvBattingTeamScore.setText(data[5]);
                tvOver.setText(data[6]);
                tvBatsman1.setText(batScores[0]);
                tvBatsman2.setText(batScores[1]);


                FixtureHomeFragment.this.commentary.clear();
                FixtureHomeFragment.this.commentary.addAll(Arrays.asList(commentary.split("#####")));
                aa = new ArrayAdapter<String>(getActivity(), android.R.layout.simple_list_item_1, FixtureHomeFragment.this.commentary);
                lvCommentary.setAdapter(aa);


                new Handler().postDelayed(new Runnable() {
                    @Override
                    public void run() {
                        new GetFixtureData().execute();
                    }
                }, 30000);
            } catch (Exception ee) {
                Log.e("Exception", ee.getMessage() + ee.toString());
            }
        }

    }

}

