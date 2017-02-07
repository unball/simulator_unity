using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotLookAtPoint : MonoBehaviour {

    public void LookAt(Vector2 point) {
        var orientationVector = (point - (Vector2)transform.position).normalized;
        float angle = Mathf.Atan2(orientationVector.y, orientationVector.x) * Mathf.Rad2Deg;
        GetComponent<Rigidbody2D>().MoveRotation(angle);
    }
}
