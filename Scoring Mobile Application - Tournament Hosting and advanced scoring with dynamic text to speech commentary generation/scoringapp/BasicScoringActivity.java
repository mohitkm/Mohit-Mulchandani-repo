                      /* Conceptualized and created by Mohit Kishor Mulchandani & Dhrumil Kishor Panchal */

package com.example.mohit.scoringapp;

import android.app.Dialog;
import android.app.ProgressDialog;
import android.content.DialogInterface;
import android.content.Intent;
import android.content.SharedPreferences;
import android.os.AsyncTask;
import android.preference.PreferenceManager;
import android.support.annotation.NonNull;
import android.support.v4.app.DialogFragment;
import android.support.v7.app.AlertDialog;
import android.support.v7.app.AppCompatActivity;
import android.os.Bundle;
import android.text.Html;
import android.util.Log;
import android.view.Gravity;
import android.view.View;
import android.widget.AdapterView;
import android.widget.ArrayAdapter;
import android.widget.Button;
import android.widget.CompoundButton;
import android.widget.ImageButton;
import android.widget.LinearLayout;
import android.widget.ListView;
import android.widget.Spinner;
import android.widget.TextView;
import android.widget.Toast;
import android.widget.ToggleButton;

import java.util.ArrayList;
import java.util.Arrays;
import java.util.HashMap;
import java.util.HashSet;

public class BasicScoringActivity extends AppCompatActivity implements View.OnClickListener {

    Delivery bean = new Delivery();

    HashMap<String, String> map;
    ArrayList<HashMap<String, String>> data;

    private Spinner spnBowler, spnBatsman1, spnBatsman2, spnExtraType, spnDismissal;
    private ListView lvShotType, lvShotDirection, lvShotElevation;
    private ListView lvDeliveryType, lvDeliveryLength, lvDeliveryLine;
    private ToggleButton btn0Run, btn1Run, btn2Run, btn3Run, btn4Run, btn6Run;
    private Button btnSave, btnNext;
    private ImageButton btnSwitchBat;
    private TextView tvOvers, tvScore;
    private TextView tvBowlerStats, tvBat1Score, tvBat2Score;
    private TextView tvInnings;

    private String[] Team1PlayerNames, Team2PlayerNames, Team1PlayerIDs, Team2PlayerIDs, BattingTeamIDs, BowlingTeamIDs;
    private int runs, deliveryRun, deliveryExtra;
    private int bat1run, bat2run, bat1balls, bat2balls;
    private int firstBat;
    private static int balls;
    private int wickets, overs, ball;
    private boolean bat1strike = true;
    private boolean batsmanOut = false;
    private boolean batsmanRunOut = false;
    private int selectedIndex;

