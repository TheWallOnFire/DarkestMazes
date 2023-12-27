using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Compass : MonoBehaviour
{
    public GameObject goal;
    public float damping;
    // var lookPos = target.position - transform.position;
    // lookPos.y = 0;
    // var rotation = Quaternion.LookRotation(lookPos);
    // transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * damping);
    private void Update() 
    {
        Vector3 lookPos = goal.GetComponent<Transform>().position - this.GetComponent<Transform>().position;
        this.GetComponent<Transform>().rotation = Quaternion.Slerp(this.GetComponent<Transform>().rotation, this.GetComponent<Transform>().rotation, Time.deltaTime * damping);
    }
}
