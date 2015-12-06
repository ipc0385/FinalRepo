using UnityEngine;
using System.Collections;

public class Finite_State_Messenger_Script : Finite_State_Script
{

	[SerializeField]
	private Messenger_Script myEnterMessenger, myLeaveMessenger, myUpdateMessenger;

	public override void Leave()
	{
		base.Leave();

		if (myLeaveMessenger)
		{
			myLeaveMessenger.Publish();
		}
	}

	public override void Enter()
	{
		base.Enter();

		if (myEnterMessenger)
		{
			myEnterMessenger.Publish();
		}
	}

	void Update()
	{
		if (myUpdateMessenger)
		{
			myUpdateMessenger.Publish();
		}
	}

	public Finite_State_Messenger_Script Set(Messenger_Script inEnterMessenger, Messenger_Script inUpdateMessenger, Messenger_Script inLeaveMessenger)
	{
		myEnterMessenger = inEnterMessenger;
		myUpdateMessenger = inUpdateMessenger;
		myLeaveMessenger = inLeaveMessenger;

		return this;
	}

}
