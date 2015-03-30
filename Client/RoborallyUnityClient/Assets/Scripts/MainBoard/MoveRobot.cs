using UnityEngine;
using System.Collections;

public class MoveRobot : MonoBehaviour {

	public void MoveForvard()
    {
        var currentPosition = gameObject.transform.position;
        currentPosition.z++;
        gameObject.transform.position = currentPosition;
    }
}
