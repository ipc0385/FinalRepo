using UnityEngine;
using System.Collections;

public class Card_Script : Effect_Script {

	public Effect_Script[] myPlayEffects, myManaEffects;
	public int myManaValue;

	public int mana;

    [System.Serializable]
    private class Mask
    {
        [SerializeField]
        public bool isOccupied, isOwned;

        //returns true if matches
        //returns false if fails
        
        public bool Match(GameObject inSubject, GameObject inObject)
        {
            
            Player_Script playerScript = inSubject.GetComponent<Player_Script>();
		
            Player_Script ownerScript = inObject.GetComponent<Owner_Script>().myOwner;

            bool result = true;

            if(isOwned)
            {
                if(playerScript != ownerScript)
                {
                    result = false;
                }
            }
            
            if(isOccupied)
            {
                if(false != inObject.GetComponent<Cells>().isOccupied)
                {
                    result = false;
                }
            }

            return result;
        }
    }

    [SerializeField]
    private Mask myMaskNegative, myMaskPositive;

	public Card_Holder_Script myCardHolder
	{
		get
		{
			return GetComponentInParent<Card_Holder_Script>();
		}
	}

	public int Mana
	{
		get
		{
			return Effect_Script.AffectsList(myManaEffects, myManaValue, myManaValue, gameObject, gameObject);
		}
	}

	// Update is called once per frame
	void Update () 
	{
		mana = Mana;
	}

	public override int Affect(int initial, int input, GameObject inSubject, GameObject inObject)
	{
		Player_Script playerScript = myCardHolder.myOwner;

        Debug.Log("playerScript: " + playerScript);

		if(playerScript)
		{

			//get cost of card
			int manaCost = Mana;
			int playerMana = playerScript.mana;

			//if player has enough
			if (manaCost <= playerMana)
			{
                Player_Script ownerScript = null;
                Cells cell = null;

                if(inObject)
                {
                    ownerScript = inObject.GetComponent<Owner_Script>().myOwner;
                    cell = inObject.GetComponent<Cells>();
                }


                if (myMaskNegative.isOwned)
                {
                    if (playerScript == ownerScript)
                    {
                        Debug.Log("Target can't be owned by you.");
                        return 0;
                    }
                }

                if (myMaskPositive.isOwned)
                {
                    if (playerScript != ownerScript)
                    {
                        Debug.Log("Target must be owned by you.");
                        return 0;
                    }
                }


                if (cell)
                {
                    if (myMaskNegative.isOccupied)
                    {
                        if (cell.isOccupied)
                        {
                            Debug.Log("Target can't be occupied.");
                            return 0;
                        }
                    }

                    if (myMaskPositive.isOccupied)
                    {
                        if (false == cell.isOccupied)
                        {
                            Debug.Log("Target must be occupied.");
                            return 0;
                        }
                    }
                }

                Term_Effect_Script subtractionTerm = gameObject.AddComponent<Term_Effect_Script>();

                subtractionTerm.myTerm = -manaCost;

                //pay cost
                playerScript.myManaEffects = Effect_Script.Append(playerScript.myManaEffects, subtractionTerm);

                if (playerScript.myGraveyard)
                {
                    transform.parent = playerScript.myGraveyard.transform;
                    Debug.Log("Went into graveyard");
                }
                else
                {
                    Debug.Log("No graveyard for used card");
                }

                Effect_Script.AffectsList(myPlayEffects, initial, input, inSubject, inObject);
                return 1;
				
			}
			else
			{
				Debug.Log("Card: " + gameObject.name + " uses " + manaCost + " mana.");
			}
		}
		return 0;

	}

}
