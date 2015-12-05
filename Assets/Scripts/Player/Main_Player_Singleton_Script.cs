using UnityEngine;
using System.Collections;

public class Main_Player_Singleton_Script : MonoBehaviour {

	static public Player_Script main
	{
		get
		{
			if (null == ourSingleton)
			{
				Object prefab = Resources.Load("Prefabs/MainPlayer");

				GameObject gameObject = Instantiate(prefab) as GameObject;

				gameObject.name = prefab.name;

				ourSingleton = gameObject.GetComponent<Player_Script>();
			}

			return ourSingleton;
		}
	}

	static private Player_Script ourSingleton;
}
