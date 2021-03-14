using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class draw : MonoBehaviour
{

    public GameObject square;
    public GameObject circle;
    public GameObject PathParent;
    public float speed = 0.05f;
    float dx;
    float dy;
    public Stack<int> directions;
    private List<Transform> path;
    private bool goingBackwards = false;


    // Start is called before the first frame update
    void Start()
    {
        path = new List<Transform>();
        directions = new Stack<int>();
    }

    // Update is called once per frames
    void Update()
    {
        dx = Input.GetAxisRaw("Horizontal");
        dy = Input.GetAxisRaw("Vertical");
        Debug.Log(dx);
        if (dx != 0 && dy != 0 )
        {
            return;
        }
        if (dx > 0)
        {
            if (directions.Count > 0 && directions.Peek() == 3)
            {
                //going backwards
                Debug.Log("Going back");
                goingBackwards = true;
                directions.Pop();
                Destroy(path[path.Count - 1].gameObject);
                path.RemoveAt(path.Count - 1);
            } else
            {
                directions.Push(1);
                Debug.Log("Going forth");

                goingBackwards = false;
            }
        }
        if (dx < 0)
        {
            if (directions.Count > 0 && directions.Peek() == 1)
            {
                //going backwards
                Debug.Log("Going back");
                goingBackwards = true;
                directions.Pop();
                Destroy(path[path.Count - 1].gameObject);
                path.RemoveAt(path.Count - 1);
            } else
            {
                directions.Push(3);
                Debug.Log("Going forth");

                goingBackwards = false;

            }
        }
        if (dy > 0)
        {
            if (directions.Count > 0 && directions.Peek() == 2)
            {
                //going backwards
                Debug.Log("Going back");
                goingBackwards = true;
                directions.Pop();
                Destroy(path[path.Count - 1].gameObject);
                path.RemoveAt(path.Count - 1);
            } else
            {
                directions.Push(0);
                Debug.Log("Going forth");

                goingBackwards = false; 
            }
        }
        if (dy < 0)
        {
            if (directions.Count > 0 && directions.Peek() == 0)
            {
                //going backwards
                Debug.Log("Going back");
                goingBackwards = true;
                directions.Pop();
                Destroy(path[path.Count - 1].gameObject);
                path.RemoveAt(path.Count - 1);
            } else
            {
                directions.Push(2);
                Debug.Log("Going forth");

                goingBackwards = false;
            }
        }
        dx = dx * speed;
        dy = dy * speed;
        circle.transform.Translate(dx, dy, 0.0f);
      //  Vector3 clampedPos = circle.transform.position;
     //   clampedPos.x = Mathf.Clamp(clampedPos.x, -1.13f, 1.13f);
    //    clampedPos.y = Mathf.Clamp(clampedPos.y, 2.25f, 3.35f);
   //     circle.transform.position = clampedPos;
        if ((dx != 0.0f || dy != 0.0f) && !goingBackwards)
        {
            Transform squarePart = Instantiate(square.transform, circle.transform.position, circle.transform.rotation);
            squarePart.SetParent(PathParent.transform);
            path.Add(squarePart);
        }
    }

}
