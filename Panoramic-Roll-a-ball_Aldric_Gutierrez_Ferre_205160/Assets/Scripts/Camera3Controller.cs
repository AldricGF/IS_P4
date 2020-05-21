using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera3Controller : MonoBehaviour
{
	public GameObject player;
	private Vector3 offset;

    // Start is called before the first frame update
    void Start()
    {
        offset = transform.position - player.transform.position + 0f*Vector3.right;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        transform.position = player.transform.position + offset;
    }
}
