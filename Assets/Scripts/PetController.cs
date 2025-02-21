//////////////////////////////////////////////
//Assignment/Lab/Project: Virtual Pet Assignment
//Name: Blaise Harris
//Section: SGD.213.0021
//Instructor: Aurore Locklear
//Date: 02/21/2025
/////////////////////////////////////////////
using TMPro;
using UnityEngine;

public class PetController : MonoBehaviour
{
    public static PetController Instance { get; private set; }
    public Pet CurrentPet { get; private set; }
    [SerializeField] private TMP_Text resultText;

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

    public void OnClickPlayWith()
    {
        if (CurrentPet.PlayWithPet())
        {
            resultText.text = "You have successfully played with " + CurrentPet.Name;
        }
        else
        {
            resultText.text = CurrentPet.Name + " is too tired to play.";
        }
    }

    public void OnClickFeed()
    {
        if (CurrentPet.FeedPet())
        {
            resultText.text = "You have successfully fed " + CurrentPet.Name;
        }
        else
        {
            resultText.text = CurrentPet.Name + " is too full to eat anymore.";
        }
    }

    public void OnClickRest()
    {
        if (CurrentPet.RestPet())
        {
            resultText.text = CurrentPet.Name + " has successfully rested.";
        }
        else
        {
            resultText.text = CurrentPet.Name + " has too much energy to rest.";
        }
    }
}
