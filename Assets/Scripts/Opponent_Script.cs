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
        if (false == PlayCardsHere1.GetComponent<Cells>().isOccupied)
        {
            MyEffect.Affect(0, 0, gameObject, PlayCardsHere1);
        }

        myDuration = 1f;
	}

    void Update()
    {
        myDuration -= Time.deltaTime;

        if(myDuration <= 0f)
        {
            if (myFinishTurnMessenger)
            {
                myFinishTurnMessenger.Publish();
            }
        }
    }

    private float myDuration = 0f;

}
