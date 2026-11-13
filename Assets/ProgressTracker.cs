using UnityEngine;

/*
    This class keeps track of the user's progress through a level and will mark and
    return which emails have been completed.
*/
public static class ProgressTracker 
{
    // keeps track of which emails in the inbox have been completed
    private static bool[] completed = new bool[GameData.NUM_EMAILS];


    /*
    This method initializes the "completed" array. 
    
    NOTE: the runtime tag forces Unity to run this method automatically on every single 
    Play Mode press. It acts as a constructor since a typical constructor should not be used
    in Unity. Unity uses caching and will not reliably run a consrtuctor on Play
    */
    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
    private static void Initialize()
    {
        // Initialize array. At the beginning there are no completed emails
        for (int i = 0; i < GameData.NUM_EMAILS; i++)
        {
            completed[i] = false;
        }
    }

    /*
    This method marks the email at the given index as complete
    */
    public static void MarkComplete(int index)
    {
        if (index >= 0 && index < GameData.NUM_EMAILS) // check array bounds
        {
            completed[index] = true;
        }
    }

    /*
    This method returns whether the email at the given index has been completed
    */
    public static bool IsComplete(int index)
    {
        if (index >= 0 && index < GameData.NUM_EMAILS) // check array bounds
        {
            return completed[index];
        } else {
            return false; // error case
        }
    }

    /*
    This method returns whether the entire level is complete. This occurs when every inbox
    entry has been completed
    */
    public static bool LevelComplete()
    {
        for (int i = 0; i < GameData.NUM_EMAILS; i++)
        {
            if(!IsComplete(i))
            {
                return false; // if a single email is not done, the level is not complete
            }
        }

        return true; // only reaches here if all emails were complete
    }
}