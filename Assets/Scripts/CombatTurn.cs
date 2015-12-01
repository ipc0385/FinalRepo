using UnityEngine;
using System.Collections;

public class CombatTurn : MonoBehaviour {

    
    private Attack_Script UnitAttack;
    private Health_Script UnitHealth;

    private Cells UnitLocation;
    private Cells TilesInRange;

    private GameObject enemyUnit;
    //private Attack_Script EnemyAttack;
    private Health_Script EnemyHealth;

    [SerializeField]
    private int range = 1;

	// Use this for initialization
	void Start () {
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
                TilesInRange = UnitLocation.GetForward(range).GetComponent<Cells>();
                if (TilesInRange.isOccupied)
                {
                    EnemyHealth = TilesInRange.GetComponentInChildren<Health_Script>();
                    EnemyHealth.ApplyDamage(UnitAttack.damage);
                }
            }
        }
        else 
        {
            //Debug.Log(gameObject.name + " has reached the end!");
            EnemyHealth = GameObject.Find("EnemyPlayer").GetComponent<Health_Script>();
            EnemyHealth.ApplyDamage(1);
            UnitHealth.ApplyDamage(9001);
        }
    }
}
