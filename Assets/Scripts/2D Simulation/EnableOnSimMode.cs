using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableOnSimMode : MonoBehaviour {

	public SimulationMode enableOnMode;

    void Start () {
        if (SimulationDataRetriever.instance.simulationMode != enableOnMode)
            gameObject.SetActive(false);
    }
}
