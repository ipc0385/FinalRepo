using UnityEngine;
using System.Collections;

public class Health_Script : Effect_Script {

	[SerializeField]
	private int myHealthValue, myDamageValue;

	[SerializeField]
	private Effect_Script[] myHealthEffects, myDamageEffects;
	
	public int health
	{
		get
		{
			return Effect_Script.AffectsList(myDamageEffects, myDamageValue, gameObject, gameObject);
		}
	}

	public int damage
	{
		get
		{
			return Effect_Script.AffectsList(myHealthEffects, myHealthValue, gameObject, gameObject);
		}
	}

	public bool isDamaged
	{
		get
		{
			return damage > 0;
		}
	}

	public override int Affect(int input, GameObject inSubject, GameObject inObject)
	{
		return health - damage;
	}

	public void Checkup ()
	{
		if(health < damage)
		{
			transform.parent = GetComponent<Card_Script>().myCardHolder.myOwner.myGraveyard.transform;
		}
	}

	public void ApplyDamage(int input)
	{
		Term_Effect_Script termDamage = gameObject.AddComponent<Term_Effect_Script>();

		termDamage.myTerm = -input;

		Effect_Script.Append(myDamageEffects, termDamage);
	}

}
