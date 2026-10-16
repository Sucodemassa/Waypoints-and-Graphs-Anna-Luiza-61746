using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowWP : MonoBehaviour
{
    public GameObject[] waipoints;
    int currentWP = 0;

    public float speed = 10.0f;
    public float rotSpeed = 10.0f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(this.transform.position, waipoints[currentWP].transform.position) < 3)
            currentWP++;

        if (currentWP >= waipoints.Length)
            currentWP = 0;

       // this.transform.LookAt(waipoints[currentWP].transform);

        Quaternion lookatWP = Quaternion.LookRotation(waipoints[currentWP].transform.position - this.transform.position);

        this.transform.rotation = Quaternion.Slerp(transform.rotation, lookatWP, rotSpeed * Time.deltaTime);
        this.transform.Translate(0,0,speed * Time.deltaTime);
    }
}
