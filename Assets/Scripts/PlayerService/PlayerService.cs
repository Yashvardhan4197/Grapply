using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerService : MonoBehaviour
{
    private PlayerController playerController;
    [SerializeField] PlayerView playerView;

    //change later
    private void Start()
    {
        Init();
    }

    public void Init()
    {
        playerController = new PlayerController(playerView);
    }

    public PlayerController GetPlayerController() => playerController;

}
