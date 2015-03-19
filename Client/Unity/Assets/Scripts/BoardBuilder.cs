using UnityEngine;
using System.Collections;

public class BoardBuilder : MonoBehaviour
{
    public GameObject plate;
    public GameObject wall;

    // Use this for initialization
    void Awake()
    {
        for (int y = -5; y < 6; y++)
        {
            for (int x = -5; x < 6; x++)
            {
                if (x == 5 || x == -5 || y == 5 || y == -5)
                {
                    Instantiate(wall, new Vector3(x, 0.5f, y), Quaternion.identity);

                }
                else
                {
                    Instantiate(plate, new Vector3(x, 0, y), Quaternion.identity);

                }
            }
        }
    }
}
