using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public Text countText;
    public Text winText;
    public Text winText2;
    public Text timeText;

    public float totalTime;

    private Rigidbody rb;
    private int count;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        count = 8;
        SetCountText();
        winText.text = "";
        winText2.text = "";
        totalTime = 0;
        timeText.text = "";
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        rb.AddForce(movement*speed);
        rb.AddForce(-rb.velocity); //remove inertia

        totalTime += Time.deltaTime;
        timeText.text = "Current time: " + totalTime + "s";
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Pick Up"))
        {
            other.gameObject.SetActive(false);
            count = count - 1;
            SetCountText();
        }
    }

    void SetCountText()
    {
        countText.text = "Remaining: " + count.ToString();
        if(count <= 0){
            winText.text = "You won in " + totalTime + "s !!!";
            winText2.text = "You won in " + totalTime + "s !!!";
        }
    }
}