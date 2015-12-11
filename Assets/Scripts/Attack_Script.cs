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
			return Effect_Script.AffectsList(myDamageEffects, myDamageValue, myDamageValue, gameObject, gameObject);
		}
	}

    void OnGUI()
    {
        if (damage > 0)
        {
            Vector3 myScreenPosition = Camera.main.WorldToScreenPoint(this.transform.position);
            Vector2 GUIposition = new Vector2(myScreenPosition.x - 30f, Screen.height - myScreenPosition.y - 10f);
            GUI.Box(new Rect(GUIposition, new Vector2(25f, 20f)), (damage).ToString());
        }
    }
}
