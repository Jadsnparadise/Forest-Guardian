using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPrincipalManager1 : MonoBehaviour
{
    [SerializeField] private string nomeDoLevelDeJogo;
    [SerializeField] private GameObject MenuInicial;
    [SerializeField] private GameObject ajuda;


    public void Jogar()
    {

        SceneManager.LoadScene(nomeDoLevelDeJogo);

    }

    public void AabrirAjuda()
    {
        MenuInicial.SetActive(false);
        ajuda.SetActive(true);


    }

    public void FecharAjuda()
    {
        ajuda.SetActive(false);
        MenuInicial.SetActive(true);

    }

    public void SairJogo()
    {
        Debug.Log("SAIR");
        Application.Quit();



    }

}
