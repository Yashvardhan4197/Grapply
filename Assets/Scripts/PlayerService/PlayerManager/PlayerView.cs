
using System;
using UnityEngine;

public class PlayerView : MonoBehaviour
{

    private PlayerController playerController;
    [SerializeField] Animator playerAnimator;
    public void SetController(PlayerController playerController)
    {
        this.playerController = playerController;
    }

    private void Update()
    {
        if(playerController?.IsDead==false)
        {
            Vector3 mousePos= Input.mousePosition;
            Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(new Vector3(mousePos.x, mousePos.y, 0));
            playerController?.SetPlayerDirection(mouseWorldPos);

        }
    }

    public Animator GetPlayerAnimator() => playerAnimator;


}
