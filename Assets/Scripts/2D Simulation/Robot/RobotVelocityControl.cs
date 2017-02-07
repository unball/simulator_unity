using UnityEngine;

public class RobotVelocityControl : MonoBehaviour {

    public float linearVelocity;
    public float angularVelocity;

    private Rigidbody2D rigidBody;

    void Awake() {
        rigidBody = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate() {
        ApplyLinearVelocity(Pause.instance.isPaused ? 0 : linearVelocity);
        ApplyAngularVelocity(Pause.instance.isPaused ? 0 : angularVelocity);
    }

    private void ApplyLinearVelocity(float velocity) {
        rigidBody.velocity = rigidBody.transform.right * velocity;
    }

    private void ApplyAngularVelocity(float velocity) {
        rigidBody.angularVelocity = velocity;
    }
}
