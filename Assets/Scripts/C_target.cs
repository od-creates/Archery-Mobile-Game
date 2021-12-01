using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class C_target : MonoBehaviour
{

    public static float collisiontime;
    // Start is called before the first frame update
    void Start()
    {
        collisiontime = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.tag == "arrow")
        {
            //print("collision");
            collisiontime = Time.time;
            collision.gameObject.GetComponent<Rigidbody>().isKinematic = true;
        }



        //collisioncount++;

        /*
        if(collisioncount>=2)
        {
            collisiontime = Time.time;
            collisioncount = 0;
        }

        */





    }

}
