                      /* Conceptualized and created by Mohit Kishor Mulchandani & Dhrumil Kishor Panchal */

package com.example.mohit.scoringapp;

import android.app.ProgressDialog;
import android.content.SharedPreferences;
import android.os.AsyncTask;
import android.os.Bundle;
import android.preference.PreferenceManager;
import android.support.v4.app.Fragment;
import android.util.SparseBooleanArray;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.ArrayAdapter;
import android.widget.Button;
import android.widget.ListView;
import android.widget.TextView;

import java.lang.reflect.Array;
import java.util.ArrayList;
import java.util.Arrays;
import java.util.HashSet;
import java.util.Set;

/**
 * Created by Mohit on 06-Apr-16.
 */
public class Team2Fragment extends Fragment {
    ListView lvTeam2Players;
    TextView tvTeam2Name;
    ArrayAdapter<String> aa;
    ArrayList<String> Team2PlayerNames,Team2PlayerIDs;
    static ArrayList<String> Team2Players,Team2PlayersIDs;
    Button btnConfirmTeam;
    SharedPreferences sp;


    public Team2Fragment() {
    }

    @Override
    public View onCreateView(LayoutInflater inflater, ViewGroup container,
                             Bundle savedInstanceState) {
        View rootView = inflater.inflate(R.layout.fragment_team2, container, false);
        sp = PreferenceManager.getDefaultSharedPreferences(getActivity());
        lvTeam2Players = (ListView)rootView.findViewById(R.id.lvTeam2Players);
        tvTeam2Name = (TextView)rootView.findViewById(R.id.tvTeam2Name);
        btnConfirmTeam = (Button)rootView.findViewById(R.id.btnConfirmTeam);

        Team2PlayerNames = new ArrayList<>();
        Team2PlayerIDs = new ArrayList<>();
        Team2PlayersIDs = new ArrayList<>();
        btnConfirmTeam.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                SparseBooleanArray checked = lvTeam2Players.getCheckedItemPositions();
                Team2Players = new ArrayList<String>();
                for (int i = 0; i < checked.size(); i++) {
                    // Item position in adapter
                    int position = checked.keyAt(i);
                    // Add sport if it is checked i.e.) == TRUE!
                    if (checked.valueAt(i)) {
                        Team2Players.add(aa.getItem(position));
                        Team2PlayersIDs.add(Team2PlayerIDs.get(position));
                    }
                }
                //sp.edit().putStringSet("Team2PlayerNames", new HashSet<String>(Team2PlayerNames)).apply();
                //sp.edit().putStringSet("Team2PlayerIDs", new HashSet<String>(Team2PlayerIDs)).apply();
                v.setEnabled(false);
            }
        });
        return rootView;
    }

    @Override
    public void setUserVisibleHint(boolean isVisibleToUser) {
        super.setUserVisibleHint(isVisibleToUser);
        if(isVisibleToUser) {
            tvTeam2Name.setText(FixtureHomeFragment.TeamNames[2]);
            if(Team2PlayerNames.isEmpty()) {
                GetFixtureTeam team = new GetFixtureTeam();
                team.execute();
            }

        }
    }

    public class GetFixtureTeam extends AsyncTask<String,String,String> {
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
            rp.setParam("type", "FixtureTeam2");
            rp.setParam("TeamID", FixtureHomeFragment.TeamId[2]);

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
                    Team2PlayerNames.add(data[i]);
                else
                    Team2PlayerIDs.add(data[i]);
            }
            aa = new ArrayAdapter<String>(getActivity(),android.R.layout.simple_list_item_multiple_choice,Team2PlayerNames);
            lvTeam2Players.setChoiceMode(ListView.CHOICE_MODE_MULTIPLE);
            lvTeam2Players.setAdapter(aa);

            if (pd != null)
                pd.dismiss();
        }
    }

}
