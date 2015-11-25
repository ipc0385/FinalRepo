using UnityEngine;
using System.Collections;

public class FindAndGetCellsTest : MonoBehaviour {
    
    private Cells test;

	// Use this for initialization
	void Start () {
        test = gameObject.GetComponent<Cells>();
	}
	
	// Update is called once per frame
	void Update () {
        if (test.UpExists(1) == false) Debug.Log(gameObject.name + " UP Does not Exist");
        if (test.DownExists(1)==false) Debug.Log(gameObject.name + " DOWN Does not Exist");
        if (test.ForwardExists(1)==false) Debug.Log(gameObject.name + " FORWARD Does not Exist");
        if (test.BackExists(1)==false) Debug.Log(gameObject.name + " BACK Does not Exist");
	}
}
