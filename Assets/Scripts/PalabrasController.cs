using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PalabrasController : MonoBehaviour {

    public List<string> palabrasCorazon;
    public List<string> palabrasCerebro;
    public List<AudioClip> palabrasCorazonAudio;
    public List<AudioClip> palabrasCerebroAudio;

    public List<AudioClip> palabrasCorazonAudio2;
    public List<AudioClip> palabrasCerebroAudio2;
    public InputField inputText;
    private AudioSource audioSource;

    private bool audio1;
    private bool isTurnoCorazon;
    private bool isError = false;
    private bool isCorazonError = false;
    private bool isPlayerRespond = true;
    private bool finalCorazon = false;
    private bool finalCerebro = false;
    private int palabraCorazonActual = 0;
    private int palabraCerebroActual = 0;
    private int aciertosCorazon = 0;
    private int aciertosCerebro = 0;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        isTurnoCorazon =Random.Range(0, 100) > 50;
        for (int i = 0; i < palabrasCerebro.Count; i++) {
            palabrasCerebro[i] = palabrasCerebro[i].ToUpper();
        }


        for (int i = 0; i < palabrasCorazon.Count; i++) {
            palabrasCorazon[i] = palabrasCorazon[i].ToUpper();
        }
        
        
    }

    private void Start()
    {
        activateTextbox();
    }

    // Update is called once per frame
    void Update() {

        if (finalCorazon && finalCerebro)
        {
            if (isError)
            {
                if (isCorazonError)
                {

                    SceneManager.LoadScene(2 );
                    //final del cerebro
                }
                else {
                    SceneManager.LoadScene(3 );
                    //final del corazon
                }
            }
            else {
                SceneManager.LoadScene( 4 );

                //final Equilibrado
            }
            return;
        }
        audio1=Random.Range(0, 100) > 50;
        if (isPlayerRespond) {

            isPlayerRespond = false;
            playAudio();
        }

        
    }

    public void onValueChangeListener(string text)
    {
        for(int i=0;i<10;i++)
            text = text.Replace(i.ToString(), " ");

        text =text.Split(' ')[0];
       
        this.inputText.text = text.ToUpper();
    }

    public void getTextListener(string inputText)
    {
        activateTextbox();
        if (isTurnoCorazon)
        {
            actualizarPalabraCorazon(inputText);
        }
        else {
           
            actualizarPalabraCerebro(inputText);
        }

        isTurnoCorazon = !isTurnoCorazon;
        isPlayerRespond = true;
    }

    private void actualizarPalabraCorazon(string inputText) {

        if (palabrasCorazon[palabraCorazonActual].Equals(inputText))
        {
            aciertosCorazon++;
        }
        else
        {
            if (!isError) { 
                isError = true;
                isCorazonError = true;
            }
        }
        
        palabraCorazonActual++;

        if (palabraCorazonActual >= palabrasCorazon.Count)
        {
            finalCorazon = true;
            palabraCorazonActual = palabrasCorazon.Count - 1;
        }
        if (palabraCorazonActual < 0)
            palabraCorazonActual = 0;
        


    }

    private void actualizarPalabraCerebro(string inputText) {

        if (palabrasCerebro[palabraCerebroActual].Equals(inputText))
        {
            aciertosCerebro++;
        }
        else
        {
            if (!isError)
            {
                isError = true;
                isCorazonError = false;
            }
        }
        palabraCerebroActual++;
        if (palabraCerebroActual > palabrasCerebro.Count - 1)
        {
            palabraCerebroActual = palabrasCerebro.Count - 1;
            finalCerebro = true;
        }
        if (palabraCerebroActual < 0)
            palabraCerebroActual = 0;


    }

    private void activateTextbox()
    {
        this.inputText.Select();
        this.inputText.ActivateInputField();
    }

    private void playAudio() {
        AudioClip audioClip;
        if (isTurnoCorazon)
        {
            if(audio1)
                audioClip=palabrasCorazonAudio[palabraCorazonActual];
            else
                audioClip = palabrasCorazonAudio2[palabraCorazonActual];
        }
        else
        {
            if (audio1)
                audioClip = palabrasCerebroAudio[palabraCerebroActual];
            else
                audioClip = palabrasCerebroAudio2[palabraCerebroActual];
        }
        audioSource.clip = audioClip;
        audioSource.Play();
    }
}
