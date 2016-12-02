package excelemailproject;

import com.google.api.services.gmail.Gmail;

/**
 * @author mohitmulchandani
 */
public class SendingMail implements Runnable {

    private String recipientEmailID;
    private String emailSubject;
    private String emailBody;
    private Gmail service;

    public SendingMail() {
    }

    public SendingMail(String recipientEmailID, String emailSubject, String emailBody, Gmail gmailService) {
        this.recipientEmailID = recipientEmailID;
        this.emailSubject = emailSubject;
        this.emailBody = emailBody;
        this.service = gmailService;
    }
    
    
    @Override
    public void run() {
        System.out.println("Started executing thread for " + recipientEmailID);
        GmailService.sendMail(recipientEmailID, emailSubject, emailBody, service);
        System.out.println("Thread ended for " + recipientEmailID);
    }
}