                      /* Conceptualized and created by Mohit Kishor Mulchandani & Dhrumil Kishor Panchal */

package android.theopentutorials.com.scoringclientapp;

import android.util.Log;

import java.io.BufferedReader;
import java.io.File;
import java.io.FileOutputStream;
import java.io.IOException;
import java.io.InputStream;
import java.io.InputStreamReader;
import java.io.OutputStreamWriter;
import java.net.HttpURLConnection;
import java.net.URL;


public class HttpManager {

	public static String getData(RequestPackage p) {
		int statusCode = 0;
		BufferedReader reader = null;
		String uri = p.getUri();
		if (p.getMethod().equals("GET")) {
			uri += "?" + p.getEncodedParams();
		}
		Log.e("Samay", "Final URL:" + uri);

		try {
			URL url = new URL(uri);
			HttpURLConnection con = (HttpURLConnection) url.openConnection();
			con.setRequestMethod(p.getMethod());

			if (p.getMethod().equals("POST")) {
				con.setDoOutput(true);
				OutputStreamWriter writer = new OutputStreamWriter(con.getOutputStream());
				writer.write(p.getEncodedParams());
				writer.flush();
			}
			 statusCode =  con.getResponseCode();
			StringBuilder sb = new StringBuilder();
			reader = new BufferedReader(new InputStreamReader(con.getInputStream()));
			
			String line;
			while ((line = reader.readLine()) != null) {
				sb.append(line + "\n");
			}
			
			return sb.toString();
			
		} catch (Exception e) {
			if(statusCode == 404){
				return "Requested resource not found";
				
			}else if(statusCode == 500){
				return "Something went wrong at server end";
				
			}else{
				return "Unexpected Error occcured! [Most common Error: Device might not be connected to Internet]"+"" +
						"statusCode"+statusCode+e.toString();
				
			}
			
			
		} finally {
			if (reader != null) {
				try {
					reader.close();
				} catch (IOException e) {
					e.printStackTrace();
					return null;
				}
			}
		}
		
	}


}