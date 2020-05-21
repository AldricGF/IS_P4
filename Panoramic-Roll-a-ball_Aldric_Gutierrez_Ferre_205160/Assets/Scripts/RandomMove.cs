using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomMove : MonoBehaviour
{
    public float speed2;

    private float totalTime2;

    private float moveHorizontal;
    private float moveVertical;

    private Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();

        totalTime2 = 0;

        moveHorizontal = Random.Range(-1.0f, 1.0f);
        moveVertical = Random.Range(-1.0f, 1.0f);
    }

    // Update is called once per frame
    void FixedUpdate()
    {

    	if(totalTime2 > 0.5){
    		totalTime2 = 0;
    		moveHorizontal = Random.Range(-1.0f, 1.0f);
        	moveVertical = Random.Range(-1.0f, 1.0f);

    	}

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        rb.AddForce(movement*speed2);
        rb.AddForce(-rb.velocity*5); //remove inertia

        totalTime2 += Time.deltaTime;
    }
}
