                      /* Conceptualized and created by Mohit Kishor Mulchandani & Dhrumil Kishor Panchal */

package com.example.mohit.scoringapp;

import android.app.ProgressDialog;
import android.content.Intent;
import android.content.SharedPreferences;
import android.os.AsyncTask;
import android.os.Bundle;
import android.preference.PreferenceManager;
import android.support.v4.app.Fragment;
import android.util.Log;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.AdapterView;
import android.widget.ArrayAdapter;
import android.widget.ListView;
import android.widget.TextView;

import java.util.ArrayList;
import java.util.Arrays;

/**
 * Created by Mohit on 11-Mar-16.
 */
public class Frag2 extends Fragment {
    /**
     * The fragment argument representing the section number for this
     * fragment.
     */
    ListView past;
    ArrayAdapter<String> aa;
    String[] fixtureNames, fixtureId;
    static int ScorerID;

    public Frag2() {
    }

    @Override
    public void setUserVisibleHint(boolean isVisibleToUser) {
        super.setUserVisibleHint(isVisibleToUser);
        if (isVisibleToUser) {
            GetPastFixtures fixtures = new GetPastFixtures();
            fixtures.execute();

        }
    }

    @Override
    public View onCreateView(LayoutInflater inflater, ViewGroup container,
                             Bundle savedInstanceState) {
        View rootView = inflater.inflate(R.layout.frag2, container, false);
        SharedPreferences sp = PreferenceManager.getDefaultSharedPreferences(getActivity());
        ScorerID = sp.getInt("ScorerID", 0);

        past = (ListView) rootView.findViewById(R.id.lvPast);
        past.setOnItemClickListener(new AdapterView.OnItemClickListener() {
            @Override
            public void onItemClick(AdapterView<?> parent, View view, int position, long id) {
                Intent I = new Intent(getActivity(), FixtureHomeActivity.class);
                startActivity(I);
            }
        });
        return rootView;

    }

    public class GetPastFixtures extends AsyncTask<String, String, String> {
        ProgressDialog pd;
        String response;

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
            rp.setParam("type", "Past");
            rp.setParam("ScorerID", String.valueOf(Frag1.ScorerID));

            response = HttpManager.getData(rp).trim();
            /*String Response = response.split("<!--")[0];
            Log.e("Past",Response);*/
            return response;
        }

        @Override
        protected void onPostExecute(String s) {
            super.onPostExecute(s);
            if (s.startsWith("No Fixtures")) {
                pd.dismiss();
                fixtureNames = new String[1];
                fixtureNames[0] = "No Outstanding Fixtures to show";
            } else {
                pd.dismiss();
                fixtureNames = s.split(";");
                fixtureId = new String[fixtureNames.length];
                for (int i = 0; i < fixtureNames.length; i++) {
                    fixtureId[i] = fixtureNames[i].substring(fixtureNames[i].indexOf(":") + 1);
                    fixtureNames[i] = fixtureNames[i].substring(0, fixtureNames[i].indexOf(":"));

                }
            }
            aa = new ArrayAdapter<String>(getActivity(), android.R.layout.simple_list_item_1, fixtureNames);
            past.setAdapter(aa);
        }
    }
}
