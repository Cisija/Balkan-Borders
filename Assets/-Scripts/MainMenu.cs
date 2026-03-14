using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    // Start is called before the first frame update
    public Slider radioVolume;
    public Slider musicVolume;
    private AudioSource music;
    void Start()
    {
        Data.radioVolume=PlayerPrefs.GetFloat("Radio volume");
        Data.musicVolume=PlayerPrefs.GetFloat("Music volume");
        radioVolume.value=Data.radioVolume;
        musicVolume.value=Data.musicVolume;
        music=GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        Data.radioVolume=radioVolume.value;
        Data.musicVolume=musicVolume.value;

        music.volume=Data.musicVolume;

        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(GameObject.Find("Back")!=null)
            {
                GameObject.Find("Back").GetComponent<Button>().onClick.Invoke();
            }
            Save();
        }
    }

    public void Hr()
    {
        Data.pause=false;
        SceneManager.LoadScene(sceneName:"BiH-Hr");
    }
    public void Srb()
    {
        Data.pause = false;
        SceneManager.LoadScene(sceneName: "BiH-Srb");
    }

    public void Quit()
    {
        Save();
        Application.Quit();
    }

    public void Save()
    {
        PlayerPrefs.SetFloat("Radio volume",radioVolume.value);
        PlayerPrefs.SetFloat("Music volume",musicVolume.value);
    }
}
