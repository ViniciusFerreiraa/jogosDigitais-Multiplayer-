using UnityEngine;
using System.Collections;

public class DestroyEffect : MonoBehaviour {

	// Use this for initialization
	void Start () {
        Invoke("DestroyTime", 2);
	}

    void DestroyTime()
    {
        Destroy(this.gameObject);
    }
}
