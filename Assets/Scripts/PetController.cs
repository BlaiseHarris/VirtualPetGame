//////////////////////////////////////////////
//Assignment/Lab/Project: Virtual Pet Assignment
//Name: Blaise Harris
//Section: SGD.213.0021
//Instructor: Aurore Locklear
//Date: 02/21/2025
/////////////////////////////////////////////

using System.Collections;
using UnityEngine;

/// <summary>
/// Controls the virtual pet's behaviors and manages game logic related to the pet.
/// Implements the Singleton.
/// </summary>
public class PetController : MonoBehaviour
{
    /// <summary>
    /// Singleton instance of PetController.
    /// </summary>
    public static PetController Instance;
    public Pet CurrentPet; // Current adopted pet

    private void Awake()
    {
        if (Instance != null && Instance != this) // Initializes singleton instance if one is not found
        {
            Destroy(this.gameObject);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
    }

    /// <summary>
    /// Creates a new pet with the given name.
    /// </summary>
    public void CreatePet(string petName)
    {
        CurrentPet = new Pet(petName);
    }

    /// <summary>
    /// Starts the coroutine that periodically updates the stats.
    /// </summary>
    public void StartTimer()
    {
        StartCoroutine(UpdatePetStatsCoroutine());
    }

    /// <summary>
    /// Coroutine that updates the stats every 10 seconds.
    /// </summary>
    private IEnumerator UpdatePetStatsCoroutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(10f);
            CurrentPet.UpdateStats();
        }
    }

    // The three methods below take the bool that the pet class returns to determine what response to give to the game UI to update the player
    
    /// <summary>
    /// Handles the play action for the pet and returns a result message.
    /// </summary>
    public string PlayWithPetResult()
    {
        if (CurrentPet.PlayWithPet())
        {
            return "You have successfully played with " + CurrentPet.Name;
        }
        else
        {
            return CurrentPet.Name + " is too tired to play.";
        }
    }

    /// <summary>
    /// Handles the feeding action for the pet and returns a result message.
    /// </summary>
    public string FeedPetResult()
    {
        if (CurrentPet.FeedPet())
        {
            return "You have successfully fed " + CurrentPet.Name;
        }
        else
        {
            return CurrentPet.Name + " is too full to eat anymore.";
        }
    }

    /// <summary>
    /// Handles the rest action for the pet and returns a result message.
    /// </summary>
    public string RestpetResult()
    {
        if (CurrentPet.RestPet())
        {
            return CurrentPet.Name + " has successfully rested.";
        }
        else
        {
            return CurrentPet.Name + " has too much energy to rest.";
        }
    }

    /// <summary>
    /// Resets the singleton instance of PetController for play again functionality.
    /// </summary>
    public static void ResetSingleton()
    {
        Destroy(Instance.gameObject);        
    }

}
