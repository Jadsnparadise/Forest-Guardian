using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public int qntMamacos;
    public GameObject chamadorDeCenas;

    void Update()
    {
        if(qntMamacos == 0)
        {
            chamadorDeCenas.GetComponent<loadScene>().nextlevel();

        }
    }
}
