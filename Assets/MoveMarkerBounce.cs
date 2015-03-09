using UnityEngine;
using System.Collections;

public class MoveMarkerBounce : MonoBehaviour {
    public double lifetime = 0.5;
    private double lived = 0;
    public float velocity = 5.0f;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	    lived += Time.deltaTime;

        if (lived > lifetime) { 
            DestroyImmediate(this.gameObject);
            return; 
        }


        transform.Translate(Vector3.up * this.velocity * Time.deltaTime);
	}
}
