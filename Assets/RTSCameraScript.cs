using UnityEngine;

public class RTSCameraScript : MonoBehaviour {
    private readonly double scrollMargin = 0.1;
    private readonly float scrollSpeed = 15f;
    // Use this for initialization
    private void Start() {
    }

    // Update is called once per frame
    private void Update() {
        if (Input.mousePosition.x >= Screen.width * (1 - scrollMargin)) {
            transform.Translate(Vector3.right * Time.deltaTime * scrollSpeed, Space.World);
        }
        else if (Input.mousePosition.x <= Screen.width * (scrollMargin)) {
            transform.Translate(Vector3.left * Time.deltaTime * scrollSpeed, Space.World);
        }

        if (Input.mousePosition.y <= Screen.height * (scrollMargin)) {
            transform.Translate(Vector3.back * Time.deltaTime * scrollSpeed, Space.World);
        }
        else if (Input.mousePosition.y >= Screen.height * (1 - scrollMargin)) {
            transform.Translate(Vector3.forward * Time.deltaTime * scrollSpeed, Space.World);
        }
    }
}