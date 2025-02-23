//////////////////////////////////////////////
//Assignment/Lab/Project: Virtual Pet Assignment
//Name: Blaise Harris
//Section: SGD.213.0021
//Instructor: Aurore Locklear
//Date: 02/21/2025
/////////////////////////////////////////////
using System.Collections;
using UnityEngine;

public class PetController : MonoBehaviour
{
    public static PetController Instance;
    public Pet CurrentPet;
    private float lastUpdateTime;
    private bool timerStarted = false;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
    }


    public void CreatePet(string petName)
    {
        CurrentPet = new Pet(petName);
    }

    public void StartTimer()
    {
        StartCoroutine(UpdatePetStatsCoroutine());
    }

    private IEnumerator UpdatePetStatsCoroutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(10f);
            CurrentPet.UpdateStats();
        }
    }


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
}
