package com.example.mohit.filemanager;

import android.content.Intent;
import android.net.Uri;
import android.os.Environment;
import android.provider.MediaStore;
import android.support.v7.app.AppCompatActivity;
import android.os.Bundle;
import android.view.ContextMenu;
import android.view.Menu;
import android.view.MenuInflater;
import android.view.MenuItem;
import android.view.View;
import android.widget.AdapterView;
import android.widget.ListView;
import android.widget.SimpleAdapter;
import android.widget.Toast;

import java.io.BufferedInputStream;
import java.io.ByteArrayOutputStream;
import java.io.DataInputStream;
import java.io.DataOutput;
import java.io.DataOutputStream;
import java.io.File;
import java.io.FileInputStream;
import java.io.FileOutputStream;
import java.io.FileReader;
import java.io.FileWriter;
import java.io.IOException;
import java.nio.ByteBuffer;
import java.util.ArrayList;
import java.util.HashMap;
import java.util.List;

public class MainActivity extends AppCompatActivity implements AdapterView.OnItemClickListener {

    ListView lv;
    SimpleAdapter sa;
    static  String copiedFileName;
    static  String copiedFilePath;
    String[] from = {"name","type"};
    int[] to = {android.R.id.text1,android.R.id.text2};
    ArrayList<HashMap<String,String>> data =  new ArrayList<HashMap<String, String>>();
    File[] arr;
    File rootfile,environmentRootFile;
    int contextMenuCurrentPos;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);
        lv = (ListView) findViewById(R.id.listView);
        environmentRootFile = Environment.getExternalStorageDirectory();

        Intent oldIntent = getIntent();
        if (oldIntent.hasExtra("path")) {
            rootfile = new File(oldIntent.getStringExtra("path"));
            if(oldIntent.hasExtra("copiedFileName")) {
                copiedFileName = oldIntent.getStringExtra("copiedFileName");
                copiedFilePath = oldIntent.getStringExtra("copiedFilePath");
            }
        }

        else {
            rootfile = Environment.getExternalStorageDirectory();
        }

        arr = rootfile.listFiles();
        for (File f : arr) {
            HashMap<String, String> map = new HashMap<String, String>();
            map.put("name", f.getName());
            map.put("type", f.isFile() ? "File" : "Folder");
            data.add(map);
        }

        sa = new SimpleAdapter(this, data, android.R.layout.simple_list_item_2, from, to);
        lv.setAdapter(sa);
        lv.setOnItemClickListener(this);
        registerForContextMenu(lv);
    }

    @Override
    public void onCreateContextMenu(ContextMenu menu, View v, ContextMenu.ContextMenuInfo menuInfo) {
        AdapterView.AdapterContextMenuInfo info = (AdapterView.AdapterContextMenuInfo)menuInfo;
        contextMenuCurrentPos = info.position;
        menu.add("Delete");
        menu.add("Details");
        menu.add("Copy");
        menu.add("Rename");
        super.onCreateContextMenu(menu, v, menuInfo);
    }

    @Override
    public boolean onContextItemSelected(MenuItem item) {
        if(item.getTitle()=="Delete") {
            File f = arr[contextMenuCurrentPos];
            f.delete();
            Toast.makeText(this, (f.getName()+" deleted"), Toast.LENGTH_LONG).show();
            Intent I = new Intent(this,MainActivity.class);
            I.putExtra("path",rootfile.getAbsolutePath());
            startActivity(I);
            finish();
        }
        else if(item.getTitle()=="Details"){
            Toast.makeText(this, item.getTitle(), Toast.LENGTH_LONG).show();

        }
        else if(item.getTitle()=="Copy"){
            File f = arr[contextMenuCurrentPos];
            Intent I = new Intent(this,MainActivity.class);
            I.putExtra("path",environmentRootFile.getAbsolutePath());
            I.putExtra("copiedFileName",f.getName());
            I.putExtra("copiedFilePath",f.getAbsolutePath());
            Toast.makeText(this,f.getName(),Toast.LENGTH_LONG).show();
            startActivity(I);
            finish();

        }
        else if(item.getTitle()=="Rename"){
            Toast.makeText(this, item.getTitle(), Toast.LENGTH_LONG).show();

        }
        return super.onContextItemSelected(item);
    }

    @Override
    public boolean onCreateOptionsMenu(Menu menu) {
        MenuInflater inflater = getMenuInflater();
        inflater.inflate(R.menu.main_menu,menu);
        return super.onCreateOptionsMenu(menu);
    }

    @Override
    public boolean onOptionsItemSelected(MenuItem item) {
        if(item.getItemId()==R.id.menu_NewFolder){
            String path = rootfile.getAbsolutePath();
            String newPath = path + "/" + "New Folder";
            File newFile = new File(newPath);
            int i = 1;
            while(newFile.exists()){
                newFile = new File(path + "/" + "New Folder" + (i++));
            }
            newFile.mkdir();
            Intent I = new Intent(this,MainActivity.class);
            I.putExtra("path",rootfile.getAbsolutePath());
            startActivity(I);
            finish();
        }
        else if(item.getItemId()==R.id.menu_Paste){
            String path = rootfile.getAbsolutePath();
            String newPath = path + "/" + MainActivity.copiedFileName;
            File copy = new File(newPath);
            File original = new File(MainActivity.copiedFilePath);
            int i;
            ByteArrayOutputStream baos = new ByteArrayOutputStream();
            try {
                BufferedInputStream bufferedInputStream = new BufferedInputStream(new FileInputStream(original));
                FileOutputStream outputStream = new FileOutputStream(copy);
                while((i=bufferedInputStream.read())!=-1){
                    baos.write((byte)i);
                }
                outputStream.write(baos.toByteArray());
                outputStream.close();
                bufferedInputStream.close();
                copy.createNewFile();
            } catch (IOException e) {
                Toast.makeText(this,"Cannot create file",Toast.LENGTH_LONG).show();
            }
            Intent I = new Intent(this,MainActivity.class);
            I.putExtra("path", rootfile.getAbsolutePath());
            startActivity(I);
            finish();
        }
        else if(item.getItemId()==R.id.menu_SortAscending){

        }

        else if(item.getItemId()==R.id.menu_SortDescending){

        }
        return super.onOptionsItemSelected(item);
    }

    @Override
    public void onItemClick(AdapterView<?> parent, View view, int position, long id) {
        File f = arr[position];
        if(f.isDirectory()){
            Intent I = new Intent(this,MainActivity.class);
            I.putExtra("path",f.getAbsolutePath());
            startActivity(I);
        }
        else{
            Intent I = new Intent();
            I.setAction(Intent.ACTION_VIEW);
            I.setDataAndType(Uri.fromFile(f), "image/*");
            startActivity(I);
        }

    }
}
