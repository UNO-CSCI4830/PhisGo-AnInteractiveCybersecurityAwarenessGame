using UnityEngine;

public static class GameData 
{
    // static array accessible anywhere - example use: GameData.emailStatus[i]
    private static int inboxSize = 5;  // number of emails in the inbox
    public static int[] emailStatus = new int[inboxSize]; // safe/scam status of each inbox email
    

    // This tag forces Unity to run this method automatically on every single Play Mode press
    // Do NOT replace with a constructor as Unity uses caching and will not reliably run
    // the consrtuctor on Play
    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
    private static void Initialize()
    {       
        // Set status for inbox emails 0 for scam and 1 for safe
        for (int i = 0; i < inboxSize; i++)
        {
            // Random.Range for integers is inclusive of min, exclusive of max
            emailStatus[i] = Random.Range(0, 2);
        } 
        Debug.Log(string.Join(", ", emailStatus));  
    }
}


