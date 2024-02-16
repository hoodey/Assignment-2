using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSheet : MonoBehaviour
{
    //Variables for stats
    [SerializeField] string userName = "";
    [SerializeField] int profBonus = 0;
    [SerializeField] bool finesseWep = false;
    [SerializeField] [Range(-5,5)] int strMod = 0;
    [SerializeField] [Range(-5,5)] int dexMod = 0;


    // Start is called before the first frame update
    void Start()
    {
        //Set roll variables
        int playerRoll = Random.Range(1, 21);
        int enemyAC = Random.Range(10, 21);
        //Output to the console results
        Debug.Log(userName + "'s hit modifier is +" + hitMod(profBonus, strMod, dexMod, finesseWep));
        Debug.Log("Enemy's AC is " + enemyAC);
        Debug.Log(userName + " rolled a " + playerRoll);
        if ((hitMod(profBonus, strMod, dexMod, finesseWep) + playerRoll) >= enemyAC)
            Debug.Log("Congrats, you hit. Roll for your 1D4 damage!");
        else if (playerRoll == 1)
            Debug.Log("You critically missed. You shot an arrow into your own knee.");
        else if (playerRoll == 20)
            Debug.Log("You crit! You shot an arrow into your opponents knee. They never adventured again");
        else
            Debug.Log("You missed, better luck next time!");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //Function to determine user's hit modifier
    int hitMod(int prof, int str, int dex, bool finesse)
    {
        int hitModifier;
        if (finesse)
        {
            if (str > dex)
            {
                hitModifier = prof + str;
            }
            else
            {
                hitModifier = prof + dex;
            }
        }
        else
        {
            hitModifier = prof + str;
        }
        return hitModifier;
    }
}
