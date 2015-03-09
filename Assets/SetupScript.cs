using UnityEngine;
using System.Collections;

public class SetupScript : MonoBehaviour {
    public Texture2D mouseTexture;

	// Use this for initialization
	void Start () {
	    Cursor.SetCursor(mouseTexture, Vector2.zero, CursorMode.Auto);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
