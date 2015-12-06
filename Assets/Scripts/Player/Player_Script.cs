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
		Debug.Log(Turn_Singleton_Script.Get.myFiniteStateMachine.CurrentState + " into " + myTurnState.next);

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
