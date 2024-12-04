using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindmillRotate : MonoBehaviour
{
    private Vector3 aVector;
    public float spinSpeed = 50f;
    public float spinX = 0f;
    public float spinY = 0f;
    public float spinZ = 1f;
    // Start is called before the first frame update
    void Start()
    {
        aVector = new Vector3(spinX, spinY, spinZ);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(aVector * spinSpeed * Time.deltaTime);
    }
}
