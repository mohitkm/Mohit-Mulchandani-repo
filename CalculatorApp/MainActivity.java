package com.example.mohit.calculatordemo;

import android.support.v7.app.AppCompatActivity;
import android.os.Bundle;
import android.view.View;
import android.widget.*;

public class MainActivity extends AppCompatActivity implements View.OnClickListener {

    Button btn1,btn2, btn3, btn4, btn5, btn6, btn7, btn8, btn9, btn0, btnDiv, btnMul, btnPlus, btnMinus, btnDot, btnEqual,btnC;
    EditText etNumber;
    int counter=0;
    int op=0;


    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);

        findAllViews();
        btn0.setOnClickListener(this);
        btn1.setOnClickListener(this);
        btn2.setOnClickListener(this);
        btn3.setOnClickListener(this);
        btn4.setOnClickListener(this);
        btn5.setOnClickListener(this);
        btn6.setOnClickListener(this);
        btn7.setOnClickListener(this);
        btn8.setOnClickListener(this);
        btn9.setOnClickListener(this);
        btnDiv.setOnClickListener(this);
        btnDot.setOnClickListener(this);
        btnMinus.setOnClickListener(this);
        btnMul.setOnClickListener(this);
        btnPlus.setOnClickListener(this);
        btnEqual.setOnClickListener(this);
        btnC.setOnClickListener(this);
    }

    public void findAllViews(){

        btn0 = (Button)findViewById(R.id.btn0);
        btn1 = (Button)findViewById(R.id.btn1);
        btn2 = (Button)findViewById(R.id.btn2);
        btn3 = (Button)findViewById(R.id.btn3);
        btn4 = (Button)findViewById(R.id.btn4);
        btn5 = (Button)findViewById(R.id.btn5);
        btn6 = (Button)findViewById(R.id.btn6);
        btn7 = (Button)findViewById(R.id.btn7);
        btn8 = (Button)findViewById(R.id.btn8);
        btn9 = (Button)findViewById(R.id.btn9);
        btnDiv = (Button)findViewById(R.id.btnDiv);
        btnMinus = (Button)findViewById(R.id.btnMinus);
        btnMul = (Button)findViewById(R.id.btnMul);
        btnPlus = (Button)findViewById(R.id.btnPlus);
        btnDot = (Button)findViewById(R.id.btnDot);
        btnEqual = (Button)findViewById(R.id.btnEqual);
        btnC = (Button)findViewById(R.id.btnC);
        etNumber = (EditText)findViewById(R.id.etNumber);
    }

    @Override
    public void onClick(View v) {
        int b=0;
        int a=0;
        int result=100;
        if(v==btn0)etNumber.append("0");
        if(v==btn1)etNumber.append("1");
        if(v==btn2)etNumber.append("2");
        if(v==btn3)etNumber.append("3");
        if(v==btn4)etNumber.append("4");
        if(v==btn5)etNumber.append("5");
        if(v==btn6)etNumber.append("6");
        if(v==btn7)etNumber.append("7");
        if(v==btn8)etNumber.append("8");
        if(v==btn9)etNumber.append("9");
        if(v==btnDot)etNumber.append(".");
        if(v==btnC){
            if(etNumber.getText().length()==0)
                etNumber.setText("");
            else
                etNumber.setText(etNumber.getText().subSequence(0,(etNumber.length())-1));
        }
        if(v==btnPlus){
            counter++;
            a= Integer.parseInt(etNumber.getText().toString());
            op=3;
            etNumber.setText("");
        }
        if(v==btnDiv){
            a= Integer.parseInt(etNumber.getText().toString());
            op=1;
            etNumber.setText("");
        }
        if(v==btnMinus){
            a= Integer.parseInt(etNumber.getText().toString());
            op=4;
            etNumber.setText("");
        }
        if(v==btnMul){
            a= Integer.parseInt(etNumber.getText().toString());
            op=2;
            etNumber.setText("");
        }

        if(v==btnEqual){
            b = Integer.parseInt(etNumber.getText().toString());
            switch (op){
                case 1:
                    a=a/b;
                    etNumber.setText(Integer.toString(a));
                    break;
                case 2:
                    a=a*b;
                    etNumber.setText(Integer.toString(a));
                    break;
                case 3:
                    a=a+b;
                    etNumber.setText(Integer.toString(a));
                    break;
                case 4:
                    a=a-b;
                    etNumber.setText(Integer.toString(a));
                    break;
                default:
                    etNumber.setText("0");
                    break;
            }
        }
    }
}
