using UnityEngine;
using System.Collections;

public class MoveAnimate : MonoBehaviour {
	
	// Update is called once per frame
	void Update () {
	
	}

    public Animation myAnim;
    public AnimationClip MakeClip(float inDuration, Vector3 inLocalPosition)
    {
        AnimationClip outClip = new AnimationClip();

        outClip.legacy = true;

        outClip.SetCurve("", typeof(Transform), "localPosition.x", AnimationCurve.Linear(0, transform.localPosition.x, inDuration, inLocalPosition.x));
        outClip.SetCurve("", typeof(Transform), "localPosition.y", AnimationCurve.Linear(0, transform.localPosition.y, inDuration, inLocalPosition.y));
        outClip.SetCurve("", typeof(Transform), "localPosition.z", AnimationCurve.Linear(0, transform.localPosition.z, inDuration, inLocalPosition.z));

        return outClip;
    }

    void Start()
    {
    }

}
