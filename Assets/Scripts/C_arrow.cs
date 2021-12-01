using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;

public class C_arrow : MonoBehaviour
{
    //public GameObject bowarrowprefab;
    Animator g_bowarroeanimator;
    public static int throwflag, pull, release,load,ispaused;
    //public Rigidbody g_rigidarrow;
    //public float arrowspeed;
    public Text yourturn, opponentturn;


    public static float starttime, loadtime, pulltime, releasetime;
    void Start()
    {
        g_bowarroeanimator = this.GetComponent<Animator>();
        //g_rigidarrow = GetComponent<Rigidbody>();
        g_bowarroeanimator.SetBool("isIdle", false);
        g_bowarroeanimator.SetBool("isload", false);
        g_bowarroeanimator.SetBool("isPull", false);
        g_bowarroeanimator.SetBool("isRelease", false);
        starttime = Time.time;
        throwflag = 0;
        //ispaused = (int)PhotonNetwork.LocalPlayer.CustomProperties["Paused"];
        



    }

    // Update is called once per frame
    void Update()
    {
        m_throwarrow();
        m_isload();
        m_ispull();
        m_isrelease();
        //m_isyourturn();
        //m_vanisharrow();
        //test_arrow();
    }

    void m_throwarrow()
    {
        //print("throw entered");
        if(release==1 && Time.time-releasetime>=0.8)
        {
            //g_BulletsScriptArray[i].g_RigitBody.AddForce(Vector3.forward * g_BulletSpeed, ForceMode.VelocityChange)
            //print("throw entered");
            //this.g_rigidarrow.AddForce(Vector3.forward * arrowspeed, ForceMode.VelocityChange);
            g_bowarroeanimator.SetBool("isRelease", false);
            pull = 0;
            throwflag = 1;
            release = 0;
            load = 0;
            this.gameObject.SetActive(false);

        }
    }

    public void m_isload()
    {
        //print("load entered");
        if (throwflag==0  && C_uimanager.loadflag==1 && load==0 )
        {
            yourturn.enabled = false;
            print("load entered");
            g_bowarroeanimator.SetBool("isIdle", false);
            g_bowarroeanimator.SetBool("isload", true);
            loadtime = Time.time;
            pull = 0;
            release = 0;
            load = 1;
            C_uimanager.loadflag = 0;

            //g_uimanagerload.SetActive(false);

        }
    }

    void m_ispull()
    {
        //print("pull entered");
        if (loadtime!=0 && Time.time-loadtime>=1 && load==1)
        {
            print("pull entered");
            g_bowarroeanimator.SetBool("isload", false);
            g_bowarroeanimator.SetBool("isPull", true);
            pulltime = Time.time;
            pull = 1;
            load = 0;
            release = 0;
            //print("pull elapsed" + (Time.time - pulltime));
        }
    }

    void m_isrelease()
    {
        //print("release entered");
        if (release==1 && releasetime!=0 )
        {
            print("release entered");
            g_bowarroeanimator.SetBool("isPull", false);
            g_bowarroeanimator.SetBool("isRelease", true);

            pull = 0;
            load = 0;


            //releasetime = Time.time;
            
            
        }
    }

    void m_isyourturn()
    {
        if(ispaused==0)
        {
            yourturn.enabled = true;
            opponentturn.enabled = false;
            m_isload();
        }
        else
        {
            yourturn.enabled = false;
            opponentturn.enabled = true;
        }
    }









}
