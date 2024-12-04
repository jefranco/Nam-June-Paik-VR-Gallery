using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Maskscript : MonoBehaviour
{
    public void Start()
    {
        GetComponent<MeshRenderer>().material.renderQueue = 3002;
    }
}
