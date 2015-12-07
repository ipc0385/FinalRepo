using UnityEngine;
using System.Collections;

public class Term_Effect_Script : Effect_Script {

	public int myTerm;

	public override int Affect(int initial, int input, GameObject inSubject, GameObject inObject)
	{
		return input + myTerm;
	}

}
