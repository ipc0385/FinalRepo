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

	// Use this for initialization
	void Start () {
        UnitOwner = gameObject.GetComponent<Owner_Script>();
        UnitAttack = gameObject.GetComponent<Attack_Script>();
        UnitHealth = gameObject.GetComponent<Health_Script>();
        UnitLocation = gameObject.GetComponentInParent<Cells>();
        Turn_Singleton_Script.Get.myEndingMessenger.Subscribe(new Subscription(gameObject,"DealDamage"));
        
	}
	
	// Update is called once per frame
	void Update () {
        //UnitLocation = gameObject.GetComponentInParent<Cells>();
        
	}

    void DealDamage(){
        UnitLocation = gameObject.GetComponentInParent<Cells>();
        
        if (transform.parent.GetComponent<Cells>().isEnd() == false)
        {
            if (UnitLocation.ForwardExists(range) == true)
            {
                Cells TilesInRange = UnitLocation.GetForward(range).GetComponent<Cells>();
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
            }
        }
    }

    //void EnemyDealDamage()
    //{
    //    UnitLocation = gameObject.GetComponentInParent<Cells>();

    //    if (transform.parent.GetComponent<Cells>().isEnd() == false)
    //    {
    //        if (UnitLocation.BackExists(range) == true)
    //        {
    //            TilesInRange = UnitLocation.GetBack(range).GetComponent<Cells>();
    //            if (TilesInRange.isOccupied)
    //            {
    //                InRangeOwner = TilesInRange.GetComponentInChildren<Owner_Script>();
    //                if (InRangeOwner.myOwner != UnitOwner.myOwner)
    //                {
    //                    EnemyHealth = TilesInRange.GetComponentInChildren<Health_Script>();
    //                    EnemyHealth.ApplyDamage(UnitAttack.damage);
    //                }
    //            }
    //        }
    //    }
    //    else
    //    {
    //        InRangeOwner = transform.parent.GetComponent<Owner_Script>();
    //        if (InRangeOwner.myOwner != UnitOwner.myOwner)
    //        {
    //            //Debug.Log(gameObject.name + " has reached the end!");
    //            EnemyHealth = GameObject.Find("Main Camera").GetComponent<Health_Script>();
    //            EnemyHealth.ApplyDamage(1);
    //            UnitHealth.ApplyDamage(9001);
    //        }
    //    }
    //}
}
