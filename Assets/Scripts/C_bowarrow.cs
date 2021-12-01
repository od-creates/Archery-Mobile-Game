using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.UI;
using Hashtable = ExitGames.Client.Photon.Hashtable;

public class C_bowarrow : MonoBehaviour
{

    //public GameObject g_bowarrow;


    private PhotonView view;
    public GameObject arrow_prefab, arrow2, followcam, maincam, uiobject, shootagain,player;
    
    GameObject arrowcopy;
    public float arrowspeed;
    public static int flag,turn,pausedplayer,score1bak,score2bak;
    int aim;
    Vector3  rotatedirection,rotateeulerangle;
    public int chance;

    //public static Hashtable hashturn1 = new Hashtable();
    //public static Hashtable hashturn2 = new Hashtable();

    // Start is called before the first frame update
    void Start()
    {

        //starttime = Time.time;
  
        m_createarrow();
        maincam.GetComponent<Camera>().fieldOfView = 60.0f;
        uiobject.SetActive(false);
        maincam.transform.position = new Vector3(Random.Range(-1.3f, 1.3f),0,0);
        aim = 0;
        //turn =turn*(-1);
        //followcam.SetActive(false);
        
    }

    // Update is called once per frame
    void Update()
    {
        m_throwarrow();
        m_followarrow();
        m_playerrotate();
        m_stoptime();
        //print(C_uimanager.startgamecount);
        //m_taketurns();

        //print(arrow2.transform.position+"GG"+arrow2.transform.rotation+"GG"+arrow2.transform.localScale);

    }





    void m_throwarrow()
    {


        if (C_arrow.pull==1 && Time.time-C_arrow.pulltime>=2)
        {

            uiobject.SetActive(true);

            maincam.GetComponent<Camera>().fieldOfView = 40.0f;
            aim = 1;
            if(Input.GetMouseButtonUp(0))
            {


                uiobject.SetActive(false);
                maincam.GetComponent<Camera>().fieldOfView = 60.0f;
                C_arrow.releasetime = Time.time;
                C_arrow.release = 1;
                aim = 0;
                

            }


            


        }
        
        
        
    }

    void m_createarrow()
    {

        arrowcopy = Instantiate(arrow_prefab);
        arrowcopy.SetActive(false);
        flag = 0;

    }

    void m_followarrow()
    {
        if (C_arrow.throwflag == 1 && flag==0)
        {
            arrowcopy.SetActive(true);
            arrowcopy.transform.position = maincam.transform.position;
            arrowcopy.transform.rotation = arrow2.transform.rotation;
            arrowcopy.transform.localScale = arrow2.transform.localScale;


            arrowcopy.GetComponent<Rigidbody>().velocity = maincam.transform.forward*arrowspeed;


            flag = 1;
        }

        if(flag == 1)
        { 
            maincam.GetComponent<Camera>().fieldOfView = 50.0f;
            maincam.transform.position = arrowcopy.transform.Find("cam").position;
            maincam.transform.rotation = arrowcopy.transform.Find("cam").rotation;

        }


    }

    void m_playerrotate()
    {


        if(Input.GetMouseButton(0) && aim==1)
        {
            rotatedirection.x = -Input.GetAxis("Mouse Y");

            maincam.transform.Rotate(rotatedirection *20*  Time.deltaTime);

            rotateeulerangle.x = maincam.transform.localEulerAngles.x;

            if (rotateeulerangle.x > 250 && rotateeulerangle.x < 350)
            {
                rotateeulerangle.x = 350;
            }

            if (rotateeulerangle.x > 10 && rotateeulerangle.x < 60)
            {
                rotateeulerangle.x = 10;
            }

            maincam.transform.localEulerAngles = rotateeulerangle;

            rotatedirection = Vector3.zero;

            rotatedirection.y = Input.GetAxis("Mouse X");
            
            player.transform.Rotate(rotatedirection * 20 * Time.deltaTime, Space.Self);
        }
        

    }

    void m_stoptime()
    {
        if(C_target.collisiontime != 0 )
        {
            //print("collision");
            arrowcopy.GetComponent<Rigidbody>().isKinematic = true;

            //if(C_uimanager.startgamecount<= chance)
            //{
             ///   shootagain.SetActive(false);
              //  C_uimanager.startgamecount = 0;
          //  }
           // else 

          //  {
                shootagain.SetActive(true);
           // }



            C_uimanager.score1++;//for singleplayer

            /*

            Hashtable hash = new Hashtable();
            
            
            if(PhotonNetwork.LocalPlayer==PhotonNetwork.CurrentRoom.GetPlayer(1))
            {
                C_uimanager.score1++;
                score1bak = C_uimanager.score1;
                hash.Add("score1", score1bak);
                PhotonNetwork.CurrentRoom.GetPlayer(1).SetCustomProperties(hash);

            }
            if(PhotonNetwork.LocalPlayer == PhotonNetwork.CurrentRoom.GetPlayer(2))
            {
                C_uimanager.score2++;
                score2bak = C_uimanager.score2;
                hash.Add("score2", score2bak);
                PhotonNetwork.CurrentRoom.GetPlayer(2).SetCustomProperties(hash);
            }
            //print("score is "+C_uimanager.score);

            */

            C_target.collisiontime = 0;
        }

        if(arrowcopy.transform.position.z > 11)
        {
            //print("noncollision");
            arrowcopy.GetComponent<Rigidbody>().isKinematic = true;
            //if(C_uimanager.startgamecount> chance)
            //{
            //    shootagain.SetActive(false);
             //   C_uimanager.startgamecount = 0;
            //}
          //  else 

            //{
                shootagain.SetActive(true);
          //  }
        }

        

        
    }

    /*
    public void m_taketurns()
    {
        if(C_createandjoinrooms.ismultiplayer==1)
        {

            var firstplayer = PhotonNetwork.CurrentRoom.GetPlayer(1);
            var secondplayer= PhotonNetwork.CurrentRoom.GetPlayer(2);

            hashturn1 = new Hashtable();
            hashturn2 = new Hashtable();

            /*
            int KillScore = (int)PhotonNetwork.player.customProperties["Kills"];
            killScore++;
            Hashtable hash = new Hashtable();
            hash.Add("Kills", killScore);
            PhotonNetwork.player.SetCustomProperties(hash);
            *
            if (turn == 0)
            {
                turn = 1;
            }
                //Hashtable hashturn1 = new Hashtable();
                //Hashtable hashturn2 = new Hashtable();
                //turn = (int)firstplayer.CustomProperties["TurnNumber"];
                //turn = (int)secondplayer.CustomProperties["TurnNumber"];
                
                //hashturn1.Add("PlayerID", 1);
                //hashturn2.Add("PlayerID", 2);
               

                //pausedplayer= (int)firstplayer.CustomProperties["Paused"];
                //pausedplayer = (int)secondplayer.CustomProperties["Paused"];
                //pausedplayer = 2;

            if(turn==1)
            {
                hashturn1.Add("Paused", 0);
                hashturn2.Add("Paused", 1);
                firstplayer.SetCustomProperties(hashturn1);
                secondplayer.SetCustomProperties(hashturn2);
                
                
            }
               


            
            if(turn==-1)
            {
                hashturn1.Add("Paused", 1);
                hashturn2.Add("Paused", 0);
                firstplayer.SetCustomProperties(hashturn1);
                secondplayer.SetCustomProperties(hashturn2);
            }
            



        }

        
    }
            */


        }
