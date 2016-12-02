package excelemailproject;

import com.google.api.client.auth.oauth2.Credential;
import com.google.api.client.extensions.java6.auth.oauth2.AuthorizationCodeInstalledApp;
import com.google.api.client.extensions.jetty.auth.oauth2.LocalServerReceiver;
import com.google.api.client.googleapis.auth.oauth2.GoogleAuthorizationCodeFlow;
import com.google.api.client.googleapis.auth.oauth2.GoogleClientSecrets;
import com.google.api.client.googleapis.javanet.GoogleNetHttpTransport;
import com.google.api.client.http.HttpTransport;
import com.google.api.client.json.JsonFactory;
import com.google.api.client.json.jackson2.JacksonFactory;
import com.google.api.client.util.Base64;
import com.google.api.client.util.store.FileDataStoreFactory;
import com.google.api.services.gmail.Gmail;
import com.google.api.services.gmail.GmailScopes;
import com.google.api.services.gmail.model.Message;
import java.io.ByteArrayOutputStream;
import java.io.File;
import java.io.FileInputStream;
import java.io.IOException;
import java.io.InputStream;
import java.io.InputStreamReader;
import java.util.ArrayList;
import java.util.Properties;
import javax.activation.DataHandler;
import javax.activation.DataSource;
import javax.activation.FileDataSource;
import javax.mail.MessagingException;
import javax.mail.Multipart;
import javax.mail.Session;
import javax.mail.internet.InternetAddress;
import javax.mail.internet.MimeBodyPart;
import javax.mail.internet.MimeMessage;
import javax.mail.internet.MimeMultipart;

/**
 * @author mohitmulchandani
 */
public class GmailService{
    private static final JsonFactory JSON_FACTORY = JacksonFactory.getDefaultInstance();
    private static HttpTransport httpTransport;
    private static FileDataStoreFactory dataStoreFactory;
    private static final File GMAIL_DATA_FILE = new File(System.getProperty("user.home"), ".credentials/StoredCredentials");
    
    static{
        try{
            httpTransport = GoogleNetHttpTransport.newTrustedTransport();
            dataStoreFactory = new FileDataStoreFactory(GMAIL_DATA_FILE);
        } catch(Exception e){
            System.out.println("Some error " + e);
        }
    }
    
    public static ArrayList<String> GMAIL_SCOPES;
        
    public static Credential authorize() throws IOException{
        InputStream in = new FileInputStream("./client_secret.json");
        GoogleClientSecrets clientSecrets = GoogleClientSecrets.load(JSON_FACTORY, new InputStreamReader(in));
        GMAIL_SCOPES = new ArrayList<>();
        GMAIL_SCOPES.add(GmailScopes.GMAIL_COMPOSE);
        GMAIL_SCOPES.add(GmailScopes.GMAIL_INSERT);
        GMAIL_SCOPES.add(GmailScopes.GMAIL_SEND);
        GMAIL_SCOPES.add(GmailScopes.MAIL_GOOGLE_COM);
        GMAIL_SCOPES.add(GmailScopes.GMAIL_SETTINGS_BASIC);
        GMAIL_SCOPES.add(GmailScopes.GMAIL_MODIFY);
        GMAIL_SCOPES.add(GmailScopes.GMAIL_SETTINGS_SHARING);

        GoogleAuthorizationCodeFlow flow = new GoogleAuthorizationCodeFlow.Builder(httpTransport, JSON_FACTORY, clientSecrets, GMAIL_SCOPES)
                .setAccessType("offline")
                .setDataStoreFactory(dataStoreFactory)
                .build();
        
        Credential credential = new AuthorizationCodeInstalledApp(flow, new LocalServerReceiver()).authorize("user");
        return credential;
    }
    
    public static Gmail gmailService() throws IOException{
        Credential credential = authorize();
        return new Gmail.Builder(httpTransport, JSON_FACTORY, credential)
                .setApplicationName("Gmail test app")
                .build();
    }
    
    public static MimeMessage createMessage(String toAddress,
            String messageContent, String messageSubject, File attachment)
            throws MessagingException, IOException{
        
        Properties properties = new Properties();
        Session session = Session.getDefaultInstance(properties, null);
        
        MimeMessage message = new MimeMessage(session);
        message.addRecipient(javax.mail.Message.RecipientType.TO, new InternetAddress(toAddress));
        message.setSubject(messageSubject);
        
        MimeBodyPart messageBody = new MimeBodyPart();
        messageBody.setContent(messageContent, "text/plain");
        
        Multipart multipart = new MimeMultipart();
        multipart.addBodyPart(messageBody);
        
        messageBody = new MimeBodyPart();
        DataSource dataSource = new FileDataSource(attachment);
        
        messageBody.setDataHandler(new DataHandler(dataSource));
        message.setFileName(attachment.getName());
        
        multipart.addBodyPart(messageBody);
        message.setContent(multipart);
        
        return message;
        
    }
    
    public static MimeMessage createMessage(String toAddress,
            String messageContent, String messageSubject)
            throws MessagingException, IOException{
        
        Properties properties = new Properties();
        Session session = Session.getDefaultInstance(properties, null);
        
        MimeMessage message = new MimeMessage(session);
        message.addRecipient(javax.mail.Message.RecipientType.TO, new InternetAddress(toAddress));
        message.setSubject(messageSubject);
        
        MimeBodyPart messageBody = new MimeBodyPart();
        messageBody.setContent(messageContent, "text/plain");
        
        Multipart multipart = new MimeMultipart();
        multipart.addBodyPart(messageBody);
        
        message.setContent(multipart);
        
        return message;
        
    }
    
    public static Message createEmailMessage(MimeMessage message)
            throws MessagingException, IOException{
        
        ByteArrayOutputStream outputStream = new ByteArrayOutputStream();
        message.writeTo(outputStream);
        byte[] bytes = outputStream.toByteArray();
        String encodedEmail = Base64.encodeBase64URLSafeString(bytes);
        
        Message emailMessage = new Message();
        emailMessage.setRaw(encodedEmail);
        
        return emailMessage;
        
    }
    public static void sendMail(String recipientAddress, String emailSubject, String emailBody, Gmail service) {
        try{
            MimeMessage emailContent = createMessage(recipientAddress, emailBody, emailSubject);
            Message email = createEmailMessage(emailContent);
            service.users().messages().send("me", email).execute();
            
        }catch(Exception e){
            System.err.println("Some error in main " + e);
        }
    }
    
    public static void sendMailWithAttachment(String recipientAddress, String emailSubject, String emailBody, File attachmentFile, Gmail service) {
        try{
            MimeMessage emailContent = createMessage(recipientAddress, emailBody, emailSubject, attachmentFile);
            Message email = createEmailMessage(emailContent);
            service.users().messages().send("me", email).execute();
            
        }catch(Exception e){
            System.err.println("Some error in main " + e);
        }
    }
}