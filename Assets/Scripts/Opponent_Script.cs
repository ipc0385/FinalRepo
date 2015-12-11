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
    private GameObject[] PlayCardsHere;

	void Think ()
	{
		//a smart ai would have things happen here,
        int position = Random.Range(0, 3);
        if (false == PlayCardsHere[position].GetComponent<Cells>().isOccupied)
        {
            if (PlayCardsHere[position].GetComponent<Cells>().isOccupied == false)
            {
                MyEffect.Affect(0, 0, gameObject, PlayCardsHere[position]);
            }
            else
            {
                //Debug.Log("Bad Roll - Rerolling");
                Think();
                return;
            }
        }

        myDuration = 1f;
	}

    void Update()
    {
        myDuration -= Time.deltaTime;

        if (myDuration <= 0f)
        {
            if (myFinishTurnMessenger)
            {
                myFinishTurnMessenger.Publish();
            }
        }
    }

    private float myDuration = 0f;

}
