using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstaculoControler : MonoBehaviour
{
    [SerializeField]private float Speed;
    [SerializeField] private GameObject Obstaculo;
    [SerializeField] private GameControler game;


    // Start is called before the first frame update
    void Start()
    {
        //destroi apos sair da dela
        Destroy(Eu, 4f);
        game = FindObjectOfType<GameControler>();

       
    }

    // Update is called once per frame
    void Update()
    {
        //verifica o nivel para almentar a velocidade
        Speed = 4 + game.RetornarLevel();

        //move na direcao do player
        transform.position += Vector3.left * Time.deltaTime * Speed;
    }
}
