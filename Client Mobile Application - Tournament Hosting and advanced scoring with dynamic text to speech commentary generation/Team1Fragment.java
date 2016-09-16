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
import android.widget.Button;
import android.widget.ListView;
import android.widget.TextView;

import java.util.ArrayList;


public class Team1Fragment extends Fragment {
    ListView lvTeam1Players;
    TextView tvTeam1Name;
    ArrayAdapter<String> aaa;
    ArrayList<String> Team1PlayerNames;
    static ArrayList<String> Team1Players;

    public Team1Fragment() {
        // Required empty public constructor
    }

    @Override
    public View onCreateView(LayoutInflater inflater, ViewGroup container,
                             Bundle savedInstanceState) {
        View rootView = inflater.inflate(R.layout.fragment_team1, container, false);
        lvTeam1Players = (ListView) rootView.findViewById(R.id.lvTeam1Players);
        tvTeam1Name = (TextView) rootView.findViewById(R.id.tvTeam1Name);
        Team1PlayerNames = new ArrayList<>();

        return rootView;
    }

    @Override
    public void setUserVisibleHint(boolean isVisibleToUser) {
        super.setUserVisibleHint(isVisibleToUser);
        if (isVisibleToUser) {
            tvTeam1Name.setText(FixtureHomeFragment.TeamNames[1]);
            if(Team1PlayerNames.isEmpty()) {
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
            rp.setParam("type", "FixtureTeam1");
            rp.setParam("FixtureID", LiveScoresActivity.fixtureID);
            String response = HttpManager.getData(rp).trim();

            //return response.split("<!--")[0];
            return response;
        }

        @Override
        protected void onPostExecute(String s) {
            Log.e("Team1Players",s);
            String[] data = s.split(";");
            for (int i = 0; i < data.length; i++) {
                Team1PlayerNames.add(data[i]);
            }
            aaa = new ArrayAdapter<String>(getActivity(), android.R.layout.simple_list_item_1, Team1PlayerNames);
            lvTeam1Players.setAdapter(aaa);
            if (pd != null)
                pd.dismiss();
        }
    }

}
