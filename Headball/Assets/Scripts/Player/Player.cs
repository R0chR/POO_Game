using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private CharacterController controle;
    private Vector3 playerVelocidade;
    [SerializeField]
    private bool playerNoChao;
    private float playerVelocidadeMovimento = 2.0f;
    private float alturaPulo = 1.0f;
    private float gravidade = -9.8f;
    private Vector3 movimento;
    private float alturaPlayer;
    [SerializeField]
    private float aceleracao = 2.0f;


    public void setPlayerVelocidadeMovimento(float playerVelocidadeMovimento)
    {
        this.playerVelocidadeMovimento = playerVelocidadeMovimento;
    }
    public bool getPlayerNoChao()
    {
        return playerNoChao;
    }
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

    public float getAceleracao()
    {
        return this.aceleracao;
    }

    public void setAceleracao(float aceleracao)
    {
        this.aceleracao = aceleracao;
    }

    // Start is called before the first frame update
    void Start()
    {
        controle = gameObject.AddComponent<CharacterController>();
        alturaPlayer = this.transform.localScale.y;
        //gols = 0;
    }

    // Update is called once per frame
    void Update()
    {
        playerMoves();   
    }

    private void pular()
    {
        if(Input.GetButtonDown("Jump") && playerNoChao)
        {
            playerVelocidade.y = Mathf.Sqrt(alturaPulo * -5.0f * gravidade);
        }
    }

    private void endireitar()
    {
        gameObject.transform.rotation = new Quaternion(0,0,0,0);
        gameObject.transform.position = new Vector3(this.transform.position.x, transform.position.y, 0);
        /*if (playerNoChao)
        {
            transform.position = new Vector3(transform.position.x, transform.localScale.y/2, transform.position.z);
        }*/
    }

    public void acelerar()
    {
        if(Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.LeftArrow))
        {
            if(getAceleracao() < 10f)
            {
                this.setAceleracao( 0.2f + getAceleracao());
            }
        }
        if(Input.GetKeyUp(KeyCode.RightArrow) || Input.GetKeyUp(KeyCode.LeftArrow))
        {
            this.setAceleracao(2);
        }
    }

    public void playerMoves()
    {
        playerNoChao = controle.isGrounded;
        if (playerNoChao && playerVelocidade.y < 0)
        {
            playerVelocidade.y = 0;
        }
        acelerar();
        movimento = new Vector3(Input.GetAxis("Horizontal"), 0, 0);
        controle.Move(movimento * Time.deltaTime * aceleracao);

        if (movimento != Vector3.zero)
        {
            gameObject.transform.forward = movimento;
        }
        pular();
        playerVelocidade.y += gravidade * Time.deltaTime;
        controle.Move(playerVelocidade * Time.deltaTime);
        endireitar();
    }
}
