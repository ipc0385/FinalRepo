using UnityEngine;
using System.Collections;

public class MoveUnits : MonoBehaviour {

    private MoveAnimate movement;


	// Use this for initialization
	void Start () {
        movement = gameObject.GetComponent<MoveAnimate>();
        Turn_Singleton_Script.Get.myEndingMessenger.Subscribe(new Subscription(gameObject, "Move"));
	}
	
	// Update is called once per frame
    //void Update () {
    //    if (Input.GetKeyDown(KeyCode.Space)) {
    //        Move();
    //    }
    //}

    public void Move()
    {

        if (transform.parent.GetComponent<Cells>().isEnd() == false)
        {
            //Unit = gameObject.GetComponent<UnitInfo>();
            int distance = gameObject.GetComponent<UnitInfo>().GetSpeed();

            if (distance > 0)
            {
                if (transform.parent.GetComponent<Cells>().ForwardExists(distance) == true)
                {
                    if (transform.parent.GetComponent<Cells>().GetForward(distance).GetComponent<Cells>().isOccupied == false)
                    {

                        // change parent
                        GameObject Destination = transform.parent.GetComponent<Cells>().GetForward(distance);
                        gameObject.transform.parent = Destination.transform;
                        // now actually make it move
                        movement.myAnim.AddClip(movement.MakeClip(1, Vector3.up.normalized * .35f), "moveUnit");
                        movement.myAnim.Play("moveUnit");
                        //transform.localPosition = Vector3.up.normalized*.35f;
                    }
                    else Debug.Log("Anouther Unit is Blocking the way of " + gameObject.name);
                }
                else Debug.Log(gameObject.name + " Cannot move forward");
            }
            else Debug.Log(gameObject.name + " is stationary");
        }
        else Debug.Log(gameObject.name + " has reached the end!");
    }
 
}
