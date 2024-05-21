using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Player player;
    public GameObject startButton;
    public Canvas showCredits;
    public Canvas showTeam;
    public Canvas showSettings;
    public GameObject hexaAstrum;
    public GameObject credits;
    public GameObject settings;
    public GameObject exitButton;
    public AudioSource backgroundMusic;
    public AudioSource inGameSound;
    public AudioSource startSound;
    public AudioSource creditSound;
    public AudioSource settingSound;
    public AudioSource teamSound;

    public Slider backgroundMusicSlider;
    public Slider soundEffectsSlider;
    public Toggle bgMusicToggle;
    public Toggle soundFXToggle;
    //public Button showPrompt;
    public string[] enteredScenes;
    public int sceneIndex = 0;
    private void Awake(){
        Application.targetFrameRate = 60;
    }
    // Start is called before the first frame update
    void Start()
    {
        // hide these objects on start
        showCredits.gameObject.SetActive(false);
        showTeam.gameObject.SetActive(false);
        showSettings.gameObject.SetActive(false);

        backgroundMusic.Play();


        backgroundMusicSlider.value = backgroundMusic.volume;
        //soundEffectsSlider.value = 
        bgMusicToggle.isOn = !backgroundMusic.mute;

        backgroundMusicSlider.onValueChanged.AddListener(OnVolumeChanged);
        bgMusicToggle.onValueChanged.AddListener(OnBGMusicToggle);
    }
    public void OnVolumeChanged(float value){
        backgroundMusic.volume = value;
    }
    public void OnBGMusicToggle(bool isOn){
        backgroundMusic.mute = !isOn;
    }
    // Update is called once per frame
    void Update()
    {
    }

    public void Play(){
        startSound.Play();
        Debug.Log("Play!");

        backgroundMusic.Stop();
        //scoreText.text = score.ToString();

        SceneManager.LoadScene(1);

        inGameSound.Play();
        
        //enteredScenes[0] = "Scene 1";
    }
    public void Exit(){
        Debug.Log("Exit button has been clicked!");
        Application.Quit();

        // for debugging purposes only, delete when building
        //UnityEditor.EditorApplication.isPlaying = false;
    }
    public void ShowCredits(){
        creditSound.Play();
        showCredits.gameObject.SetActive(true);
    }
    public void HideCredits(){
        showCredits.gameObject.SetActive(false);
    }
    public void ShowCreators(){
        teamSound.Play();
        showTeam.gameObject.SetActive(true);
    }
    public void HideCreators(){
        showTeam.gameObject.SetActive(false);
    }
    public void ShowSettings(){
        Debug.Log("Settings clicked!");
        showSettings.gameObject.SetActive(true);
    }
    public void HideSettings(){
        Debug.Log("Main menu clicked!");
        showSettings.gameObject.SetActive(false);
    }
}
