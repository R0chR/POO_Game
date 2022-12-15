using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimations : MonoBehaviour
{
    Animator animator;
    GameObject goPlayer;
    GameObject playerEsq;
    Player sPlayer;
    // Start is called before the first frame update
    void Start()
    {
        goPlayer = GameObject.Find("TrooperEsq");
        animator = goPlayer.GetComponent<Animator>();
        playerEsq = GameObject.Find("JogadorEsq");
        sPlayer = playerEsq.GetComponent<Player>();
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
        if(Input.GetAxis("Horizontal") == -1)
        {
            animator.SetInteger("MovimentoEixo", -1);
        }
        else if(Input.GetAxis("Horizontal") == 1)
        {
            animator.SetInteger("MovimentoEixo", 1);
        }
        else
            animator.SetInteger("MovimentoEixo", 0);
    }
}
