using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class GameManaguer : MonoBehaviour
{
    public coin puntuaje;
    public int costeVelocidad;
    public int costeInvulnerable;
    public int costeRomper;
    [HideInInspector]
    public GameObject moneda;
    [HideInInspector]
    public GameObject moneda2;
    [HideInInspector]
    public GameObject textInvul;
    [HideInInspector]
    public GameObject textDestru;
    [HideInInspector]
    public GameObject textVelo;
    public Player player;
    public Button ButtonInvul;
    public Button ButtonVelo;
    public Button ButtonDestru;
    public static GameManaguer gameManaguer;

    private void Start()
    {
        puntuaje.puntuaje = 0;
        Application.targetFrameRate = 120;
        gameManaguer = this;

        GameObject[] objs = GameObject.FindGameObjectsWithTag("Cerebro");
        player.SlowParticle.Stop();
        player.invulnerableParticle.Stop();

    }



// Update is called once per frame
    void Update()
    {
        if (textVelo == null)
        {
            textVelo = GameObject.FindGameObjectWithTag("TextVelo");
        }
        else
        {
            textVelo.GetComponent<Text>().text = costeVelocidad.ToString();
        }
        if (textDestru == null)
        {
            textDestru = GameObject.FindGameObjectWithTag("TextoDestru");
        }
        else
        {
            textDestru.GetComponent<Text>().text = costeRomper.ToString();
        }
        if (textInvul == null)
        {
            textInvul = GameObject.FindGameObjectWithTag("TextInvul");
        }
        else
        {
            textInvul.GetComponent<Text>().text = costeInvulnerable.ToString();
        }
        if (player.perder == false)
        {
            if (moneda == null)
            {
                moneda = GameObject.FindGameObjectWithTag("Text");
            }
            moneda.GetComponent<Text>().text = puntuaje.puntuaje.ToString();
        }
        if (player.perder == true)
        {
            if (moneda2 == null)
            {
                moneda2 = GameObject.FindGameObjectWithTag("2");
            }
            moneda2.GetComponent<Text>().text = Player.metros.ToString() + "  " + "M";
        }
        if (puntuaje.puntuaje < costeVelocidad)
        {
            ButtonVelo.enabled = false;
        }
        else
        {
            ButtonVelo.enabled = true;
        }
        if (puntuaje.puntuaje < costeInvulnerable)
        {
            ButtonInvul.enabled = false;
        }
        else
        {
            ButtonInvul.enabled = true;
        }
        if (puntuaje.puntuaje < costeRomper)
        {
            ButtonDestru.enabled = false;
        }
        else
        {
            ButtonDestru.enabled = true;
        }
    }


    public void Velocidad()
    {
        if (puntuaje.puntuaje >= costeVelocidad)
        {
            player.SlowParticle.Play(true);
            player.audioSource.PlayOneShot(player.velocidadSound);
            player.velocity = 0.7f;
            player.x = 0.2f;
            player.velocityCould = true;
            puntuaje.puntuaje -= costeVelocidad;
            costeVelocidad += costeVelocidad;
        }
    }
    public void Invulnerable()
    {
        if (puntuaje.puntuaje >= costeInvulnerable)
        {
            player.invulnerableParticle.Play(true);
            player.audioSource.PlayOneShot(player.invulnerableSound);
            player.invulnerable = true;
            player.rb.isKinematic = true;
            puntuaje.puntuaje -= costeInvulnerable;
            costeInvulnerable += costeInvulnerable;
        }
    }
    public void Romper()
    {
        if (puntuaje.puntuaje >= costeRomper)
        {
            player.colliderDestruir = true;
            player.DestruirParticle.SetActive(true);
            puntuaje.puntuaje -= costeRomper;
            costeInvulnerable += costeRomper;
        }
    }
}
