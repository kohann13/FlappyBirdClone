using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGroundControler : MonoBehaviour
{
    private Renderer MeuRender;

    private float XOffSet;

    private Vector2 TextureOffSet;

    [SerializeField] private float Speed = 0.1f;

    // Start is called before the first frame update
    void Start()
    {
        MeuRender = GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        //Parallax
        XOffSet += speed * Time.deltaTime;

        TextureOffSet.x = XOffSet;
        
        MeuRender.material.mainTextureOffset = TextureOffSet;
    }
}
