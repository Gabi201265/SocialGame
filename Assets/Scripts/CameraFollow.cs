using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public BoxCollider2D areaBox;
    private float halfWidth, halfHeight;

    Camera mycam;
    // Start is called before the first frame update
    void Start()
    {
        mycam = GetComponent<Camera>();
        mycam.orthographicSize = (Screen.height / 100f);
        halfHeight = mycam.orthographicSize;
        halfWidth = mycam.orthographicSize * mycam.aspect;
    }

    // Update is called once per frame
    void Update()
    {
        if (target)
        {
            transform.position = Vector3.Lerp(target.position, target.position,0.1f)+new Vector3(0,0,-15);
            transform.position = new Vector3(Mathf.Clamp(transform.position.x, areaBox.bounds.min.x + halfWidth, areaBox.bounds.max.x - halfWidth), Mathf.Clamp(transform.position.y, areaBox.bounds.min.y + halfHeight, areaBox.bounds.max.y - halfHeight),-15);        
        }
    }
}
