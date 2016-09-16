                      /* Conceptualized and created by Mohit Kishor Mulchandani & Dhrumil Kishor Panchal */

package com.example.mohit.scoringapp;

/**
 * Created by Mohit on 04-Apr-16.
 */
public class Delivery {

    int FixtureID;
    int DelNumber;
    int Bowler;
    String BowlerName;
    int OnStrikePlayer;
    String BatsmanName;
    int OffStrikePlayer;
    String OffBatsmanName;
    String DeliveryType;
    String DeliveryLength;
    String DeliveryPosition;
    String StrikeType;
    String StrikeDirection;
    String StrikeElevation;
    int Runs;
    int ExtraRun;
    int ExtraType;
    int DismissalType;
    int DismissedPlayers;
    String DismissedPlayerName;


    public String sendToServer(){
        RequestPackage rp = new RequestPackage();
        rp.setMethod("POST");
        rp.setUri(LoginActivity.url);
        rp.setParam("type", "delivery");
        rp.setParam("FixtureID",String.valueOf(FixtureID));
        rp.setParam("DeliveryNumber",String.valueOf(DelNumber));
        rp.setParam("Bowler", String.valueOf(Bowler));
        rp.setParam("BowlerName", BowlerName);
        rp.setParam("OnStrikePlayer",String.valueOf(OnStrikePlayer));
        rp.setParam("BatsmanName",BatsmanName);
        rp.setParam("OffStrikePlayer",String.valueOf(OffStrikePlayer));
        rp.setParam("OffBatsmanName",OffBatsmanName);
        rp.setParam("DeliveryType",String.valueOf(DeliveryType));
        rp.setParam("DeliveryLength",String.valueOf(DeliveryLength));
        rp.setParam("DeliveryPosition",String.valueOf(DeliveryPosition));
        rp.setParam("StrikeType",String.valueOf(StrikeType));
        rp.setParam("StrikeDirection",String.valueOf(StrikeDirection));
        rp.setParam("StrikeElevation",String.valueOf(StrikeElevation));
        rp.setParam("Runs",String.valueOf(Runs));
        rp.setParam("ExtraRun",String.valueOf(ExtraRun));
        rp.setParam("ExtraType",String.valueOf(ExtraType));
        rp.setParam("DismissalType",String.valueOf(DismissalType));
        rp.setParam("DismissedPlayers", String.valueOf(DismissedPlayers));
        rp.setParam("DismissedPlayerName", DismissedPlayerName);

        String Response = HttpManager.getData(rp).trim();
        //return Response.split("<!--")[0];
        return Response;

    }

}
