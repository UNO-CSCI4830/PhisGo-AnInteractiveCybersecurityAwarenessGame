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
    private int numEmails = 5; // total number of emails in the inbox

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
        possibleEmailTexts = new string[numEmails, 2];

        /* FIRST INBOX ENTRY **********************************************/
        // index 0 is the scam email  
        possibleEmailTexts[0, 0] = "scam email 0 main text"; 
        // index 1 is the safe email 
        possibleEmailTexts[0, 1] = "safe email 0 main text";

        /* SECOND INBOX ENTRY **********************************************/
        // index 0 is the scam email  
        possibleEmailTexts[1, 0] = "scam email 1 main text"; 
        // index 1 is the safe email 
        possibleEmailTexts[1, 1] = "safe email 1 main text";

        /* THIRD INBOX ENTRY **********************************************/
        // index 0 is the scam email  
        possibleEmailTexts[2, 0] = "scam email 2 main text"; 
        // index 1 is the safe email 
        possibleEmailTexts[2, 1] = "safe email 2 main text";

        /* FOURTH INBOX ENTRY **********************************************/
        // index 0 is the scam email  
        possibleEmailTexts[3, 0] = "scam email 3 main text"; 
        // index 1 is the safe email 
        possibleEmailTexts[3, 1] = "safe email 3 main text";

        /* FIFTH INBOX ENTRY **********************************************/
        // index 0 is the scam email  
        possibleEmailTexts[4, 0] = "scam email 4 main text"; 
        // index 1 is the safe email 
        possibleEmailTexts[4, 1] = "safe email 4 main text";
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
        if (emailText != null && inboxIndex >= 0 && inboxIndex < numEmails) 
        {
            int choiceForEntry = GameData.emailStatus[inboxIndex]; // 0 or 1 from GameData
            emailText.text = possibleEmailTexts[inboxIndex, choiceForEntry];
        }
    }
}
