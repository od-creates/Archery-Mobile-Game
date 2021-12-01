using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Photon.Pun;

public class C_uimanager : MonoBehaviour
{

    public static int startgamecount,setcount,loadflag,score1,score2;
    public GameObject shootagain, loadaim,scoreboard1,scoreboard2,gameover,winner,loser,home,quitbutton,finalscore;
    public Text scoretext1,scoretext2,scoretext;

    public int chances;
    C_bowarrow cbj;

    void Start()
    {
        //startgamecount = 0;
        //setcount = 1;
        loadflag = 0;
        shootagain.SetActive(false);
        loadaim.SetActive(true);
        scoreboard1.SetActive(true);
        scoreboard2.SetActive(true);
        gameover.SetActive(false);
        winner.SetActive(false);
        loser.SetActive(false);
        home.SetActive(false);
        quitbutton.SetActive(false);
        finalscore.SetActive(false);
        //cbj.chance = chances;
        

        
    }

    void Update()
    {
        m_updatescore();
        //cbj.chance = chances;
    }
    
    
    public void m_startgame()
    {
        
        startgamecount++;
        if(startgamecount<=chances)
        {
            if(score1+(chances-startgamecount)<4)
            {
                loser.SetActive(true);
                gameover.SetActive(true);

                home.SetActive(true);
                quitbutton.SetActive(true);
                shootagain.SetActive(false);
                scoreboard1.SetActive(false);
                scoreboard2.SetActive(false);
                finalscore.SetActive(true);
                scoretext.text = "" + score1;
                startgamecount = 0;
                score1 = 0;
                score2 = 0;
            }
            else
            {
                SceneManager.LoadScene("MainGame");
            }
            
            
        }
        else 
        {
            //game over

            print("player1:" + PhotonNetwork.LocalPlayer.CustomProperties["score1"]);
            print("player2:" + PhotonNetwork.LocalPlayer.CustomProperties["score2"]);


            gameover.SetActive(true);
            
            home.SetActive(true);
            quitbutton.SetActive(true);
            shootagain.SetActive(false);
            scoreboard1.SetActive(false);
            scoreboard2.SetActive(false);
            finalscore.SetActive(true);
            scoretext.text = "" + score1;

            if(score1>=5)
            {
                winner.SetActive(true);
            }
            else
            {
                loser.SetActive(true);
            }

            startgamecount = 0;
            score1 = 0;
            score2 = 0;

        }

        


    }

    public void m_quit()
    {
        Application.Quit();
    }

    public void m_load()
    {
        loadflag = 1;
        loadaim.SetActive(false);
    }

    void m_updatescore()
    {
        if(SceneManager.GetActiveScene()==SceneManager.GetSceneByName("MainGame"))
        {
            scoretext1.text = "" + score1;
            scoretext2.text = "" + (chances-startgamecount+1);
            //print(chances - startgamecount + 1);
        }
        
    }

    public void m_callLobby()
    {
        
        SceneManager.LoadScene("Lobby");
    }

    public void m_home()
    {
        //PhotonNetwork.Disconnect();
        SceneManager.LoadScene("StartGame");
    }

    public void m_maingame()
    {
        SceneManager.LoadScene("MainGame");
    }

    public void m_howtoplay()
    {
        SceneManager.LoadScene("howtoplay");
    }

    
    
}
