using UnityEngine;
using System.Collections;

public class Moving : MonoBehaviour
{

    float speed = 3f;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        var move = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        transform.position += move * speed * Time.deltaTime;
    }

    void FixedUpdate()
    {

    }
}
