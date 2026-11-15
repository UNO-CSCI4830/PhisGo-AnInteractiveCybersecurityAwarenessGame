using UnityEngine;
using TMPro; 

/*
This class stores the text for all emails that the game displays and returns the correct
one to display when an inbox entry is clicked
*/
public class EmailTextMaker : MonoBehaviour
{
    // Text object to display the emails. The value is set in the Inspector window
    public TextMeshProUGUI emailText;
    // Index of desired email from the inbox. The value is set in the Inspector window
    [SerializeField] private int inboxIndex;

    /*
    This 2D array stores all possible email text bodies for the game.  
    first index - number of entries in the inbox
    second index - number of possible email texts to display for that entry (one safe and one scam)
    */
    private string[,] possibleEmailTexts; 

    /*
    The Awake method runs automatically once at the beginning when the game is played. 
    It initializes all locations in the possibleEmailTexts field. 
    It stores each email text possibility as a single string.
    */
    private void Awake() 
    {
        possibleEmailTexts = new string[GameData.NUM_EMAILS, 2];

        /* FIRST INBOX ENTRY **********************************************/
        // index 0 is the scam email  
        possibleEmailTexts[0, 0] = 
            "sender: BuyAndSelBokks@gmail.com\n" +
            "subject: Order Confirmation Needed\n\n" +
            "Thank you for choosing Buy And Sell Books. You still need to confirm your order.\n" +
            "You must click here in the next 24 hours to confirm your order.";
        // index 1 is the safe email 
        possibleEmailTexts[0, 1] =
            "sender: BuyAndSellBooks@bsb.org\n" +
            "subject: Order Confirmation\n\n" +
            "Your order for 1 item: Cyber Security Concepts by Philip Reggins has been placed.\n" +
            "Thank you for choosing Buy And Sell Books.";

        /* SECOND INBOX ENTRY **********************************************/
        // index 0 is the scam email  
        possibleEmailTexts[1, 0] = 
            "sender: Linkedin@phishmail.com\n" +
            "subject: I Want to Connect\n\n" +
            "Someone you know want to connect with you. Click HERE to see who."; 
        // index 1 is the safe email 
        possibleEmailTexts[1, 1] =
            "sender: invitations@linkedin.com\n" +
            "subject: Maria Lopez wants to connect with you\n\n" +
            "Maria Lopez, Software Engineer at Brightside Labs, sent you an invitation to connect.\n" +
            "You can accept or ignore this invitation from your LinkedIn account.";

        /* THIRD INBOX ENTRY **********************************************/
        // index 0 is the scam email  
        possibleEmailTexts[2, 0] =
            "sender: security@firstnatl-bank-alerts.net\n" +
            "subject: URGENT!!! Your account is SUSPENDED\n\n" +
            "Dear Customer,\n" +
            "We noticed suspicious activity. Your account will be closed in 2 hours.\n" +
            "Reply to this email with your password and PIN to verify your identity."; 
        // index 1 is the safe email 
        possibleEmailTexts[2, 1] =
            "sender: statements@firstnationalbank.com\n" +
            "subject: Your October statement is ready\n\n" +
            "Dear Customer,\n" +
            "Your monthly statement for the account ending in 4821 is now available.\n" +
            "To view it, log in through our official website or mobile app.\n" +
            "We will never ask for your password or PIN by email.";

        /* FOURTH INBOX ENTRY **********************************************/
        // index 0 is the scam email  
        possibleEmailTexts[3, 0] =
            "sender: shipfast-delivery@gmail.com\n" +
            "subject: Package could not be delivered - pay fee now\n\n" +
            "Your package is on hold. Pay a $1.99 redelivery fee or it will be returned.\n" +
            "Click here and enter your credit card number to reschedule."; 
        // index 1 is the safe email 
        possibleEmailTexts[3, 1] =
            "sender: tracking@shipfast.com\n" +
            "subject: Your package has shipped\n\n" +
            "Dear Customer,\n" +
            "Your order from Buy And Sell Books is on its way.\n" +
            "Tracking number: SF-20481937. Expected delivery: Friday.\n" +
            "No action is needed. Thank you for choosing ShipFast.";

        /* FIFTH INBOX ENTRY **********************************************/
        // index 0 is the scam email  
        possibleEmailTexts[4, 0] =
            "sender: WINNER@free-prizes-now.xyz\n" +
            "subject: CONGRATULATIONS!!! You Have Won $1,000,000\n\n" +
            "You are the luky winner of our grate prize draw!\n" +
            "To claim your money, send your full name, home adress, and Social Security number.\n" +
            "Act now. This offer expires today!"; 
        // index 1 is the safe email 
        possibleEmailTexts[4, 1] =
            "sender: notices@citylibrary.org\n" +
            "subject: Library book due soon\n\n" +
            "Hello,\n" +
            "This is a reminder that Cyber Security Concepts is due back on November 22.\n" +
            "You can renew it online or at the front desk.\n" +
            "Thank you for being a City Library member.";
    }

    /*
    This method will run when the inbox entry is clicked. It assigns one of the possible 
    email texts for the given inbox location (stored in inboxIndex) to the emailText object. 
    The choice of assigning a safe or scam email is based on the corresponding entry in the 
    emailStatus array from the GameData class.
    */
    public void OnButtonClick()
    {
        // assures emailText object was assigned in inspector and inboxIndex from
        // inspector is not out of bounds
        if (emailText != null && inboxIndex >= 0 && inboxIndex < GameData.NUM_EMAILS) 
        {
            int choiceForEntry = GameData.getEmailStatus(inboxIndex); // 0 or 1 from GameData
            emailText.text = possibleEmailTexts[inboxIndex, choiceForEntry];
        }

        // Tell the GameData class which email is current
        GameData.updateCurrentEmailIndex(inboxIndex);
    }
}
