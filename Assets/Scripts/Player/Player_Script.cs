using UnityEngine;
using System.Collections;

public class Player_Script : MonoBehaviour {

	[SerializeField]
	public Effect_Script[] myManaEffects;
	public int myManaValue;
	public Card_Holder_Script myDeck, myGraveyard, myHand;

	public int mana
	{
		get
		{
			return Effect_Script.AffectsList(myManaEffects, myManaValue, gameObject, gameObject);
		}
	}

	public Card_Script Draw ()
	{
		return myDeck.myCards[Random.Range(0, myHand.transform.childCount)];
	}

	public void Hand (Card_Script input)
	{
		input.transform.parent = myHand.transform;
	}

	void Update()
	{
		if(Input.GetKey(KeyCode.F))
		{
			Hand(Draw());
		}
	}

}
