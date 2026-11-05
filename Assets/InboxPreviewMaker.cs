using UnityEngine;
using TMPro;

public class InboxPreviewMaker : MonoBehaviour
{
    // Reference to the text on the inbox email sprite
    [SerializeField] private TMP_Text myInboxText;

    // stores the possible inbox previews to show 
    private string[] possibleInboxTexts = new string[2]; 

    // stores each inbox preview possibility once at the beginning
    private void Awake() 
    {
        // index 0 is the scam email preview 
        possibleInboxTexts[0] = "scam email 0"; 

        // index 1 is the safe email preview
        possibleInboxTexts[1] = "safe email 0";
    }

    void Update()
    {
        // Randomly assign one of the possible inbox previews
        if (myInboxText != null)
        {
            int randomForIndex = GameData.emailStatus[0]; //contains 0 or 1
            myInboxText.text = possibleInboxTexts[randomForIndex];
            //Debug.Log($"Setting text on {myInboxText.gameObject.name} to: '{possibleInboxTexts}'", this);
        }              
    }
}
