using UnityEngine;
using System.Collections;

public class Spawn_Effect_Script : Effect_Script
{
	[SerializeField]
	private GameObject mySpawn;

	public override int Affect(int initial, int input, GameObject inSubject, GameObject inObject)
	{
		GameObject spawn = Instantiate(mySpawn);

		spawn.transform.parent = inObject.transform;

		return input;
	}
}
