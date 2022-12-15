using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2 : MonoBehaviour
{
    private CharacterController controle;
    private Vector3 playerVelocidade;
    [SerializeField]
    private bool playerNoChao;
    private float playerVelocidadeMovimento = 2.0f;
    private float alturaPulo = 1.0f;
    private float gravidade = -9.8f;
    [SerializeField]
    private Vector3 movimento;
    private float alturaPlayer;
    [SerializeField]
    private float aceleracao = 2.0f;
    private int hAxis = 0;

    public void setPlayerVelocidadeMovimento(float playerVelocidadeMovimento)
    {
        this.playerVelocidadeMovimento = playerVelocidadeMovimento;
    }
    public int getHAxis()
    {
        return hAxis;
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
        this.controle = gameObject.AddComponent<CharacterController>();
        this.alturaPlayer = this.transform.localScale.y;
    }

    // Update is called once per frame
    void Update()
    {
        endireitar();
        playerMoves();
        pular();
        acelerar();
    }

    private void pular()
    {
        if (Input.GetKey(KeyCode.I) && playerNoChao)
        {
            playerVelocidade.y = Mathf.Sqrt(alturaPulo * -5.0f * gravidade);
        }
    }

    private void endireitar()
    {
        this.gameObject.transform.rotation = new Quaternion(0, 0, 0, 0);
        this.gameObject.transform.position = new Vector3(this.transform.position.x, transform.position.y, 0);
        /*if (playerNoChao)
        {
            transform.position = new Vector3(transform.position.x, transform.localScale.y/2, transform.position.z);
        }*/
    }

    public void acelerar()
    {
        if (Input.GetKey(KeyCode.J) || Input.GetKey(KeyCode.L))
        {
            if (getAceleracao() < 10f)
            {
                this.setAceleracao(0.2f + getAceleracao());
            }
        }
        if (Input.GetKeyUp(KeyCode.J) || Input.GetKeyUp(KeyCode.L))
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
        if (Input.GetKey(KeyCode.J))
        {
            hAxis = -1;
        }
        else if (Input.GetKey(KeyCode.L))
        {
            hAxis = 1;
        }
        else
            hAxis = 0;
        this.movimento = new Vector3(hAxis, 0, 0);
        controle.Move(movimento * Time.deltaTime * aceleracao);

        if (movimento != Vector3.zero)
        {
            //gameObject.transform.forward = movimento;
        }
        
        playerVelocidade.y += gravidade * Time.deltaTime;
        controle.Move(playerVelocidade * Time.deltaTime);
        
    }
}