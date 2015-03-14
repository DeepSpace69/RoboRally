using UnityEngine;
using System.Collections;

public class BoardBuilder : MonoBehaviour
{
    public GameObject plate;

    // Use this for initialization
    void Start()
    {
        for (int y = 0; y < 5; y++)
        {
            for (int x = 0; x < 5; x++)
            {
                Instantiate(plate, new Vector3(x, 0, y), Quaternion.identity);
            }
        }
    }
}
