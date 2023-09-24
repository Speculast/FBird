using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Game : MonoBehaviour
{
    public enum GAME_STATUS
    {
        Ready,
        Gameing,
        over
    }
    private GAME_STATUS status;

    public GAME_STATUS Status
    {
        get { return status; }
        set { status = value;
            UpdataUI();
        }
    }

    public GameObject Canvas;
    public GameObject PanelReady;
    public GameObject PanelInGame;
    public GameObject PanelGameOver;
    public Player player;
    public pipelineManager pipelineManager;
    public int score;

    public Text UiScoreGain;
    public Text UiScoreOver;


    public int Score
    {
        get{ return score; }
        set { 
            score = value;
            UiScoreGain.text=score.ToString();
            UiScoreOver.text=score.ToString();
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        PanelReady.SetActive(true);
        Status = GAME_STATUS.Ready;
        this.Canvas.SetActive(true);
        this.PanelReady.SetActive(true);
        this.PanelInGame.SetActive(false);
        this.PanelGameOver.SetActive(false);
        this.player.OnDeath += player_OnDeath;
        this.player.OnScore = OnPlayerScore;
    }
    void OnPlayerScore(int score)
    {
        Score += score;
    }

    private void player_OnDeath()
    {
        this.Status = GAME_STATUS.over;
        pipelineManager.Stop();
        
    }

    // Update is called once per frame
    

    public void GameStar()
    {
        this.Status = GAME_STATUS.Ready;
        //Debug.Log("ÓÎÏ·¿ªÊ¼");
        pipelineManager.StarRun();
        Debug.LogFormat("GameStar:{0}",this.Status);
        this.PanelReady.SetActive(false);
        player.Fly();
        PanelInGame.SetActive(true);
    }
    public void UpdataUI()
    {
        this.PanelReady.SetActive(this.Status == GAME_STATUS.Ready);
        this.PanelInGame.SetActive(this.Status ==GAME_STATUS.Gameing);
        this.PanelGameOver.SetActive(this.Status ==GAME_STATUS.over);
    }
    public void ReStar()
    {
        Status = GAME_STATUS.Ready;
        pipelineManager.Init();
        player.Init();
        ResetScore(0);

    }
    public void ResetScore(int score)
    {
        Score = 0;
        score = 0;
        UiScoreGain.text = score.ToString();
        UiScoreOver.text = score.ToString();
    }
}
