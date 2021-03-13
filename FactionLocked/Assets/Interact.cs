using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interact : MonoBehaviour
{

    bool inRange = false;
    public Behaviour halo;
    public GameObject canvas;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && inRange)
        {

            //instantiate new canvas prefab
            Debug.Log("User interacted with object");
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {

            inRange = true;
            halo.enabled = true;
            canvas.SetActive(true);

        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            inRange = false;
            halo.enabled = false;
            canvas.SetActive(false);
        }
    }
}
