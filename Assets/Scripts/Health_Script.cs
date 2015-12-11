using UnityEngine;
using System.Collections;

public class Health_Script : Effect_Script {

	[SerializeField]
	private int myHealthValue, myDamageValue;

	[SerializeField]
	private Effect_Script[] myHealthEffects, myDamageEffects;

    public Canvas winConditionScreen;
    public Canvas loseConditionScreen;

    void Start()
    {
        if (gameObject.name == "Main Camera" || gameObject.name == "EnemyPlayer")
        {
            Debug.Log("Player: " + this.gameObject);
            winConditionScreen.enabled = false;
            loseConditionScreen.enabled = false;
        }
    }

    void OnGUI()
    {

        if (health - damage > 0)
        {
            Vector3 myScreenPosition = Camera.main.WorldToScreenPoint(this.transform.position);
            Vector2 GUIposition = new Vector2(myScreenPosition.x - 5f, Screen.height - myScreenPosition.y - 10f);
            GUI.Box(new Rect(GUIposition, new Vector2(25f, 20f)), (health - damage).ToString());
        }
    }

    public int currentHealth;
    public int currentMaxHealth;
    public int currentDamage;

    void Update()
    {
        Checkup();

        currentHealth = health - damage;
        currentMaxHealth = health;
        currentDamage = damage;
        if(gameObject.name == "Main Camera")
        {
            if (currentHealth < 19)
            {
                loseConditionScreen.enabled = true;
            }
        }
        else if (gameObject.name == "EnemyPlayer")
        {
            if (currentHealth < 19)
            {
                winConditionScreen.enabled = true;
            }

        }
    }


	public int health
	{
		get
		{
			return Effect_Script.AffectsList(myHealthEffects, myHealthValue, myHealthValue, gameObject, gameObject);
		}
	}

	public int damage
	{
		get
		{
			return Effect_Script.AffectsList(myDamageEffects, myDamageValue, myDamageValue, gameObject, gameObject);
		}
	}

	public bool isDamaged
	{
		get
		{
			return damage > 0;
		}
	}

	public override int Affect(int initial, int input, GameObject inSubject, GameObject inObject)
	{
		return health - damage;
	}

	public void Checkup ()
	{
		if(health <= damage)
		{
            //Debug.Log(gameObject.name + " has died!");
            if (gameObject.name != "EnemyPlayer" && gameObject.name != "Main Camera")
            {
                transform.parent = GetComponent<Owner_Script>().myOwner.myGraveyard.transform;  
                transform.localPosition = Vector3.zero;
            }
		}
	}

	public void ApplyDamage(int input)
	{
		Term_Effect_Script termDamage = gameObject.AddComponent<Term_Effect_Script>();

		termDamage.myTerm = input;

		myDamageEffects = Effect_Script.Append(myDamageEffects, termDamage);
	}

}
