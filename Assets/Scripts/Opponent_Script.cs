using UnityEngine;
using System.Collections;

public class Opponent_Script : MonoBehaviour 
{

	//the AI thinks and then finishes its turn
	[SerializeField]
	private Messenger_Script myFinishTurnMessenger;

	[SerializeField]
	private Player_Script myPlayer;

	void Think ()
	{
		//a smart ai would have things happen here,

		if (myFinishTurnMessenger)
		{
			myFinishTurnMessenger.Publish();
		}
	}

}
