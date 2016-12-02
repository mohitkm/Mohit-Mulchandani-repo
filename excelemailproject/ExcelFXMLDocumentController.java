package excelemailproject;

import com.google.api.services.gmail.Gmail;
import java.io.File;
import java.net.URL;
import java.util.ArrayList;
import java.util.ResourceBundle;
import javafx.event.ActionEvent;
import javafx.fxml.FXML;
import javafx.fxml.FXMLLoader;
import javafx.fxml.Initializable;
import javafx.scene.Parent;
import javafx.scene.Scene;
import javafx.scene.control.Button;
import javafx.scene.control.Label;
import javafx.scene.control.TextArea;
import javafx.scene.control.TextField;
import javafx.scene.input.MouseEvent;
import javafx.scene.text.Text;
import javafx.stage.FileChooser;
import javafx.stage.Stage;

/**
 * @author mohitmulchandani
 */
public class ExcelFXMLDocumentController implements Initializable {
    
    @FXML
    private TextField columnNumber;
    
    @FXML
    private TextField rowNumber;
    
    @FXML
    private TextArea emailBody;
    
    @FXML
    private TextField emailSubject;
    
    @FXML
    private Label errorLabel;
    
    @FXML
    private Label excelFileName;
    
    @FXML
    private Label attachmentFileName;
    
    private String excelFilePath = "";
    private String attachmentPath = "";
    
    @FXML
    protected void validateColumn(MouseEvent me){
        if (this.columnNumber.getText() == null || this.columnNumber.getText() == ""){
            errorLabel.setText("The column field is blank");
        }
        else{
            try{
                int columnNumber = Integer.parseInt(this.columnNumber.getText());
            }catch(NumberFormatException ne){
                errorLabel.setText("Error in the column field");
            }
        }
    }
    
    @FXML
    protected void onClick(MouseEvent me){
        errorLabel.setText("");
    }
    
    @FXML
    protected void validateRow(MouseEvent me){
        if (this.columnNumber.getText() == null || this.columnNumber.getText() == ""){
            errorLabel.setText("The column field is blank");
        }
        else{
            for(int i=0; i<rowNumber.getText().length(); i++){
                if(!Character.isDigit(rowNumber.getText().charAt(i)) && rowNumber.getText().charAt(i) != '-' && rowNumber.getText().charAt(i) != ','){
                    errorLabel.setText("Some problem in the row field");
                }

            }
        }
    }
    
    
    @FXML
    protected void handleSelectSourceFile(ActionEvent event) {
        FileChooser fileChooser = new FileChooser();
        fileChooser.setTitle("Select excel file");
        fileChooser.getExtensionFilters().add(new FileChooser.ExtensionFilter("XLS", "*.xlsx"));
        excelFilePath = fileChooser.showOpenDialog(columnNumber.getScene().getWindow()).getAbsolutePath();
        excelFileName.setText(excelFilePath);
        
    }
    
    @FXML
    protected void handleSelectAttachments(ActionEvent event) {
        FileChooser fileChooser = new FileChooser();
        fileChooser.setTitle("Select attachments");
        attachmentPath = fileChooser.showOpenDialog(columnNumber.getScene().getWindow()).getAbsolutePath();
        attachmentFileName.setText(attachmentPath);
    }
    
    @FXML
    protected void handleSendEmails(ActionEvent event) {
        Gmail service = null;
        try{
            service = GmailService.gmailService();
        }catch(Exception e){
            System.out.println("Some error in handleSendEmails gmailservice " + e);
        }
        String emailBody = this.emailBody.getText();
        String emailSubject = this.emailSubject.getText();
        ArrayList<String> recipientEmailIDs = new ArrayList<>();
        int columnNumber = Integer.parseInt(this.columnNumber.getText());
        String rows = rowNumber.getText();
        
        if (rows.indexOf("-") != -1){
            int startRowNumber = Integer.parseInt(rows.split("-")[0]);
            int endRowNumber = Integer.parseInt(rows.split("-")[1]);

            recipientEmailIDs.addAll(ExcelModel.getEmailIDs(excelFilePath, columnNumber-1 , startRowNumber, endRowNumber));
        }
        else if (rows.indexOf(",") != -1){
            String[] temp = rows.split(",");
            recipientEmailIDs.addAll(ExcelModel.getEmailIDs(excelFilePath, columnNumber-1, temp));
        }
        else {
            recipientEmailIDs.addAll(ExcelModel.getEmailIDs(excelFilePath, columnNumber-1, Integer.parseInt(rows)));
        }

        if (attachmentPath == ""){
            for (String recipientEmailID : recipientEmailIDs) {
                try{
                    SendingMail mail = new SendingMail(recipientEmailID, emailSubject, emailBody, service);
                    Thread t = new Thread(mail);
                    t.start();
                    t.join();
                }catch(Exception e){
                    System.out.println("Some exception in thread" + e);
                }
                
            }
        }else{
            File f = new File(attachmentPath);
            for (String recipientEmailID : recipientEmailIDs) {
                try{
                    SendingMailWithAttachment mailWithAttachment = new SendingMailWithAttachment(recipientEmailID, emailSubject, emailBody, f, service);
                    Thread t = new Thread(mailWithAttachment);
                    t.start();
                    t.join();
                }catch(Exception e){
                    System.out.println("Some exception in thread" + e);
                }
                
            }
        }
        try{
            Button b = (Button)event.getSource();
            Stage s = (Stage)b.getScene().getWindow();
            Parent nextScene = FXMLLoader.load(getClass().getResource("EmailSentFXMLDocument.fxml"));
            
            s.setScene(new Scene(nextScene));
            File f = new File(System.getProperty("user.home"), ".credentials/StoredCredentials/StoredCredential");
            f.delete();
            f = new File(System.getProperty("user.home"), ".credentials/StoredCredentials");
            f.delete();
            f = new File(System.getProperty("user.home"), ".credentials");
            f.delete();
            s.show();
        }catch(Exception e){
            
        }
    }

    @Override
    public void initialize(URL url, ResourceBundle rb) {
        // TODO
    }    
    
}