using UnityEngine;
using System.Collections;

public class Spawn_Effect_Script : Effect_Script
{
	[SerializeField]
	private GameObject mySpawn;

    [SerializeField]
    private Vector3 myInitialSize = Vector3.one;

	public override int Affect(int initial, int input, GameObject inSubject, GameObject inObject)
	{
		GameObject spawn = Instantiate(mySpawn);

		spawn.transform.parent = inObject.transform;

        spawn.transform.localPosition = Vector3.up * 0.35f;

        spawn.transform.localScale = myInitialSize;

		return input;
	}
}
