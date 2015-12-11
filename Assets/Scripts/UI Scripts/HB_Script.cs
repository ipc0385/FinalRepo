using UnityEngine;
using System.Collections;

public class HB_Script : MonoBehaviour
{

    public float max_health = 20f;
    public float cur_health = 0f;
    public GameObject healthBar;
    public GameObject MyCurrentHealth;
    public float myCurrHealth;
    // Use this for initialization
    void Start()
    {
        cur_health = max_health;
        InvokeRepeating("decreasehealth", 1f, 1f);

    }

    // Update is called once per frame
    void Update()
    {

    }

    void decreasehealth()
    {
        int intHealth = MyCurrentHealth.gameObject.GetComponent<Health_Script>().currentHealth;
        myCurrHealth = (float)intHealth;
        float inputHealth = myCurrHealth / max_health;
        GetCurrentHealth(inputHealth);
        

    }

    public void GetCurrentHealth(float myHealth)
    {
        healthBar.transform.localScale = new Vector3(myHealth, healthBar.transform.localScale.y, healthBar.transform.localScale.z);
    }
}
