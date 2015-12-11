using UnityEngine;
using System.Collections;

public class CombatTurn : MonoBehaviour {

    
    private Attack_Script UnitAttack;
    private Health_Script UnitHealth;
    private Owner_Script UnitOwner;


    private Cells UnitLocation;

    private GameObject enemyUnit;
    //private Attack_Script EnemyAttack;
    private Health_Script EnemyHealth;
    private Owner_Script InRangeOwner;

    [SerializeField]
    private int range = 1;

    [SerializeField]
    private string AttackDirection;



	// Use this for initialization
	void Start () {
        UnitOwner = gameObject.GetComponent<Owner_Script>();
        UnitAttack = gameObject.GetComponent<Attack_Script>();
        UnitHealth = gameObject.GetComponent<Health_Script>();
        UnitLocation = gameObject.GetComponentInParent<Cells>();
        UnitOwner.myOwner.myTurnState.myCombatMessenger.Subscribe(new Subscription(gameObject, AttackDirection));
	}
	
	// Update is called once per frame
	void Update () 
	{
        //UnitLocation = gameObject.GetComponentInParent<Cells>();
        
	}

    void AttackFriendly()
    {
        UnitLocation = gameObject.GetComponentInParent<Cells>();

        for (int i = range; i > 0; i--)
        {
            Debug.Log(gameObject.name +": Attacking " + i + " tiles ahead");
            if (transform.parent.GetComponent<Cells>().isEnd() == false || transform.parent.GetComponent<Cells>().isEnd() == UnitOwner.myOwner)
            {
                
                if (UnitLocation.ForwardExists(i) == true)
                {
                    Cells TilesInRange = UnitLocation.GetForward(i).GetComponent<Cells>();
                    if (TilesInRange.isOccupied)
                    {
                        GameObject enemyObject = TilesInRange.transform.GetChild(0).gameObject;

                        InRangeOwner = enemyObject.GetComponent<Owner_Script>();
                        if (InRangeOwner.myOwner != UnitOwner.myOwner)
                        {
                            //Debug.Log("hi ian: " + InRangeOwner.myOwner + ", " + UnitOwner.myOwner);
                            //Debug.Log(gameObject + " - has delt damage to - " + enemyObject);
                            EnemyHealth = enemyObject.GetComponent<Health_Script>();
                            EnemyHealth.ApplyDamage(UnitAttack.damage);
                        }
                    }
                }
            }
            else
            {
                InRangeOwner = transform.parent.GetComponent<Owner_Script>();
                if (InRangeOwner.myOwner != UnitOwner.myOwner)
                {
                    //Debug.Log(gameObject.name + " has reached the end!");
                    EnemyHealth = InRangeOwner.myOwner.GetComponent<Health_Script>();
                    EnemyHealth.ApplyDamage(1);
                    UnitHealth.ApplyDamage(9001);
                    i = 0;
                }
            }
        }
    }
        

	void AttackEnemy()
	{
        	UnitLocation = gameObject.GetComponentInParent<Cells>();

        	for (int i = range; i > 0; i--)
		{
        		Cells cell = transform.parent.GetComponent<Cells>();

       			if (cell && cell.isEnd() == false)
       			{
            			Debug.Log(gameObject.name +": Attacking " + i + " tiles ahead");
            			if (transform.parent.GetComponent<Cells>().isEnd() == false || transform.parent.GetComponent<Cells>().isEnd() == UnitOwner.myOwner)
            			{
                
                			if (UnitLocation.BackExists(i) == true)
                			{
                    				Cells TilesInRange = UnitLocation.GetBack(i).GetComponent<Cells>();
                    				if (TilesInRange.isOccupied)
                    				{
                        				GameObject enemyObject = TilesInRange.transform.GetChild(0).gameObject;

                        				InRangeOwner = enemyObject.GetComponent<Owner_Script>();
                        				if (InRangeOwner.myOwner != UnitOwner.myOwner)
                        				{
                            					//Debug.Log("hi ian: " + InRangeOwner.myOwner + ", " + UnitOwner.myOwner);
                            					//Debug.Log(gameObject + " - has delt damage to - " + enemyObject);
                            					EnemyHealth = enemyObject.GetComponent<Health_Script>();
                            					EnemyHealth.ApplyDamage(UnitAttack.damage);
                        				}
                    				}
                			}
            			}
        		}
        		else
        		{
          	 		InRangeOwner = transform.parent.GetComponent<Owner_Script>();
          	 		if (InRangeOwner && InRangeOwner.myOwner != UnitOwner.myOwner)
            			{
                			InRangeOwner = transform.parent.GetComponent<Owner_Script>();
                			if (InRangeOwner.myOwner != UnitOwner.myOwner)
                			{
                    				//Debug.Log(gameObject.name + " has reached the end!");
                    				EnemyHealth = InRangeOwner.myOwner.GetComponent<Health_Script>();
                    				EnemyHealth.ApplyDamage(1);
                    				UnitHealth.ApplyDamage(9001);
                    				i = 0;
                			}
            			}
        		}
    		}
	}
}
