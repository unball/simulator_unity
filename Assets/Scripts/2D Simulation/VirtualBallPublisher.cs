using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VirtualBallPublisher : MonoBehaviour {

	private ROSPublisher publisher;

	void Start() {
		publisher = GetComponent<ROSPublisher>();
		if (SimulationDataRetriever.instance.simulationMode != SimulationMode.GUI)
			this.enabled = false;
		if (SimulationDataRetriever.instance.ballBehaviour != BallGUIBehaviour.VIRTUAL)
			this.enabled = false;
	}

	void Update() {
		Vector2 ball = Ball.instance.transform.position;
		JSONObject ballPosMsg = new JSONObject(JSONObject.Type.OBJECT);
		ballPosMsg.AddField("x", ball.x * 0.1f);
		ballPosMsg.AddField("y", ball.y * 0.1f);
		ballPosMsg.AddField("z", 0);
		if (Time.timeSinceLevelLoad > 0.1f) {
			publisher.PublishMessage(ballPosMsg);
			if (publisher.error != null)
				Debug.LogError(publisher.error);
		}
	}
}
