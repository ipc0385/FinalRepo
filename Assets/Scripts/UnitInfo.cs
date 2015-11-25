using UnityEngine;
using System.Collections;

public class UnitInfo : MonoBehaviour {

    [SerializeField]
    private int MoveSpeed = 1;

    [SerializeField]
    private int MoveDelay = 0;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    public int GetSpeed() {
        return MoveSpeed;
    }

    public int GetDelay()
    {
        return MoveDelay;
    }

}
