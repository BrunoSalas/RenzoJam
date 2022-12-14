using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public GameObject game;
    public GameObject menu;
    public GameObject instruciones;
    public GameObject instruciones1;
    public GameObject instruciones2;
    public GameObject player;
    public GameObject pierde;
    public GameObject creditos;
    public GameObject txt;
    public GameObject boton;
    public GameObject soundOff;
    public GameObject banner;
    public coin coin;
    public AudioSource audioSource;
    public AudioClip audio;
    private bool sound;
    public GameObject cam;
    public Animator animator;
    bool ranki;

    private void Start()
    {
    }

    private void FixedUpdate()
    {
        if (player.GetComponent<Player>().perder && !ranki)
        {
            pierde.SetActive(true);
            game.SetActive(false);
            txt.SetActive(true);
            boton.SetActive(true);
            banner.SetActive(false); 
            soundOff.SetActive(false);
        }
    }
    public void Tutorial()
    {
        audioSource.PlayOneShot(audio);
        cam.GetComponent<Animator>().enabled = false;
        cam.GetComponent<Cameras>().enabled = true;
        menu.SetActive(false);
        instruciones.SetActive(true);
    }
    public void Tuto2()
    {
        audioSource.PlayOneShot(audio);
        instruciones1.SetActive(false);
        instruciones2.SetActive(true);
    }
    public void Inicio()
    {
        audioSource.PlayOneShot(audio);
        instruciones.SetActive(false);
        player.GetComponent<Player>().init = true;
        player.GetComponent<Player>().velocity = 0.7f;
        game.SetActive(true);
    }
    public void Creditos()
    {
        banner.SetActive(false);
        audioSource.PlayOneShot(audio);
        menu.SetActive(false);
        creditos.SetActive(true);

    }

    public void Salir()
    {
        audioSource.PlayOneShot(audio);
        Application.Quit();
        coin.puntuaje = 0;
    }
    public void SceneChange(string sceneName)
    {
        audioSource.PlayOneShot(audio);
        SceneManager.LoadScene(sceneName);
    }

    public void SoundSfx()
    {
        sound = !sound;
        if (sound)
        {
            Debug.Log("SI");
            soundOff.SetActive(true);
            audioSource.PlayOneShot(audio);
            cam.GetComponent<Camera>().GetComponent<AudioListener>().enabled = false;
        }
        else
        {
            Debug.Log("NO");
            soundOff.SetActive(false);
            audioSource.PlayOneShot(audio);
            cam.GetComponent<Camera>().GetComponent<AudioListener>().enabled = true;
        }
    }
}
