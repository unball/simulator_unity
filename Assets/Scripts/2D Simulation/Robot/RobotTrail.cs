using System;
using System.Collections.Generic;
using UnityEngine;

public class RobotTrail : MonoBehaviour {

    public GameObject trailPrefab;
    public GameObject trailContainer;
    public GameObject smallCircle;

    private int maxAmount;
    private float trailPeriod;

    private float elapsedTime;

    private Queue<GameObject> trailQueue = new Queue<GameObject>();

    void Start() {
        // 0 is the value for "No" on the config menu's trail dropdown
        bool leaveTrail = PlayerPrefs.GetInt("TrailDropdown") == 0 ? false : true;
        if (!leaveTrail)
            gameObject.SetActive(false);
        else
            SetupTrail();
    }

    void Update() {
        elapsedTime += Time.deltaTime;
        if (elapsedTime >= trailPeriod) {
            GenerateTrailUnit();
            elapsedTime = 0;
        }
    }

    private void SetupTrail() {
        float trailTime = Convert.ToSingle(PlayerPrefs.GetString("TrailTime"));
        trailPeriod = 1f / Convert.ToSingle(PlayerPrefs.GetString("TrailFrequency"));
        maxAmount = (int)(trailTime / trailPeriod);
    }

    private void GenerateTrailUnit() {
        if (trailQueue.Count == maxAmount)
            Destroy(trailQueue.Dequeue());
        var newTrailUnit = Instantiate(trailPrefab);
        newTrailUnit.transform.parent = trailContainer.transform;
        newTrailUnit.transform.position = transform.position;
        newTrailUnit.transform.rotation = transform.rotation;
        newTrailUnit.GetComponent<SpriteRenderer>().color = smallCircle.GetComponent<SpriteRenderer>().color;
        trailQueue.Enqueue(newTrailUnit);
    }
}
