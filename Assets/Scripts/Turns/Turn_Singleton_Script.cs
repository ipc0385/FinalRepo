using UnityEngine;
using System.Collections;

public class Turn_Singleton_Script : MonoBehaviour 
{

	[SerializeField]
	private Messenger_Script _myEndingMessenger, _myBeginningMessenger;

	[SerializeField]
	private Finite_State_Machine_Script _myFSM;

	public Finite_State_Machine_Script myFiniteStateMachine
	{
		get
		{
			if(null == _myFSM)
			{
				_myFSM = gameObject.AddComponent<Finite_State_Machine_Script>() as Finite_State_Machine_Script;
			}

			return _myFSM;
		}
	}

	public Messenger_Script myEndingMessenger
	{
		get
		{
			if (null == _myEndingMessenger)
			{
				_myEndingMessenger = gameObject.AddComponent<Messenger_Script>() as Messenger_Script;

				_myEndingMessenger.myName = name + "'s turn beginning messenger";
			}

			return _myEndingMessenger;
		}
	}

	public Messenger_Script myBeginningMessenger
	{
		get
		{
			if (null == _myBeginningMessenger)
			{
				_myBeginningMessenger = gameObject.AddComponent<Messenger_Script>() as Messenger_Script;

				_myBeginningMessenger.myName = name + "'s turn beginning messenger";
			}

			return _myBeginningMessenger;
		}
	}

	public static Turn_Singleton_Script Get
	{
		get
		{
			if (null == ourSingleton)
			{
				Object prefab = Resources.Load("Prefabs/TurnSingleton");

				GameObject gameObject = Instantiate(prefab) as GameObject;

				gameObject.name = prefab.name;

				ourSingleton = gameObject.GetComponent<Turn_Singleton_Script>();
			}

			return ourSingleton;
		}
	}

	//these are for appending player states onto the game state machine
	private Finite_State_Script myFirstState, myLastState;

	private static Turn_Singleton_Script ourSingleton;

	public Player_Script myTurningPlayer;

	void Start ()
	{
		ourSingleton = this;
	}

}
