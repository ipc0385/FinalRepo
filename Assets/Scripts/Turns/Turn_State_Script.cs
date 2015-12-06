using UnityEngine;
using System.Collections;

public class Turn_State_Script : Finite_State_Script {

	[SerializeField]
	public Player_Script myOwner;

	[SerializeField]
	private Messenger_Script _myTurnBeginningMessenger, _myTurnEndingMessenger, _myMovementMessenger, _myCombatMessenger;

	public Messenger_Script myTurnBeginningMessenger
	{
		get
		{
			if (null == _myTurnBeginningMessenger)
			{
				_myTurnBeginningMessenger = gameObject.AddComponent<Messenger_Script>() as Messenger_Script;

				_myTurnBeginningMessenger.myName = name + "'s turn beginning messenger";
			}

			return _myTurnBeginningMessenger;
		}
	}

	public Messenger_Script myTurnEndingMessenger
	{
		get
		{
			if (null == _myTurnEndingMessenger)
			{
				_myTurnEndingMessenger = gameObject.AddComponent<Messenger_Script>() as Messenger_Script;

				_myTurnEndingMessenger.myName = name + "'s turn ending messenger";
			}

			return _myTurnEndingMessenger;
		}
	}

	public Messenger_Script myMovementMessenger
	{
		get
		{
			if (null == _myMovementMessenger)
			{
				_myMovementMessenger = gameObject.AddComponent<Messenger_Script>() as Messenger_Script;

				_myMovementMessenger.myName = name + "'s movement messenger";
			}

			return _myMovementMessenger;
		}
	}

	public Messenger_Script myCombatMessenger
	{
		get
		{
			if (null == _myCombatMessenger)
			{
				_myCombatMessenger = gameObject.AddComponent<Messenger_Script>() as Messenger_Script;

				_myCombatMessenger.myName = name + "'s combat messenger";
			}

			return _myCombatMessenger;
		}
	}
	
	public override void Enter()
	{
		base.Enter();

		Turn_Singleton_Script.Get.myTurningPlayer = myOwner;

		Turn_Singleton_Script.Get.myBeginningMessenger.Publish();

		myTurnBeginningMessenger.Publish();
	}

	public override void Leave()
	{
		base.Leave();

		myCombatMessenger.Publish();
		myMovementMessenger.Publish();

		myTurnEndingMessenger.Publish();

		Turn_Singleton_Script.Get.myEndingMessenger.Publish();

		Turn_Singleton_Script.Get.myTurningPlayer = null;
	}

}
