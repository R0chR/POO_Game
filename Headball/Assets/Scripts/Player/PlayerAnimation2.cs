using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation2 : MonoBehaviour
{
    Animator animator;
    GameObject goPlayer;
    GameObject playerEsq;
    Player2 sPlayer;
    // Start is called before the first frame update
    void Start()
    {
        goPlayer = GameObject.Find("TrooperDir");
        animator = goPlayer.GetComponent<Animator>();
        playerEsq = GameObject.Find("JogadorDir");
        sPlayer = playerEsq.GetComponent<Player2>();
    }

    // Update is called once per frame
    void Update()
    {
        animacaoPulo();
        corrida();
    }

    public void animacaoPulo()
    {
        if (sPlayer.getPlayerNochao())
        {
            animator.SetBool("noChao", true);

        }
        else
        {
            animator.SetBool("noChao", false);
        }
    }

    public void corrida()
    {
        if (sPlayer.getHAxis() == 1)
        {
            animator.SetInteger("MovimentoEixo", -1);
        }
        else if (sPlayer.getHAxis() == -1)
        {
            animator.SetInteger("MovimentoEixo", 1);
        }
        else
            animator.SetInteger("MovimentoEixo", 0);
    }
}