using UnityEngine;
using System.Collections;

public class Arrive : MonoBehaviour {

    // Use this for initialization
    void Start()
    {
        velocity_current = Vector3.forward;
    }
    [SerializeField]
    private Vector3 target;
    [SerializeField]
    private float MaxSpeed = 3;
    [SerializeField]
    private float MaxSteer = 3;

    [SerializeField]
    private float slow_radius = 3;

    private Vector3 velocity_current;

    void Awake()
    {
        target = transform.position;
    }
    // Update is called once per frame
    void Update()
    {
        Color debug_range;
        Vector3 position = transform.position;

        float distance = ((target - position).magnitude);
        if (distance < slow_radius)
        {
            velocity_current = velocity_current.normalized * MaxSpeed * (distance / slow_radius);
            debug_range = Color.red;
        }
        else
        {
            velocity_current = velocity_current.normalized * MaxSpeed;
            debug_range = Color.blue;
        }

        velocity_current = Vector3.RotateTowards(velocity_current, (target - position), (MaxSteer * Time.deltaTime), 0);

        Debug.DrawLine(position, position + velocity_current, debug_range);


        transform.position = (position + (velocity_current * Time.deltaTime));
    }
    public void changeTarget(Vector3 x)
    {
        target = x;
    }

}
