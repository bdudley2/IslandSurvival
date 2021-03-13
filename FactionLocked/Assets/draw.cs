using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class draw : MonoBehaviour
{

    public GameObject square;
    public GameObject circle;
    public GameObject PathParent;
    float speed = 0.05f;
    private Vector2 screenBounds;
    float dx;
    float dy;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
         dx = Input.GetAxis("Horizontal") * speed;
         dy = Input.GetAxis("Vertical") * speed;
        circle.transform.Translate(dx, dy, 0.0f);
        Vector3 clampedPos = circle.transform.position;
        clampedPos.x = Mathf.Clamp(clampedPos.x, -1.13f, 1.13f);
        clampedPos.y = Mathf.Clamp(clampedPos.y, 2.25f, 3.35f);
        circle.transform.position = clampedPos;
        if (dx != 0.0f || dy != 0.0f)
        {
            Transform squarePart = Instantiate(square.transform, circle.transform.position, circle.transform.rotation);
            squarePart.SetParent(PathParent.transform);
        }
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "body")
        {
            dx = 0;
            dy = 0;
        }
    }
}
