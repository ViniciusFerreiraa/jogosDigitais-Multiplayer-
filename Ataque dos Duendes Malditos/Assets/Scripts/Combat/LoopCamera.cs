using UnityEngine;
using System.Collections;

public class LoopCamera : MonoBehaviour {
    public Transform target;
    public GameObject[] LoopPoints;
    public float loopTime, smoothTime;
    private Vector3 velocity = Vector3.zero;
    private int loopCount, maxLoop;
	// Use this for initialization
	void Start () {
        Invoke("CameraLoop", 1);
	}
	
	// Update is called once per frame
	void Update () {
        transform.LookAt(target);
        transform.position = Vector3.SmoothDamp(transform.position, LoopPoints[loopCount].transform.position, ref velocity, smoothTime);
       // transform.position = Vector3.Lerp(transform.position, LoopPoints[loopCount].transform.position, Speed);
	}

    void CameraLoop()
    {
        maxLoop = LoopPoints.Length;
        if (loopCount < maxLoop-1)
        {
            loopCount++;
        }
        else
        {
            loopCount = 0;
        }
        Invoke("CameraLoop", loopTime);
    }
}
