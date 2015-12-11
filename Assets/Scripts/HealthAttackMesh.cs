using UnityEngine;
using System.Collections;

public class HealthAttackMesh : MonoBehaviour {

    public Health_Script health;
    [SerializeField]
    private TextMesh field;
	
	// Update is called once per frame
	void Update () {
        transform.LookAt(Camera.main.transform);
        
        field.text = (health.health - health.damage) + "/" + health.health;

	}
}
