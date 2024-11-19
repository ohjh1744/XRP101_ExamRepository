using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeController : MonoBehaviour
{
    //set private Á¦°Å.
    public Vector3 SetPoint { get;  set; }

    public void SetPosition()
    {
        transform.position = SetPoint;
    }
}
