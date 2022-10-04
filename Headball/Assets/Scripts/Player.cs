using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private CharacterController controle;
    private Vector3 playerVelocidade;
    private bool playerNoChao;
    private float playerVelocidadeMovimento = 2.0f;
    private float alturaPulo = 1.0f;
    private float gravidade = -9.8f;
    private Vector3 movimento;

    public Vector3 getPlayerVelocidade()
    {
        return this.playerVelocidade;
    }

    public bool getPlayerNochao()
    {
        return this.playerNoChao;
    }

    public float getPlayerVelocidadeMovimento()
    {
        return this.playerVelocidadeMovimento;
    }

    public Vector3 getMovimento()
    {
        return this.movimento;
    }
    // Start is called before the first frame update
    void Start()
    {
        controle = gameObject.AddComponent<CharacterController>();

    }

    // Update is called once per frame
    void Update()
    {
        playerNoChao = controle.isGrounded;
        if(playerNoChao && playerVelocidade.y < 0)
        {
            playerVelocidade.y = 0;
        }

        movimento = new Vector3(Input.GetAxis("Horizontal"), 0, 0);
        controle.Move(movimento * Time.deltaTime * playerVelocidadeMovimento);
        
        if(movimento != Vector3.zero)
        {
            gameObject.transform.forward = movimento;
        }
        pular();
        playerVelocidade.y += gravidade * Time.deltaTime;
        controle.Move(playerVelocidade * Time.deltaTime);
        endireitar();
    }

    private void pular()
    {
        if(Input.GetButtonDown("Jump") && playerNoChao)
        {
            playerVelocidade.y = Mathf.Sqrt(alturaPulo * -3.0f * gravidade);
        }
    }

    private void endireitar()
    {
        gameObject.transform.rotation = new Quaternion(0,0,0,0);
    }


}
