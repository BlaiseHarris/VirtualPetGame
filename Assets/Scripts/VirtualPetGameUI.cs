//////////////////////////////////////////////
//Assignment/Lab/Project: Virtual Pet Assignment
//Name: Blaise Harris
//Section: SGD.213.0021
//Instructor: Aurore Locklear
//Date: 02/22/2025
/////////////////////////////////////////////

using TMPro;
using UnityEngine;

public class VirtualPetGameUI : MonoBehaviour
{
    [SerializeField] private TMP_Text resultText;
    [SerializeField] private TMP_Text nameText;


    public void Start()
    {
        nameText.text = "Name: " + PetController.Instance.CurrentPet.Name;
        PetController.Instance.StartTimer();
    }

    private void Update()
    {
        if(PetController.Instance.CurrentPet.Happiness <= 2)
        {
            resultText.color = Color.yellow;
            resultText.text = "Quickly entertain your pet! Before your pet gets taken away!";
        }
        if (PetController.Instance.CurrentPet.Fullness <= 2)
        {
            resultText.color = Color.yellow;
            resultText.text = "Quickly feed your pet! Before your pet gets taken away!";
        }
        if (PetController.Instance.CurrentPet.Tiredness >= 8)
        {
            resultText.color = Color.yellow;
            resultText.text = "Quickly feed your pet! Before your pet gets taken away!";
        }
    }

    public void OnPlayWithClicked()
    {
        resultText.color = Color.white;
        resultText.text = PetController.Instance.PlayWithPetResult();
        Debug.Log("Working");
    }

    public void OnFeedClicked()
    {
        resultText.color = Color.white;
        resultText.text = PetController.Instance.FeedPetResult();
    }

    public void OnRestClicked()
    {
        resultText.color = Color.white;
        resultText.text = PetController.Instance.RestpetResult();
    }
}

