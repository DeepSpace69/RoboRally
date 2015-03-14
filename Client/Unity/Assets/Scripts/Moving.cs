using UnityEngine;
using System.Collections;

public class Moving : MonoBehaviour
{
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //var move = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        if (Input.GetKeyDown(KeyCode.A))
        {
            var position = transform.position;
            position.x--;
            transform.position = position;
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            var position = transform.position;
            position.z--;
            transform.position = position;
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            var position = transform.position;
            position.x++;
            transform.position = position;
        }

        if (Input.GetKeyDown(KeyCode.W))
        {
            var position = transform.position;
            position.z++;
            transform.position = position;
        }
    }

    void FixedUpdate()
    {

    }
}
