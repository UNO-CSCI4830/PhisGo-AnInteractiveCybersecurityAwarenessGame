using UnityEngine;
using TMPro; 

public class EmailTextMaker : MonoBehaviour
{
    // Text object for the emails. This is set in the Inspector window
    public TextMeshProUGUI emailText;
    // Index of email in the inbox. This is set in the Inspector window
    [SerializeField] private int inboxIndex;

    // 2D array stores all possible email texts to show 
    // first index - number of entries in the inbox
    // second index - number of possible email texts to display for that entry
    private string[,] possibleEmailTexts = new string[5, 2]; 

    // store each email text possibility once at the beginning as a single string
    private void Awake() 
    {
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

    // This method will run when the inbox entry is clicked
    // Assigns one of the possible emails for the given inbox entry
    public void OnButtonClick()
    {
        int choiceForEntry = GameData.emailStatus[inboxIndex]; //generated in GameData
        emailText.text = possibleEmailTexts[inboxIndex, choiceForEntry];
    }
}
