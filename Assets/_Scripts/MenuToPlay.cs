using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuToPlay : MonoBehaviour
{

    public void EscenaJuego()
{
    SceneManager.LoadScene("Juego"); 
}

 public void CargarCreditos (string nombreEscena)
 {

    SceneManager.LoadScene("Creditos");

 }

}

