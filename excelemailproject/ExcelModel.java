package excelemailproject;

import java.io.File;
import java.util.ArrayList;
import org.apache.poi.xssf.usermodel.XSSFCell;
import org.apache.poi.xssf.usermodel.XSSFRow;
import org.apache.poi.xssf.usermodel.XSSFSheet;
import org.apache.poi.xssf.usermodel.XSSFWorkbook;

/**
 * @author mohitmulchandani
 */
public class ExcelModel {
    public static ArrayList<String> getEmailIDs(String excelFilePath, int columnNumber, int rowNumber){
        try{
            ArrayList<String> arr = new ArrayList<>();
            File xlfile = new File(excelFilePath);
            XSSFWorkbook xlworkbook = new XSSFWorkbook(xlfile);
            XSSFSheet xlsheet = xlworkbook.getSheetAt(0);
            XSSFRow row = xlsheet.getRow(rowNumber-1);
            XSSFCell  cell = row.getCell(columnNumber);
            
            arr.add(cell.getStringCellValue());
            
            return arr;
        } catch(Exception e){
            System.out.println("Some error in getEmailIDs (single row) " + e);
        }
        return null;
    }
    
    public static ArrayList<String> getEmailIDs(String excelFilePath, int columnNumber, int startRowNumber, int endRowNumber){
        try{
            File xlfile = new File(excelFilePath);
            XSSFWorkbook xlworkbook = new XSSFWorkbook(xlfile);
            XSSFSheet xlsheet = xlworkbook.getSheetAt(0);
            ArrayList<String> arr = new ArrayList<>();
            
            for (int i = startRowNumber-1; i<=endRowNumber-1; i++){
                XSSFRow row = xlsheet.getRow(i);
                XSSFCell  cell = row.getCell(columnNumber);
                arr.add(cell.getStringCellValue());
            }
            return arr;
        } catch(Exception e){
            System.out.println("Some error in getEmailIDs (range of rows) " + e);
        }
        return null;
    }
    
    public static ArrayList<String> getEmailIDs(String excelFilePath, int columnNumber, String[] rowNumbers){
        try{
            File xlfile = new File(excelFilePath);
            XSSFWorkbook xlworkbook = new XSSFWorkbook(xlfile);
            XSSFSheet xlsheet = xlworkbook.getSheetAt(0);
            ArrayList<String> arr = new ArrayList<>();
            
            for (int i = 0; i<=rowNumbers.length; i++){
                XSSFRow row = xlsheet.getRow(Integer.parseInt(rowNumbers[i])-1);
                XSSFCell  cell = row.getCell(columnNumber);
                arr.add(cell.getStringCellValue());
            }
            return arr;
        } catch(Exception e){
            System.out.println("Some error in getEmailIDs (array of rows) " + e);
        }
        return null;
    }
}