using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerControler : MonoBehaviour
{
    //movimentacao
    private Rigidbody2D Rb;
    [SerializeField] private float Speed;

    //limitador de tela
    [SerializeField] private float MaxY = 5f;
    [SerializeField] private float MinY = -5f;

    //Efeito de animacao
    [SerializeField] private GameObject particle;

    // Start is called before the first frame update
    void Start()
    {
        //Acessar componente de RigidBody
        Rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //movimentacao do player
        MoveControler();

        //limitador de velocidade de queda
        LimitadorDeVelocidade();

        //limita o espaco para q o player nao saia
        LimitadorAltura();

    }

    private void LimitadorDeVelocidade()
    {
        if (Rb.velocity.y < -Speed)
        {
            Rb.velocity = Vector2.down * Speed;
        }
    }

    private void MoveControler()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Rb.velocity = Vector2.up * Speed;

            GameObject pufControler = Instantiate(particle, transform.position, Quaternion.identity);

            Destroy(pufControler, 1f);
        }
    }

    private void LimitadorAltura()
    {
        if (transform.position.y > MaxY || transform.position.y < MinY)
        {
            SceneManager.LoadScene(0);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        SceneManager.LoadScene(0); 
    }
}
