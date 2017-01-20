using UnityEngine;
using System.Collections;

public class Cube_Be_Control : MonoBehaviour
{

    private float speed = 1.0f;
	
	// Update is called once per frame
	void Update ()
	{
	    transform.Rotate( Vector3.up, Time.deltaTime * speed);
	}

    public void ChangeSpeed(float newSpeed)
    {
        Debug.Log(newSpeed);
        speed = newSpeed;
    }
}
