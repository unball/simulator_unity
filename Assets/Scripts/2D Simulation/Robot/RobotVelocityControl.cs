using UnityEngine;

public class RobotVelocityControl : MonoBehaviour {

    public float linearVelocity;
    public float angularVelocity;

    private Rigidbody2D rigidBody;
    private bool check_pause;

    void Start() {
        if (SimulationDataRetriever.instance.simulationMode == SimulationMode.GUI) {
            this.enabled = false;
            GetComponent<Collider2D>().enabled = false;
        }
        rigidBody = GetComponent<Rigidbody2D>();
        check_pause = SimulationDataRetriever.instance.pauseMode == PauseMode.FORCE_STOP;
    }

    void FixedUpdate() {
        if (check_pause && Pause.instance.isPaused) {
            ApplyLinearVelocity(0f);
            ApplyAngularVelocity(0f);
        }
        else {
            ApplyLinearVelocity(linearVelocity);
            ApplyAngularVelocity(angularVelocity);
        }
    }

    private void ApplyLinearVelocity(float velocity) {
        rigidBody.velocity = rigidBody.transform.right * velocity;
    }

    private void ApplyAngularVelocity(float velocity) {
        rigidBody.angularVelocity = velocity;
    }
}
