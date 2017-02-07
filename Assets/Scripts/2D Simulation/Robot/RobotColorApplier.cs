using UnityEngine;

public class RobotColorApplier : MonoBehaviour {

    public GameObject bigCircle;
    public GameObject smallCircle;

    public void ApplyColor(RobotColor color) {
        bigCircle.GetComponent<SpriteRenderer>().color = color.teamColor;
        smallCircle.GetComponent<SpriteRenderer>().color = color.idColor;
    }
}
