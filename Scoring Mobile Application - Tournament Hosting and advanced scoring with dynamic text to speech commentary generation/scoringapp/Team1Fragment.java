                      /* Conceptualized and created by Mohit Kishor Mulchandani & Dhrumil Kishor Panchal */

package com.example.mohit.scoringapp;

import android.app.ProgressDialog;
import android.content.SharedPreferences;
import android.os.AsyncTask;
import android.os.Bundle;
import android.preference.PreferenceManager;
import android.support.v4.app.Fragment;
import android.util.Log;
import android.util.SparseBooleanArray;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.ArrayAdapter;
import android.widget.Button;
import android.widget.ListView;
import android.widget.TextView;

import java.util.ArrayList;
import java.util.Arrays;
import java.util.HashSet;
import java.util.Set;

/**
 * Created by Mohit on 06-Apr-16.
 */
public class Team1Fragment extends Fragment {
    ListView lvTeam1Players;
    TextView tvTeam1Name;
    Button btnConfirmTeam;
    ArrayAdapter<String> aa;
    ArrayList<String> Team1PlayerNames;
    static ArrayList<String> Team1Players;
    ArrayList<String> Team1PlayerIDs;
    static ArrayList<String> Team1PlayersIDs;
    SharedPreferences sp;
    public Team1Fragment() {

    }

    @Override
    public View onCreateView(LayoutInflater inflater, ViewGroup container,
                             Bundle savedInstanceState) {
        View rootView = inflater.inflate(R.layout.fragment_team1, container, false);
        lvTeam1Players = (ListView)rootView.findViewById(R.id.lvTeam1Players);
        tvTeam1Name = (TextView)rootView.findViewById(R.id.tvTeam1Name);
        btnConfirmTeam = (Button)rootView.findViewById(R.id.btnConfirmTeam);
        Team1PlayerNames = new ArrayList<>();
        Team1PlayerIDs = new ArrayList<>();
        Team1PlayersIDs = new ArrayList<>();
        sp = PreferenceManager.getDefaultSharedPreferences(getActivity());
        btnConfirmTeam.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                SparseBooleanArray checked = lvTeam1Players.getCheckedItemPositions();
                Team1Players = new ArrayList<String>();
                for (int i = 0; i < checked.size(); i++) {
                    int position = checked.keyAt(i);
                    // Add sport if it is checked i.e.) == TRUE!
                    if (checked.valueAt(i)) {
                        Team1Players.add(aa.getItem(position));
                        Team1PlayersIDs.add(Team1PlayerIDs.get(position));
                    }
                }
                    //sp.edit().putStringSet("Team1PlayerNames", new HashSet<String>(Team1PlayerNames)).apply();
                    //sp.edit().putStringSet("Team1PlayerIDs", new HashSet<String>(Team1PlayerIDs)).apply();
                v.setEnabled(false);
            }
        });
        return rootView;

    }

    @Override
    public void setUserVisibleHint(boolean isVisibleToUser) {
        super.setUserVisibleHint(isVisibleToUser);
        if(isVisibleToUser){
            tvTeam1Name.setText(FixtureHomeFragment.TeamNames[1]);
            if(Team1PlayerNames.isEmpty()) {
                GetFixtureTeam team = new GetFixtureTeam();
                team.execute();
            }

        }
    }

    public class GetFixtureTeam extends AsyncTask<String,String,String>{
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
            rp.setUri(LoginActivity.url);
            rp.setParam("type", "FixtureTeam1");
            String id = FixtureHomeFragment.TeamId[1];
            rp.setParam("TeamID", id);
            Log.e("error","request");

            String Response = HttpManager.getData(rp).trim();
            //return Response.split("<!--")[0];
            return Response;
        }

        @Override
        protected void onPostExecute(String s) {
            super.onPostExecute(s);
            String[] data = s.split(";");
            for(int i = 0;i<data.length;i++) {
                if(i%2 == 0)
                    Team1PlayerNames.add(data[i]);
                else
                    Team1PlayerIDs.add(data[i]);
            }
            aa = new ArrayAdapter<String>(getActivity(),android.R.layout.simple_list_item_multiple_choice,Team1PlayerNames);
            lvTeam1Players.setChoiceMode(ListView.CHOICE_MODE_MULTIPLE);
            lvTeam1Players.setAdapter(aa);
            if (pd != null)
                pd.dismiss();
        }
    }

}
