                      /* Conceptualized and created by Mohit Kishor Mulchandani & Dhrumil Kishor Panchal */

package com.example.mohit.scoringapp;

import android.app.ProgressDialog;
import android.content.Intent;
import android.os.AsyncTask;
import android.os.Bundle;
import android.support.v4.app.Fragment;
import android.text.TextUtils;
import android.util.Log;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.ArrayAdapter;
import android.widget.Button;
import android.widget.Spinner;
import android.widget.TextView;
import android.widget.Toast;

import java.util.Arrays;

/**
 * Created by Mohit on 06-Apr-16.
 */
public class FixtureHomeFragment extends Fragment {
    TextView tvFixtureName, tvStatus, tvUmpire, tvToss, tvFirstBat;
    Spinner spnToss, spnFirstBat;
    Button btnStartScoring;
    public static String[] TeamNames;
    public static String[] TeamId;
    String ScoringType, TotalOvers;
    Intent I1, I2;

    public FixtureHomeFragment() {
    }

    @Override
    public View onCreateView(LayoutInflater inflater, ViewGroup container,
                             Bundle savedInstanceState) {
        View rootView = inflater.inflate(R.layout.fragment_fixture_home, container, false);
        tvFixtureName = (TextView) rootView.findViewById(R.id.tvFixtureName);
        tvStatus = (TextView) rootView.findViewById(R.id.tvStatus);
        spnToss = (Spinner) rootView.findViewById(R.id.spnToss);
        spnFirstBat = (Spinner) rootView.findViewById(R.id.spnFirstBat);
        tvUmpire = (TextView) rootView.findViewById(R.id.tvUmpire);
        tvToss = (TextView) rootView.findViewById(R.id.tvToss);
        tvFirstBat = (TextView) rootView.findViewById(R.id.tvFirstBat);
        btnStartScoring = (Button) rootView.findViewById(R.id.btnStartScoring);
        GetFixtureData data = new GetFixtureData();
        data.execute();
        I1 = new Intent(getActivity(), BasicScoringActivity.class);
        I2 = new Intent(getActivity(), AdvancedScoringActivity.class);

        btnStartScoring.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                if (spnFirstBat.getSelectedItemPosition() == 1) {
                    I1.putExtra("FirstBat", 1);
                    I2.putExtra("FirstBat", 1);
                } else if (spnFirstBat.getSelectedItemPosition() == 2) {
                    I1.putExtra("FirstBat", 2);
                    I2.putExtra("FirstBat", 2);
                }
                I1.putExtra("FixtureID", FixtureHomeActivity.fixtureID);
                I1.putExtra("TotalOvers", Integer.parseInt(TotalOvers));
                I2.putExtra("FixtureID", FixtureHomeActivity.fixtureID);
                I2.putExtra("TotalOvers", Integer.parseInt(TotalOvers));
                I1.putStringArrayListExtra("Team1Players", Team1Fragment.Team1Players);
                I1.putStringArrayListExtra("Team1PlayersIDs", Team1Fragment.Team1PlayersIDs);
                I2.putStringArrayListExtra("Team1Players", Team1Fragment.Team1Players);
                I2.putStringArrayListExtra("Team1PlayersIDs", Team1Fragment.Team1PlayersIDs);

                I1.putStringArrayListExtra("Team2Players", Team2Fragment.Team2Players);
                I1.putStringArrayListExtra("Team2PlayersIDs", Team2Fragment.Team2PlayersIDs);
                I2.putStringArrayListExtra("Team2Players", Team2Fragment.Team2Players);
                I2.putStringArrayListExtra("Team2PlayersIDs", Team2Fragment.Team2PlayersIDs);

                StartScoringTask task = new StartScoringTask();
                task.execute();


            }
        });
        return rootView;
    }

    public class StartScoringTask extends AsyncTask<String, String, String> {
        ProgressDialog pd;
        int firstBat, tossResult;

        @Override
        protected void onPreExecute() {
            super.onPreExecute();
            firstBat = spnFirstBat.getSelectedItemPosition();
            tossResult = spnToss.getSelectedItemPosition();
            pd = new ProgressDialog(getActivity());
            pd.setIndeterminate(true);
            pd.setTitle("Finalizing fixture details");
            pd.setMessage("Please wait a moment");
            pd.setCancelable(false);
            pd.show();

        }

        @Override
        protected String doInBackground(String... params) {
            RequestPackage rp1 = new RequestPackage();
            rp1.setMethod("POST");
            rp1.setUri(LoginActivity.url);
            rp1.setParam("type", "StartScoring");
            rp1.setParam("FixtureID", FixtureHomeActivity.fixtureID);
            rp1.setParam("FirstBat", TeamId[firstBat]);
            rp1.setParam("TossResult", TeamId[tossResult]);
            rp1.setParam("Team1PlayingXI", TextUtils.join(";", Team1Fragment.Team1Players));
            rp1.setParam("Team2PlayingXI", TextUtils.join(";", Team2Fragment.Team2Players));

            String response = HttpManager.getData(rp1).trim();
            /*String Response = response.split("<!--")[0];
            Log.e("Outstanding",Response);*/
            return response;
        }


        @Override
        protected void onPostExecute(String s) {
            super.onPostExecute(s);
            if (s.equals("Success")) {
                if (pd != null)
                    pd.dismiss();

                if (ScoringType.trim().equals("1")) {
                    startActivity(I1);
                    getActivity().finish();
                } else {
                    startActivity(I2);
                    getActivity().finish();
                }
            } else {
                Toast.makeText(getActivity(), s, Toast.LENGTH_LONG).show();
            }
        }
    }

    public class GetFixtureData extends AsyncTask<String, String, String> {
        ProgressDialog pd;

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
            rp.setMethod("POST");
            rp.setUri(LoginActivity.url);
            rp.setParam("type", "FixtureData");
            rp.setParam("FixtureID", FixtureHomeActivity.fixtureID);

            String response = HttpManager.getData(rp).trim();
            //return response.split("<!--")[0];
            return response;

        }

        @Override
        protected void onPostExecute(String s) {
            super.onPostExecute(s);
            if (pd != null)
                pd.dismiss();
            Log.e("FixtureData", s);
            try {
                String[] data = s.split(";");
                TeamNames = new String[]{"Select Team", data[0], data[2]};
                TeamId = new String[]{"", data[1], data[3]};
                ScoringType = data[6];
                TotalOvers = data[7];
                tvFixtureName.setText(String.format(getResources().getString(R.string.fixture_name), TeamNames[1], TeamNames[2]));

                if (data[4].equals("1"))
                    tvStatus.setText("Pending");
                else if (data[4].equals("2")) {
                    tvStatus.setText("Finished");
                    //code to display the toss and first bat team names by making visibility gone and true.. PENDING!!

                } else if (data[4].equals("3"))
                    tvStatus.setText("Running");

                ArrayAdapter<String> aa = new ArrayAdapter<String>(getActivity(), android.R.layout.simple_list_item_1, TeamNames);
                spnFirstBat.setAdapter(aa);
                spnToss.setAdapter(aa);

                tvUmpire.setText(data[5]);

            } catch (Exception e) {
                Toast.makeText(getActivity(), "Some Problem.. Try Again", Toast.LENGTH_LONG).show();
            }
        }
    }
}
