using UnityEngine;
using System.Collections;

public class CardDraw : Effect_Script {

    public override int Affect(int initial, int input, GameObject inSubject, GameObject inObject)
    {
        Player_Script player = inSubject.GetComponent<Player_Script>();
        if(player)
        {
            player.Hand(player.Draw());
        }
        return input;
    }

}
