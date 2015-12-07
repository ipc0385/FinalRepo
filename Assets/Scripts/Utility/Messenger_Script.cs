using UnityEngine;
using System.Collections;

[System.Serializable]
public class Subscription
{
	[SerializeField]
	public GameObject Key;

	[SerializeField]
	public string Value;

	public Subscription(GameObject inKey, string inValue)
	{
		Key = inKey;
		Value = inValue;
	}
}

public class Messenger_Script : MonoBehaviour
{

	[SerializeField]
	private string _myName;

	[SerializeField]
	private Subscription[] mySubscribers;

	private int size
	{
		get
		{
			return null == mySubscribers ? 0 : mySubscribers.Length;
		}
	}

	public string myName
	{
		set
		{
			_myName = value;
		}

		get
		{
			return _myName;
		}
	}

	public void Subscribe(Subscription input)
	{
		//Debug.Log(input.Key + " subscribed to " + myName + " the " + this + ".");

		int top = size;

		var temp = new Subscription[top + 1];

		for (int i = 0; i < top; i++)
		{
			temp[i] = mySubscribers[i];
		}

		temp[top] = input;

		mySubscribers = temp;
	}

	public void Unsubscribe(GameObject input)
	{
		//Debug.Log(input + " unsubscribed to " + myName + " the " + this + ".");

		int top = size;

		var temp = new Subscription[top - 1];

		int j = 0;
		for (int i = 0; i < top; i++)
		{
			if (mySubscribers[i].Key != input)
			{
				temp[i] = mySubscribers[j++];
			}
		}

		mySubscribers = temp;
	}

	public void Publish()
	{
		if (enabled)
		{
			//Debug.Log(myName + " the " + this + " published.");

			if (null != mySubscribers)
			{
				foreach (var entry in mySubscribers)
				{
					entry.Key.SendMessage(entry.Value);
				}
			}
		}
	}
}
