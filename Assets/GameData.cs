using UnityEngine;

/*
This class initializes and stores global data for the game that multile other classes
need access to.
*/
public static class GameData 
{
    // This array stores the safe/scam status of each inbox email
    public const int NUM_EMAILS = 5;  // number of emails in the inbox
    private static int[] emailStatus = new int[NUM_EMAILS];

    // This is the index of whichever email is currently being viewed or
    // -1 if no email is selected
    private static int currentEmailIndex = -1;
    

    /*
    This method initializes the emailStatus array. It will randomly assign a 0 or 1 for
    each email that will be used to determine whether that email will be a scam (0) or
    a safe (1) email on that play through.
    
    NOTE: the runtime tag forces Unity to run this method automatically on every single 
    Play Mode press. It acts as a constructor since a typical constructor should not be used
    in Unity. Unity uses caching and will not reliably run a consrtuctor on Play
    */
    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
    private static void Initialize()
    {      
        // Set status for inbox emails 0 for scam and 1 for safe
        for (int i = 0; i < NUM_EMAILS; i++)
        {
            // Random.Range for integers is inclusive of min, exclusive of max
            emailStatus[i] = Random.Range(0, 2);
        } 
    }

    // Getter for emailStatus
    public static int getEmailStatus(int index)
    {
        if (index >= 0 && index < NUM_EMAILS) // check that given index is in bounds
        {
            return emailStatus[index];
        } else {
            return -1; //error case
        }
    }

    // Setter for currentEmailIndex
    public static void updateCurrentEmailIndex(int newIndex)
    {
        if (newIndex >= 0 && newIndex < NUM_EMAILS) // check that given index is in bounds
        {
            currentEmailIndex = newIndex;
        }
    }

    // Getter for currentEmailIndex
    public static int getCurrentEmailIndex()
    {
        return currentEmailIndex;
    }
}


