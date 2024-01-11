using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class GameControler : MonoBehaviour
{
    [SerializeField] private float Timer = 2f;
    [SerializeField] private GameObject Obstaculo;
    [SerializeField] private Vector3 Position;

    [SerializeField] private float Max = 1.77f;
    [SerializeField] private float Min = -0.72f;

    [SerializeField] private float TimerMax= 3;
    [SerializeField] private float TimerMin= 1;

    private float Pontos;
    [SerializeField] private Text PontosText;

    private int Level = 1;
    [SerializeField] private Text LevelText;
    [SerializeField] private float PontosParaPassar = 10f;

    [SerializeField] private AudioClip levelUp;
    private Vector3 CameraPos;

    // Start is called before the first frame update
    void Start()
    {
        CameraPos = Camera.main.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        GanharPontos();

        SpawnDeObstaculos();

        Leveis();
    }

    private void GanharPontos()
    {
        Pontos += Time.deltaTime;
        PontosText.text = ("Pontos: " + Mathf.Round(Pontos).ToString());

        //Round arredonda numeros quebrados
        //Debug.Log(Mathf.Round(Pontos));
    }

    private void Leveis()
    {
        LevelText.text = Level.ToString();

        if (Pontos > PontosParaPassar)
        {
            AudioSource.PlayClipAtPoint(levelUp,CameraPos);
            Level += 1;
            PontosParaPassar *= 2;
        }
    }

    private void SpawnDeObstaculos()
    {
        Timer -= Time.deltaTime;
        if (Timer <= 0)
        {
            Timer = Random.Range(TimerMin / Level, TimerMax);

            Position.y = Random.Range(Min, Max);

            Instantiate(Obstaculo, Position, Quaternion.identity);
            Timer = Random.Range(TimerMin, TimerMax);
        }
    }

    public int RetornarLevel()
    {
        return Level;
    }
}
