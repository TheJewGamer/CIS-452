using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class evacArrow : MonoBehaviour
{
    public Transform evacZone;

    // Update is called once per frame
    void LateUpdate()
    {
        //look at evac zone
        this.transform.right = (evacZone.transform.position - transform.position);
    }
}
