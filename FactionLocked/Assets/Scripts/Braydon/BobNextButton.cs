using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// makes the 'go to next text box' indicator bob up and down
public class BobNextButton : MonoBehaviour
{
    private float elapse = 0.0f; 
    private bool isUp = false;
    private Vector3 shiftAmount = new Vector3(0f,10f,0f);

    // Update is called once per frame
    void Update()
    {
        elapse += Time.deltaTime;
        if (elapse >= 0.5f) {
            if (isUp) {
                transform.position = transform.position - shiftAmount;
            } else {
                transform.position = transform.position + shiftAmount;
            } 
            isUp = !isUp;
            elapse = 0f;
        }
    }

}
