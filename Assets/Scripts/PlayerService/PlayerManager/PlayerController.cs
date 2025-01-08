
using System;
using UnityEngine;

public class PlayerController
{
    private PlayerView playerView;
    private bool isDead;
    public bool IsDead {  get { return isDead; } }
    public PlayerController(PlayerView playerView)
    {
        this.playerView = playerView;
        this.playerView.SetController(this);
    }

    public void OnGameStart()
    {
        SetPlayerAliveStatus(true);
    }


    public void SetPlayerDirection(Vector3 mouseWorldPos)
    {
        Vector3 direction=(mouseWorldPos-playerView.transform.position).normalized;
        playerView.GetPlayerAnimator().SetFloat("x", direction.x);
        playerView.GetPlayerAnimator().SetFloat ("y", direction.y);
    }

    public void SetPlayerAliveStatus(bool isAlive)
    {
        if(isAlive)
        {
            isDead=false;
            
        }
        else
        {
            isDead = true;
        }
        playerView.GetPlayerAnimator().SetBool("isDead", isDead);
    }

}
