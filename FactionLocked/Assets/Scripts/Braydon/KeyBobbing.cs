using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class KeyBobbing : MonoBehaviour
{
    private float overallTime = 0.0f;
    private float bobFactor = 0.0f;

    public float bobSpeed = 1.7f;
    public float bobHeightScale = 2f;
    public float rotationSpeed = 60.0f;


    // Start is called before the first frame update
    void Start()
    {
        overallTime += Random.Range(0.0f, 10.0f);
    }

    // Update is called once per frame
    void Update()
    {
        overallTime += Time.deltaTime;
        
        // bobbing
        bobFactor = Mathf.Sin(overallTime * bobSpeed) * this.transform.localScale.y * (bobHeightScale * 0.01f);
        this.transform.Translate(0, bobFactor, 0, Space.World);

        // rotation
        float finalRotSpeed = rotationSpeed * Time.deltaTime;
        this.transform.Rotate(0, finalRotSpeed, 0, Space.World);
    }
}
