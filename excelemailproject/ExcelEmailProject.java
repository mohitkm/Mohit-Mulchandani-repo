package excelemailproject;

import com.google.api.services.gmail.Gmail;
import javafx.application.Application;
import javafx.fxml.FXML;
import javafx.fxml.FXMLLoader;
import javafx.scene.Parent;
import javafx.scene.Scene;
import javafx.scene.control.TextField;
import javafx.stage.Stage;

/**
 * @author mohitmulchandani
 */
public class ExcelEmailProject extends Application {
    
    @Override
    public void start(Stage stage) throws Exception {
        Parent root = FXMLLoader.load(getClass().getResource("ExcelFXMLDocument.fxml"));
        
        Scene scene = new Scene(root);
        
        stage.setTitle("Welcome to Excel Emailer...");
        stage.setScene(scene);
        stage.show();
    }
    
    /**
     * @param args the command line arguments
     */
    public static void main(String[] args) {
        try{
            Gmail service = GmailService.gmailService();
        }catch(Exception e){
            System.out.println("Some error in execution " + e);
        }
        launch(args);
    }
    
}