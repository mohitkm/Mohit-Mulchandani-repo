                      /* Conceptualized and created by Mohit Kishor Mulchandani & Dhrumil Kishor Panchal */

package android.theopentutorials.com.scoringclientapp;

import android.app.ProgressDialog;
import android.content.Context;
import android.net.Uri;
import android.os.AsyncTask;
import android.os.Bundle;
import android.support.v4.app.Fragment;
import android.util.Log;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.ArrayAdapter;
import android.widget.ListView;
import android.widget.TextView;

import java.util.ArrayList;


public class Team2Fragment extends Fragment {
    ListView lvTeam2Players;
    TextView tvTeam2Name;
    ArrayAdapter<String> aa;
    ArrayList<String> Team2PlayerNames;
    static ArrayList<String> Team2Players;

    public Team2Fragment() {
        // Required empty public constructor
    }

    @Override
    public View onCreateView(LayoutInflater inflater, ViewGroup container,
                             Bundle savedInstanceState) {
        View rootView = inflater.inflate(R.layout.fragment_team2, container, false);
        lvTeam2Players = (ListView) rootView.findViewById(R.id.lvTeam2Players);
        tvTeam2Name = (TextView) rootView.findViewById(R.id.tvTeam2Name);
        Team2PlayerNames = new ArrayList<>();

        return rootView;
    }

    @Override
    public void setUserVisibleHint(boolean isVisibleToUser) {
        super.setUserVisibleHint(isVisibleToUser);
        if (isVisibleToUser) {
            tvTeam2Name.setText(FixtureHomeFragment.TeamNames[2]);
            if(Team2PlayerNames.isEmpty()) {
                GetFixtureTeam team = new GetFixtureTeam();
                team.execute();
            }
        }
    }

    public class GetFixtureTeam extends AsyncTask<String, String, String> {
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
            rp.setMethod("GET");
            rp.setUri(MainActivity.url);
            rp.setParam("type", "FixtureTeam2");
            rp.setParam("FixtureID", LiveScoresActivity.fixtureID);
            Log.e("error", "request");
            String response = HttpManager.getData(rp).trim();

            //return response.split("<!--")[0];
            return response;
        }

        @Override
        protected void onPostExecute(String s) {
            Log.e("Team2Players", s);
            String[] data = s.split(";");
            for (int i = 0; i < data.length; i++) {
                Team2PlayerNames.add(data[i]);
            }
            aa = new ArrayAdapter<String>(getActivity(), android.R.layout.simple_list_item_1, Team2PlayerNames);
            lvTeam2Players.setAdapter(aa);
            if (pd != null)
                pd.dismiss();
        }
    }
}
