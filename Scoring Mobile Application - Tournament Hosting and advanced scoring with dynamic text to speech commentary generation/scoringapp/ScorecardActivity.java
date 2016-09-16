                      /* Conceptualized and created by Mohit Kishor Mulchandani & Dhrumil Kishor Panchal */

package com.example.mohit.scoringapp;

import android.support.v7.app.AppCompatActivity;
import android.os.Bundle;
import android.widget.ListView;
import android.widget.SimpleAdapter;

import java.util.ArrayList;
import java.util.HashMap;

public class ScorecardActivity extends AppCompatActivity {

    ListView lvScorecard;
    String[] from = {"Name","Runs"};
    int[] to = {android.R.id.text1,android.R.id.text2};
    SimpleAdapter sa;
    ArrayList<HashMap<String,String>> data;
    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_scorecard);

        lvScorecard = (ListView)findViewById(R.id.lvScorecard);
        data = (ArrayList<HashMap<String,String>>)getIntent().getSerializableExtra("Batting Team 1 Scorecard");
        sa = new SimpleAdapter(this,data,android.R.layout.simple_list_item_2,from,to);
        lvScorecard.setAdapter(sa);
    }
}
