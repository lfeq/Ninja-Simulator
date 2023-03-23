using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuToPlay : MonoBehaviour
{
    public void EscenaJuego()
    {
    SceneManager.LoadScene("Juego"); 
    }

    public void CargarCreditos()
    {
        SceneManager.LoadScene("Credits");
    }

    public void CargarMenu()
    {
        SceneManager.LoadScene("Menu");
    }

    public void CargarMenu2()
    {
        StartCoroutine(CambiarEscenaDespuesDeSEgundos());   
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    IEnumerator CambiarEscenaDespuesDeSEgundos()
    {
        yield return new WaitForSeconds(2);

        CargarMenu();
    }
}