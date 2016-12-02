package excelemailproject;

import com.google.api.services.gmail.Gmail;
import java.io.File;

/**
 * @author mohitmulchandani
 */
public class SendingMailWithAttachment implements Runnable{
    
    private String recipientEmailID;
    private String emailSubject;
    private String emailBody;
    private File f;
    private Gmail service;

    public SendingMailWithAttachment() {
    }

    public SendingMailWithAttachment(String recipientEmailID, String emailSubject, String emailBody, File f, Gmail gmailService) {
        this.recipientEmailID = recipientEmailID;
        this.emailSubject = emailSubject;
        this.emailBody = emailBody;
        this.f = f;
        this.service = gmailService;
    }
    
    
    @Override
    public void run() {
        System.out.println("Started executing thread for " + recipientEmailID);
        GmailService.sendMailWithAttachment(recipientEmailID, emailSubject, emailBody, f, service);
        System.out.println("Thread ended for " + recipientEmailID);
    }
}