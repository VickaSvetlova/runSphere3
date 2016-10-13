using UnityEngine;
using System.Collections;

public class every_play : MonoBehaviour {

	// Use this for initialization
	void Start () {
        Everyplay.StartRecording();
        Invoke("stopRecorder", 2);
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    void stopRecorder() {
        Everyplay.StopRecording();
        Everyplay.PlayLastRecording();

        }
}
