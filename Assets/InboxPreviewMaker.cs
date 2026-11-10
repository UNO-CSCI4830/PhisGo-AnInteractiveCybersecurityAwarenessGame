using UnityEngine;
using TMPro;

/*
This class stores the text for all the inbox previews that the game displays and returns 
the correct one to display when an inbox entry is generated
*/
public class InboxPreviewMaker : MonoBehaviour
{
    // Text object to display the inbox email. The value is set in the Inspector window
    [SerializeField] private TMP_Text myInboxText;
    // Index of email preview in the inbox. The value is set in the Inspector window
    [SerializeField] private int previewNumber;
    private int numEmails = 5; // total number of emails in the inbox

    /*
    This 2D array stores all possible inbox previews for the game 
    first index - number of entries in the inbox
    second index - number of possible email previews to display for that entry
    */
    private string[,] possibleInboxTexts;

    /*
    The Awake method runs automatically once at the beginning when the game is played. 
    It initializes all locations in the possibleInboxTexts field. 
    It stores each preview text possibility as a single string.
    */
    private void Awake() 
    {
        possibleInboxTexts = new string[numEmails, 2];

        /* FIRST INBOX ENTRY **********************************************/
        // index 0 is the scam email preview 
        possibleInboxTexts[0, 0] = "scam email 0"; 
        // index 1 is the safe email preview
        possibleInboxTexts[0, 1] = "safe email 0";

        /* SECOND INBOX ENTRY **********************************************/
        // index 0 is the scam email preview 
        possibleInboxTexts[1, 0] = "scam email 1"; 
        // index 1 is the safe email preview
        possibleInboxTexts[1, 1] = "safe email 1";

        /* THIRD INBOX ENTRY **********************************************/
        // index 0 is the scam email preview 
        possibleInboxTexts[2, 0] = "scam email 2"; 
        // index 1 is the safe email preview
        possibleInboxTexts[2, 1] = "safe email 2";

        /* FOURTH INBOX ENTRY **********************************************/
        // index 0 is the scam email preview 
        possibleInboxTexts[3, 0] = "scam email 3"; 
        // index 1 is the safe email preview
        possibleInboxTexts[3, 1] = "safe email 3";

        /* FIFTH INBOX ENTRY **********************************************/
        // index 0 is the scam email preview 
        possibleInboxTexts[4, 0] = "scam email 4"; 
        // index 1 is the safe email preview
        possibleInboxTexts[4, 1] = "safe email 4";
    }

    /*
    This method assigns one of the possible email preview texts for the given inbox 
    location (stored in previewNumber) to the inboxText object. 
    The choice of assigning a safe or scam email is based on the corresponding entry in the 
    emailStatus array from the GameData class.
    */
    void Update()
    {
        // assures myInboxText object was assigned in inspector and previewNumber from
        // inspector is not out of bounds
        if (myInboxText != null && previewNumber >= 0 && previewNumber < numEmails) 
        {
            int choiceForEntry = GameData.emailStatus[previewNumber]; // 0 or 1 from GameData
            myInboxText.text = possibleInboxTexts[previewNumber, choiceForEntry];
        }              
    }
}
