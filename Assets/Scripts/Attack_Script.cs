using UnityEngine;
using System.Collections;

public class Attack_Script : MonoBehaviour 
{
	public int myDamageValue;
	public Effect_Script[] myDamageEffects, myTargetEffects;

	public int damage
	{
		get
		{
			return Effect_Script.AffectsList(myDamageEffects, myDamageValue, gameObject, gameObject);
		}
	}
}
