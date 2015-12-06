using UnityEngine;
using System.Collections;

public class MouseDown_Script : MonoBehaviour {

	// Update is called once per frame
	void Update () {
	
	}

	void OnMouseDown ()
	{
		if(enabled)
		{
			myMessengerScript.Publish();
		}
	}
	
	public Messenger_Script myMessengerScript
	{
		get
		{
			if(null == _myMessengerScript)
			{
				_myMessengerScript = gameObject.AddComponent<Messenger_Script>() as Messenger_Script;

				_myMessengerScript.myName = name + "'s lazy messenger";
			}

			return _myMessengerScript;
		}
	}

	[SerializeField]
	private Messenger_Script _myMessengerScript;

}
