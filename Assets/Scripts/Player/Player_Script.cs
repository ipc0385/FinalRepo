using UnityEngine;
using System.Collections;

public class Player_Script : MonoBehaviour {

	[SerializeField]
	public Effect_Script[] myManaEffects;
	public int myManaValue;
	public Card_Holder_Script myDeck, myGraveyard, myHand;

	[SerializeField]
	private Turn_State_Script _myTurnState;

	public Turn_State_Script myTurnState
	{
		get
		{
			if(null == _myTurnState)
			{
				_myTurnState = gameObject.AddComponent<Turn_State_Script>();

				_myTurnState.myOwner = this;

				Finite_State_Machine_Script fsm = Turn_Singleton_Script.Get.myFiniteStateMachine;

				if(null == fsm.CurrentState)
				{
					fsm.CurrentState = _myTurnState;

					_myTurnState.next = _myTurnState;
				}
				else
				{
					_myTurnState.next = fsm.CurrentState;

					fsm.CurrentState.next = _myTurnState;
				}
			}

			return _myTurnState;
		}
	}

	void Turn ()
	{
		Turn_Singleton_Script.Get.myFiniteStateMachine.CurrentState = myTurnState.next;
	}

	void Start()
	{
		Debug.Log(myTurnState);
	}

	public int mana
	{
		get
		{
			return Effect_Script.AffectsList(myManaEffects, myManaValue, myManaValue, gameObject, gameObject);
		}
	}

	public Card_Script Draw ()
	{
		if (myDeck.myCards.Length > 0)
		{
			return myDeck.myCards[Random.Range(0, myDeck.myCards.Length)];
		}

		return null;
	}

	public void Hand (Card_Script input)
	{
		if (input)
		{
			input.transform.parent = myHand.transform;
		}
	}

	private void Draw_to_Hand ()
		//draws a card from the deck and puts it in the hand
	{
		Hand(Draw());
	}

    public void GiveMana( int manaNum)
    {
        Term_Effect_Script Manergy = gameObject.AddComponent<Term_Effect_Script>();
        Manergy.myTerm = manaNum;

        Debug.Log("I have " + mana + " Energy! ༼ つ ◕_◕ ༽つ ~ GIVE ME " + manaNum + " MANA ~");
        myManaEffects = Effect_Script.Append(myManaEffects,Manergy);
        Debug.Log("I now have " + mana + "Energy!");
    }


    //public Color color;
}
