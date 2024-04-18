using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Temporal : MonoBehaviour
{
    public Transform point1;
    public Transform point2;
    void Start()
    {
        Vector3 vector3 = (point2.position - point1.position).normalized;
        Debug.Log(vector3);
    }
}
