using UnityEngine;
using UnityEngine.UI;

public class FieldSidePublisher : MonoBehaviour {

    private Dropdown fieldDropdown;
    private ROSPublisher publisher;

    public void UpdateFieldSide() {
        /* This conditional prevents the Dropdown component from calling  */
        if (Time.timeSinceLevelLoad > 0.1f) {
            JSONObject fieldMessage = new JSONObject(JSONObject.Type.OBJECT);
            fieldMessage.AddField("data", fieldDropdown.options[fieldDropdown.value].text);
            publisher.PublishMessage(fieldMessage);
        }
    }

    void Start () {
        fieldDropdown = GetComponent<Dropdown>();
        publisher = GetComponent<ROSPublisher>();
        Invoke("UpdateFieldSide", 0.2f);
    }
}