    SharedPreferences sp;
    @Override
    public void onBackPressed() {
        Toast.makeText(this,"Live match scoring on. Press home to exit",Toast.LENGTH_LONG).show();
    }

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_basic_scoring);

        sp = PreferenceManager.getDefaultSharedPreferences(this);
        firstBat = getIntent().getIntExtra("FirstBat", 0);
        bean.FixtureID = Integer.parseInt(getIntent().getStringExtra("FixtureID"));
        Team1PlayerNames = sp.getStringSet("Team1PlayerNames", new HashSet<String>()).toArray(new String[0]);
        Team2PlayerNames = sp.getStringSet("Team2PlayerNames", new HashSet<String>()).toArray(new String[0]);
        Team1PlayerIDs = sp.getStringSet("Team1PlayerIDs", new HashSet<String>()).toArray(new String[0]);
        Team2PlayerIDs = sp.getStringSet("Team2PlayerIDs", new HashSet<String>()).toArray(new String[0]);
        balls = 0;
        runs = 0;
        wickets = 0;
        overs = ball = 0;
        deliveryRun = deliveryExtra = 0;
        bat1run = bat2run = bat1balls = bat2balls = 0;
        findViews();
        setListViews();
        setListeners();
        tvScore.setText(getResources().getString(R.string.score, runs, wickets));
        tvOvers.setText(getResources().getString(R.string.overs, overs, ball));
        tvBat1Score.setText(getResources().getString(R.string.batScore, bat1run, bat1balls));
        tvBat2Score.setText(getResources().getString(R.string.batScore, bat2run, bat2balls));
        tvInnings.setText(Html.fromHtml("1<sup><small>st</small></sup>   Innings"));

    }

    private void findViews() {
        map = new HashMap<String, String>();
        data = new ArrayList<HashMap<String, String>>();

        btn0Run = (ToggleButton) findViewById(R.id.btn0Run);
        btn1Run = (ToggleButton) findViewById(R.id.btn1Run);
        btn2Run = (ToggleButton) findViewById(R.id.btn2Run);
        btn3Run = (ToggleButton) findViewById(R.id.btn3Run);
        btn4Run = (ToggleButton) findViewById(R.id.btn4Run);
        btn6Run = (ToggleButton) findViewById(R.id.btn6Run);

        btnSwitchBat = (ImageButton) findViewById(R.id.btnSwitch);

        btnSave = (Button) findViewById(R.id.btnSave);

        tvOvers = (TextView) findViewById(R.id.tvOvers);
        tvScore = (TextView) findViewById(R.id.tvScore);

        tvBat1Score = (TextView) findViewById(R.id.tvBat1Score);
        tvBat2Score = (TextView) findViewById(R.id.tvBat2Score);
        tvBowlerStats = (TextView) findViewById(R.id.tvBowlerStats);
        tvInnings = (TextView) findViewById(R.id.tvInnings);

        spnBatsman1 = (Spinner) findViewById(R.id.spnBatsman1);
        spnBatsman2 = (Spinner) findViewById(R.id.spnBatsman2);
        spnBowler = (Spinner) findViewById(R.id.spnBowler);
        spnExtraType = (Spinner) findViewById(R.id.spnExtraType);
        spnDismissal = (Spinner) findViewById(R.id.spnDismissal);

        spnBatsman1.setBackgroundColor(getResources().getColor(R.color.green));
        spnBatsman2.setBackgroundColor(getResources().getColor(R.color.red));
    }

    private void setListViews() {
        ArrayAdapter<String> extraTypeAdapter;
        ArrayAdapter<String> batsman1Adapter, batsman2Adapter, bowlerAdapter;
        ArrayAdapter<String> dismissalAdapter;
        ArrayList<String> batsman1 = null, batsman2 = null, bowler = null;

        ArrayList<String> extraType = new ArrayList<>(Arrays.asList(getResources().getStringArray(R.array.extraType)));
        extraType.add(0, "None");
        extraTypeAdapter = new ArrayAdapter<String>(this, android.R.layout.simple_list_item_1, extraType);
        spnExtraType.setAdapter(extraTypeAdapter);

        if (firstBat == 1) {
            batsman1 = new ArrayList<>(Arrays.asList(Team1PlayerNames));
            batsman2 = new ArrayList<>(Arrays.asList(Team1PlayerNames));
            bowler = new ArrayList<>(Arrays.asList(Team2PlayerNames));
            BattingTeamIDs = Team1PlayerIDs.clone();
            BowlingTeamIDs = Team2PlayerIDs.clone();
        } else if (firstBat == 2) {
            batsman1 = new ArrayList<>(Arrays.asList(Team2PlayerNames));
            batsman2 = new ArrayList<>(Arrays.asList(Team2PlayerNames));
            bowler = new ArrayList<>(Arrays.asList(Team1PlayerNames));
            BattingTeamIDs = Team2PlayerIDs.clone();
            BowlingTeamIDs = Team1PlayerIDs.clone();
        }
        batsman1Adapter = new ArrayAdapter<String>(this, android.R.layout.simple_list_item_1, batsman1);
        batsman2Adapter = new ArrayAdapter<String>(this, android.R.layout.simple_list_item_1, batsman2);
        batsman1.add(0, "Batsman 1");
        batsman2.add(0, "Batsman 2");
        spnBatsman1.setAdapter(batsman1Adapter);
        spnBatsman2.setAdapter(batsman2Adapter);

        bowlerAdapter = new ArrayAdapter<String>(this, android.R.layout.simple_list_item_1, bowler);
        bowler.add(0, "Select Bowler");
        spnBowler.setAdapter(bowlerAdapter);

        ArrayList<String> dismissalType = new ArrayList<>(Arrays.asList(getResources().getStringArray(R.array.dismissalType)));
        dismissalType.add(0, "Not Out");
        dismissalAdapter = new ArrayAdapter<String>(this, android.R.layout.simple_list_item_1, dismissalType);
        spnDismissal.setAdapter(dismissalAdapter);

    }

    private void setListeners() {
        btnSwitchBat.setOnClickListener(this);
        btnSave.setOnClickListener(this);
        btn0Run.setOnCheckedChangeListener(new CompoundButton.OnCheckedChangeListener() {
            @Override
            public void onCheckedChanged(CompoundButton buttonView, boolean isChecked) {
                if (isChecked)
                    deliveryRun = 0;
            }
        });
        btn1Run.setOnCheckedChangeListener(new CompoundButton.OnCheckedChangeListener() {
            @Override
            public void onCheckedChanged(CompoundButton buttonView, boolean isChecked) {
                if (isChecked)
                    deliveryRun = 1;
            }
        });
        btn2Run.setOnCheckedChangeListener(new CompoundButton.OnCheckedChangeListener() {
            @Override
            public void onCheckedChanged(CompoundButton buttonView, boolean isChecked) {
                if (isChecked)
                    deliveryRun = 2;
            }
        });
        btn3Run.setOnCheckedChangeListener(new CompoundButton.OnCheckedChangeListener() {
            @Override
            public void onCheckedChanged(CompoundButton buttonView, boolean isChecked) {
                if (isChecked)
                    deliveryRun = 3;
            }
        });
        btn4Run.setOnCheckedChangeListener(new CompoundButton.OnCheckedChangeListener() {
            @Override
            public void onCheckedChanged(CompoundButton buttonView, boolean isChecked) {
                if (isChecked)
                    deliveryRun = 4;
            }
        });
        btn6Run.setOnCheckedChangeListener(new CompoundButton.OnCheckedChangeListener() {
            @Override
            public void onCheckedChanged(CompoundButton buttonView, boolean isChecked) {
                if (isChecked)
                    deliveryRun = 6;
            }
        });
        spnDismissal.setOnItemSelectedListener(new AdapterView.OnItemSelectedListener() {
            @Override
            public void onItemSelected(AdapterView<?> parent, View view, int position, long id) {
                String dismissal = (String) parent.getItemAtPosition(position);
                bean.DismissalType = position;
                if (dismissal.equals("Not Out")) {
                    bean.DismissedPlayers = 0;
                } else if (dismissal.equals("Run Out")) {
                    String[] batsmen = new String[2];
                    batsmen[0] = (String) spnBatsman1.getSelectedItem();
                    batsmen[1] = (String) spnBatsman2.getSelectedItem();
                    DialogFragment fragment = new SelectDismissedBatsmanDialogFragment(batsmen);
                    fragment.show(getSupportFragmentManager(), "runout");
                } else {
                    batsmanOut = true;
                }
            }

            @Override
            public void onNothingSelected(AdapterView<?> parent) {

            }
        });

        spnExtraType.setOnItemSelectedListener(new AdapterView.OnItemSelectedListener() {
            @Override
            public void onItemSelected(AdapterView<?> parent, View view, int position, long id) {
                bean.ExtraType = position;
                if (position != 0) {
                    DialogFragment fragment = new EnterExtrasDialogFragment();
                    fragment.show(getSupportFragmentManager(), "extras");
                    if (position == 1 || position == 2) {
                        balls++;
                    }
                }

            }

            @Override
            public void onNothingSelected(AdapterView<?> parent) {

            }
        });
    }

    public class EnterExtrasDialogFragment extends DialogFragment {
        @NonNull
        @Override
        public Dialog onCreateDialog(Bundle savedInstanceState) {
            AlertDialog.Builder builder = new AlertDialog.Builder(BasicScoringActivity.this);
            builder.setTitle("Enter extra runs")
                    .setItems(getResources().getStringArray(R.array.extras), new DialogInterface.OnClickListener() {
                        @Override
                        public void onClick(DialogInterface dialog, int which) {
                            deliveryExtra = which + 1;
                        }
                    });
            return builder.create();
        }
    }

    public class SelectDismissedBatsmanDialogFragment extends DialogFragment {
        String[] batsmen;

        public SelectDismissedBatsmanDialogFragment() {
        }

        public SelectDismissedBatsmanDialogFragment(String[] batsmen) {
            this.batsmen = batsmen;
        }

        @NonNull
        @Override
        public Dialog onCreateDialog(Bundle savedInstanceState) {
            AlertDialog.Builder builder = new AlertDialog.Builder(BasicScoringActivity.this);
            builder.setTitle("Dismissed Batsman")
                    .setSingleChoiceItems(batsmen, 0, new DialogInterface.OnClickListener() {
                        @Override
                        public void onClick(DialogInterface dialog, int which) {
                            selectedIndex = which;
                        }
                    })
                    .setPositiveButton(R.string.dialog_string_ok, new DialogInterface.OnClickListener() {
                        @Override
                        public void onClick(DialogInterface dialog, int which) {
                            /*if (selectedIndex == 0) {
                                map.put("Name", spnBatsman1.getSelectedItem().toString());
                                map.put("Runs", tvBat1Score.getText().toString());
                                data.add(map);
                                bean.DismissedPlayers = Integer.parseInt(BattingTeamIDs[(spnBatsman1.getSelectedItemPosition()) - 1]);
                                spnBatsman1.setSelection(0);
                                bat1run = 0;
                                bat1balls = -1;
                                wickets++;
                            } else {
                                map.put("Name", spnBatsman2.getSelectedItem().toString());
                                map.put("Runs", tvBat2Score.getText().toString());
                                data.add(map);
                                bean.DismissedPlayers = Integer.parseInt(BattingTeamIDs[(spnBatsman2.getSelectedItemPosition()) - 1]);
                                spnBatsman2.setSelection(0);
                                bat2run = 0;
                                bat2balls = -1;
                                wickets++;
                            }*/
                            batsmanRunOut = true;
                        }
                    })
                    .setNegativeButton(R.string.dialog_string_cancel, null);

            return builder.create();
        }
    }

    @Override
    public void onClick(View v) {
        if (v == btnSwitchBat) {
            if (bat1strike) {
                bat1strike = false;
                spnBatsman1.setBackgroundColor(getResources().getColor(R.color.red));
                spnBatsman2.setBackgroundColor(getResources().getColor(R.color.green));
            } else {
                bat1strike = true;
                spnBatsman1.setBackgroundColor(getResources().getColor(R.color.green));
                spnBatsman2.setBackgroundColor(getResources().getColor(R.color.red));
            }
        } else if (v == btnSave) {
            if (spnExtraType.getSelectedItemPosition() != 0) {
                balls--;
            }
            balls++;
            overs = balls / 6;
            ball = balls % 6;
            if (balls == 12 || wickets == 10) {
                runs = runs + deliveryRun + deliveryExtra;
                if (bat1strike) {
                    bat1run += deliveryRun;
                    if (spnExtraType.getSelectedItemPosition() == 0 || spnExtraType.getSelectedItemPosition() == 1 || spnExtraType.getSelectedItemPosition() == 2)
                        bat1balls++;

                    tvBat1Score.setText(getResources().getString(R.string.batScore, bat1run, bat1balls));
                } else {
                    bat2run += deliveryRun;
                    if (spnExtraType.getSelectedItemPosition() == 0 || spnExtraType.getSelectedItemPosition() == 1 || spnExtraType.getSelectedItemPosition() == 2)
                        bat2balls++;

                    tvBat2Score.setText(getResources().getString(R.string.batScore, bat2run, bat2balls));
                }

                map.put("Name", spnBatsman1.getSelectedItem().toString());
                map.put("Runs", tvBat1Score.getText().toString());

                map.put("Name", spnBatsman2.getSelectedItem().toString());
                map.put("Runs", tvBat2Score.getText().toString());

                data.add(map);

                Intent I = new Intent(BasicScoringActivity.this, ScorecardActivity.class);
                I.putExtra("Batting Team 1 Scorecard", data);
                startActivity(I);
            } else {
                DialogFragment fragment = new ConfirmSaveDialogFragment();
                fragment.show(getSupportFragmentManager(), "savedelivery");
            }
        }
    }

    public class ConfirmSaveDialogFragment extends DialogFragment {
        @NonNull
        @Override
        public Dialog onCreateDialog(Bundle savedInstanceState) {
            final AlertDialog.Builder builder = new AlertDialog.Builder(BasicScoringActivity.this);
            builder.setTitle("Confirm Save?")
                    .setMessage("Save delivery details in database?")
                    .setPositiveButton(R.string.dialog_string_save, new DialogInterface.OnClickListener() {
                                @Override
                                public void onClick(DialogInterface dialog, int which) {
                                    bean.DeliveryLength = "";
                                    bean.DeliveryType = "";
                                    bean.DeliveryPosition = "";
                                    bean.StrikeType = "";
                                    bean.StrikeDirection = "";
                                    bean.StrikeElevation = "";
                                    bean.DelNumber = balls;
                                    bean.Runs = deliveryRun;
                                    bean.ExtraRun = deliveryExtra;
                                    bean.Bowler = Integer.parseInt(BowlingTeamIDs[spnBowler.getSelectedItemPosition() - 1]);
                                    runs = runs + deliveryRun + deliveryExtra;
                                    if (bat1strike) {
                                        bean.OnStrikePlayer = Integer.parseInt(BattingTeamIDs[spnBatsman1.getSelectedItemPosition() - 1]);
                                        bean.OffStrikePlayer = Integer.parseInt(BattingTeamIDs[spnBatsman2.getSelectedItemPosition() - 1]);
                                        bat1run += deliveryRun;
                                        if (spnExtraType.getSelectedItemPosition() == 0 || spnExtraType.getSelectedItemPosition() == 1 || spnExtraType.getSelectedItemPosition() == 2)
                                            bat1balls++;
                                        if (deliveryRun == 1 || deliveryRun == 3 ||
                                                ((spnExtraType.getSelectedItemPosition() == 1 || spnExtraType.getSelectedItemPosition() == 2)
                                                        && (deliveryExtra == 1 || deliveryExtra == 3)) || ((spnExtraType.getSelectedItemPosition() == 3 || spnExtraType.getSelectedItemPosition() == 4)
                                                && (deliveryExtra == 2 || deliveryExtra == 4))) {
                                            bat1strike = false;
                                            spnBatsman1.setBackgroundColor(getResources().getColor(R.color.red));
                                            spnBatsman2.setBackgroundColor(getResources().getColor(R.color.green));
                                        }
                                        tvBat1Score.setText(getResources().getString(R.string.batScore, bat1run, bat1balls));
                                    } else {
                                        bean.OnStrikePlayer = Integer.parseInt(BattingTeamIDs[spnBatsman2.getSelectedItemPosition() - 1]);
                                        bean.OffStrikePlayer = Integer.parseInt(BattingTeamIDs[spnBatsman1.getSelectedItemPosition() - 1]);
                                        bat2run += deliveryRun;
                                        if (spnExtraType.getSelectedItemPosition() == 0 || spnExtraType.getSelectedItemPosition() == 1 || spnExtraType.getSelectedItemPosition() == 2)
                                            bat2balls++;
                                        if (deliveryRun == 1 || deliveryRun == 3 ||
                                                ((spnExtraType.getSelectedItemPosition() == 1 || spnExtraType.getSelectedItemPosition() == 2)
                                                        && (deliveryExtra == 1 || deliveryExtra == 3)) || ((spnExtraType.getSelectedItemPosition() == 3 || spnExtraType.getSelectedItemPosition() == 4)
                                                && (deliveryExtra == 2 || deliveryExtra == 4))) {
                                            bat1strike = true;
                                            spnBatsman1.setBackgroundColor(getResources().getColor(R.color.green));
                                            spnBatsman2.setBackgroundColor(getResources().getColor(R.color.red));
                                        }
                                        tvBat2Score.setText(getResources().getString(R.string.batScore, bat2run, bat2balls));
                                    }
                                    if (batsmanOut) {
                                        if (bat1strike) {
                                            map.put("Name", spnBatsman1.getSelectedItem().toString());
                                            map.put("Runs", tvBat1Score.getText().toString());
                                            data.add(map);
                                            bean.DismissedPlayers = Integer.parseInt(BattingTeamIDs[(spnBatsman1.getSelectedItemPosition()) - 1]);
                                            spnBatsman1.setSelection(0);
                                            bat1run = 0;
                                            bat1balls = 0;
                                            wickets++;
                                            tvBat1Score.setText(getResources().getString(R.string.batScore, bat1run, bat1balls));
                                            batsmanOut = false;
                                        } else {
                                            map.put("Name", spnBatsman2.getSelectedItem().toString());
                                            map.put("Runs", tvBat2Score.getText().toString());
                                            data.add(map);
                                            bean.DismissedPlayers = Integer.parseInt(BattingTeamIDs[(spnBatsman2.getSelectedItemPosition()) - 1]);
                                            spnBatsman2.setSelection(0);
                                            bat2run = 0;
                                            bat2balls = 0;
                                            wickets++;
                                            tvBat2Score.setText(getResources().getString(R.string.batScore, bat2run, bat2balls));
                                            batsmanOut = false;
                                        }
                                    }
                                    if (batsmanRunOut) {
                                        if (selectedIndex == 0) {
                                            map.put("Name", spnBatsman1.getSelectedItem().toString());
                                            map.put("Runs", tvBat1Score.getText().toString());
                                            data.add(map);
                                            bean.DismissedPlayers = Integer.parseInt(BattingTeamIDs[(spnBatsman1.getSelectedItemPosition()) - 1]);
                                            spnBatsman1.setSelection(0);
                                            bat1run = 0;
                                            bat1balls = 0;
                                            wickets++;
                                            tvBat1Score.setText(getResources().getString(R.string.batScore, bat1run, bat1balls));
                                            batsmanRunOut = false;
                                        } else {
                                            map.put("Name", spnBatsman2.getSelectedItem().toString());
                                            map.put("Runs", tvBat2Score.getText().toString());
                                            data.add(map);
                                            bean.DismissedPlayers = Integer.parseInt(BattingTeamIDs[(spnBatsman2.getSelectedItemPosition()) - 1]);
                                            spnBatsman2.setSelection(0);
                                            bat2run = 0;
                                            bat2balls = 0;
                                            wickets++;
                                            tvBat2Score.setText(getResources().getString(R.string.batScore, bat2run, bat2balls));
                                            batsmanRunOut = false;
                                        }
                                    }
                                    deliveryRun = deliveryExtra = 0;
                                    tvScore.setText(getResources().getString(R.string.score, runs, wickets));
                                    tvOvers.setText(getResources().getString(R.string.overs, overs, ball));
                                    spnExtraType.setSelection(0);
                                    spnDismissal.setSelection(0);
                                    resetRuns();

                                }
                            }

                    )
                    .setNegativeButton(R.string.dialog_string_cancel, new DialogInterface.OnClickListener() {
                                @Override
                                public void onClick(DialogInterface dialog, int which) {

                                }
                            }

                    );

            return builder.create();
        }

        @Override
        public void onDismiss(DialogInterface dialog) {
            super.onDismiss(dialog);
            if (ball == 0) {
                if (bat1strike) {
                    bat1strike = false;
                    spnBatsman1.setBackgroundColor(getResources().getColor(R.color.red));
                    spnBatsman2.setBackgroundColor(getResources().getColor(R.color.green));
                } else {
                    bat1strike = true;
                    spnBatsman1.setBackgroundColor(getResources().getColor(R.color.green));
                    spnBatsman2.setBackgroundColor(getResources().getColor(R.color.red));
                }

                Toast toast = Toast.makeText(BasicScoringActivity.this, "Over. Please select new bowler", Toast.LENGTH_SHORT);
                toast.setGravity(Gravity.CENTER, 0, 0);
                toast.show();
            }
            /*DeliverySaveTask saveTask = new DeliverySaveTask();
            saveTask.execute();*/
        }
    }

    private void resetRuns() {
        btn0Run.setChecked(false);
        btn1Run.setChecked(false);
        btn2Run.setChecked(false);
        btn3Run.setChecked(false);
        btn4Run.setChecked(false);
        btn6Run.setChecked(false);
    }

    class DeliverySaveTask extends AsyncTask<String, String, String> {

        ProgressDialog pd;

        @Override
        protected void onPreExecute() {
            super.onPreExecute();
            pd = new ProgressDialog(BasicScoringActivity.this);
            pd.setTitle("Saving");
            pd.setMessage("Please wait while we save your details...");
            pd.setIndeterminate(true);
            pd.setCancelable(false);
            pd.show();
        }

        @Override
        protected String doInBackground(String... params) {
            return bean.sendToServer();
        }

        @Override
        protected void onPostExecute(String s) {
            super.onPostExecute(s);
            if (pd != null)
                pd.dismiss();
            Log.e("DeliverySaveResponse", s);
            Toast.makeText(BasicScoringActivity.this, s, Toast.LENGTH_LONG).show();
        }

    }

}
