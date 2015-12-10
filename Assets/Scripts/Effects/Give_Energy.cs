using UnityEngine;
using System.Collections;

public class Give_Energy : Effect_Script {

    [SerializeField]
    private int Amount; 


    public override int Affect(int initial, int input, GameObject inSubject, GameObject inObject)
    {
        Player_Script player = inSubject.GetComponent<Player_Script>();
        if (player)
        {
            player.GiveMana(Amount);
        }
        return input;
    }
	
}
