using UnityEngine;
using System.Collections;

public class Opponent_Script : MonoBehaviour 
{

	//the AI thinks and then finishes its turn
	[SerializeField]
	private Messenger_Script myFinishTurnMessenger;

	[SerializeField]
	private Player_Script myPlayer;

    public Effect_Script MyEffect;

    [SerializeField]
    private GameObject PlayCardsHere1;
    [SerializeField]
    private GameObject PlayCardsHere2;
    [SerializeField]
    private GameObject PlayCardsHere3;

	void Think ()
	{
		//a smart ai would have things happen here,
        MyEffect.Affect(0, 0, gameObject, PlayCardsHere1);
        


		if (myFinishTurnMessenger)
		{
			myFinishTurnMessenger.Publish();
		}
	}

}
