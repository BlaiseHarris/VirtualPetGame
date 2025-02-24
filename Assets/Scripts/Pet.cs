//////////////////////////////////////////////
//Assignment/Lab/Project: Virtual Pet Assignment
//Name: Blaise Harris
//Section: SGD.213.0021
//Instructor: Aurore Locklear
//Date: 02/21/2025
/////////////////////////////////////////////

using UnityEngine;

/// <summary>
/// Represents a pet with basic properties like name, fullness, happiness, and tiredness.
/// </summary>
public class Pet
{
    private string name;
    private int fullness;
    private int happiness;
    private int tiredness;

    /// <summary>
    /// Constructor for a pet instance. Takes a name and the rest of the stats are predetermined: fullness, happiness, and tiredness.
    /// </summary>
    public Pet(string name)
    {
        this.name = name;
        this.fullness = 10;
        this.happiness = 10;
        this.tiredness = 0;
    }

    /// <summary>
    /// Gets or sets the name of the pet.
    /// </summary>
    public string Name
    {
        get
        {
            return this.name;
        }
        set
        {
            name = value;
        }
    }

    /// <summary>
    /// Gets or sets the fullness of the pet.
    /// </summary>
    public int Fullness
    {
        get
        {
            return this.fullness;
        }
        set
        {
            fullness = value;
        }
    }

    /// <summary>
    /// Gets or sets the happiness of the pet.
    /// </summary>
    public int Happiness
    {
        get
        {
            return this.happiness;
        }
        set
        {
            happiness = value;
        }
    }

    /// <summary>
    /// Gets or sets the tiredness of the pet.
    /// </summary>
    public int Tiredness
    {
        get
        {
            return this.tiredness;
        }
        set
        {
            tiredness = value;
        }
    }

    /// <summary>
    /// Updates the stats for the pet and decay values increase as other stats fall.
    /// </summary>
    public void UpdateStats()
    {
        this.tiredness += 1;
        this.fullness -= 2;
        this.happiness -= 1;

        if (this.tiredness > 5)
        {
            if (this.tiredness > 10)
            {
                this.tiredness = 10;
            }
            this.happiness -= 1;
        }

        if (this.fullness < 5)
        {
            if (this.fullness < 0)
            {
                this.fullness = 0;
            }
            this.happiness -= 1;
        }

        if (this.happiness < 0)
        {
            this.happiness = 0;
        }
    }

    // The interactions below return bools, to alert the pet controller whether the actions succeeds

    /// <summary>
    /// Updates the stats for the pet when it has been fed. This adds 4 to the fullness and 2 to happiness if fullness less than 6.
    /// </summary>
    public bool FeedPet()
    {
        if (this.fullness < 10) 
        {
            this.fullness += 4;

            if (this.fullness < 6)
            {
                this.happiness += 2;
            }

            if (this.fullness > 10)
            {
                this.fullness = 10;
            }

            if (this.happiness > 10)
            {
                this.happiness = 10;
            }
            return true;
        }
        return false;
    }

    /// <summary>
    /// Updates the stats for the pet when he plays. This adds 4 to the happiness if fullness is above 5. Otherwise, 2 to happiness if pet is not above 4 on the tired stat. For both succesful play dates paths tiredness goes down by 2.
    /// </summary>
    public bool PlayWithPet()
    {
        if (this.tiredness <= 4)
        {
            this.happiness += 4;
            if (this.fullness <= 5)
            {
                this.happiness -= 2;
            }
            if (this.happiness > 10)
            {
                this.happiness = 10;
            }

            this.tiredness += 2;
            return true;
        }
        return false;
    }

    /// <summary>
    /// Updates the stats for the pet when he rests. He can only rest above 5 tiredness.
    /// </summary>
    public bool RestPet()
    {
        if(this.tiredness >= 6)
        {
            this.tiredness -= 10;
            this.happiness += 2;

            if (this.tiredness < 10)
            {
                this.tiredness = 0;
            }

            if (this.happiness > 10)
            {
                this.happiness = 10;
            }
            return true;
        }
        return false;
    }
}
