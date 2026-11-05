using UnityEngine;
using TMPro;

public class InboxPreviewMaker : MonoBehaviour
{
    // Text object on the inbox email sprite. This is set in the Inspector window
    [SerializeField] private TMP_Text myInboxText;

    // Number of email previews in the inbox. This is set in the Inspector window
    [SerializeField] private int previewNumber;

    // 2D array stores all possible inbox previews to show 
    // first index - number of entries in the inbox
    // second index - number of possible email previews to display for that entry
    private string[,] possibleInboxTexts = new string[5, 2]; 

    // store each inbox preview possibility once at the beginning as a single string
    private void Awake() 
    {
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

    void Update()
    {
        // Randomly assign one of the possible inbox previews for the given preview entry
        if (myInboxText != null)
        {
            int randomForIndex = GameData.emailStatus[previewNumber]; 
            myInboxText.text = possibleInboxTexts[previewNumber, randomForIndex];
        }              
    }
}
