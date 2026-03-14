using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Manager : MonoBehaviour
{
    public GameObject pauseMenu;
    public GameObject dayEnd;
    public Slider radioVolume;
    public Slider musicVolume;

    private Generator gen;
    private Radio radio;

    // Start is called before the first frame update
    void Start()
    {
        Data.day = System.DateTime.Now.Day;
        Data.month = System.DateTime.Now.Month;
        Data.year = System.DateTime.Now.Year;

        Data.radioVolume = PlayerPrefs.GetFloat("Radio volume");
        Data.musicVolume = PlayerPrefs.GetFloat("Music volume");
        radioVolume.value = Data.radioVolume;
        musicVolume.value = Data.musicVolume;
        gen = GetComponent<Generator>();
        radio = GameObject.Find("Radio").GetComponent<Radio>();
    }

    // Update is called once per frame
    void Update()
    {
        Data.radioVolume = radioVolume.value;
        Data.musicVolume = musicVolume.value;
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameObject.Find("Back") != null)
            {
                GameObject.Find("Back").GetComponent<Button>().onClick.Invoke();
            }
            else if (GameObject.Find("No") != null)
            {
                GameObject.Find("No").GetComponent<Button>().onClick.Invoke();
            }
            else
            {
                Pause();
            }
            Save();
        }
        if (Data.h == 18)
        {
            DayEnd();
            Data.h = 0;
        }
    }
    public void Pause()
    {
        Data.pause = !Data.pause;
        pauseMenu.SetActive(Data.pause);
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(sceneName: "Main Menu");
    }

    public void DayEnd()
    {
        Data.pause = true;
        dayEnd.SetActive(true);
        GameObject.Find("Correct").GetComponent<Text>().text = Data.correct.ToString();
        GameObject.Find("Incorrect").GetComponent<Text>().text = Data.incorrect.ToString();
        Data.correct = 0;
        Data.incorrect = 0;
        Data.start = false;
        Data.radio = 0;
        radio.Stop();
    }

    public void Save()
    {
        PlayerPrefs.SetFloat("Radio volume", radioVolume.value);
        PlayerPrefs.SetFloat("Music volume", musicVolume.value);
    }

    public void PushDown(string obj)
    {
        List<GameObject> objects = new List<GameObject>();
        objects.Add(GameObject.Find("Map"));
        objects.Add(GameObject.Find("Rulebook"));
        int l = 0;
        if (GameObject.Find("Passport"))
        {
            objects.Add(GameObject.Find("Passport"));
        }
        if (GameObject.Find("IDcard"))
        {
            objects.Add(GameObject.Find("IDcard"));
        }
        GameObject t;
        for (int i = 0; i < objects.Count; i++)
        {
            for (int j = 0; j < objects.Count; j++)
            {
                if (Int32.Parse(objects[i].GetComponent<SpriteRenderer>().sortingLayerName[0].ToString()) < Int32.Parse(objects[j].GetComponent<SpriteRenderer>().sortingLayerName[0].ToString()))
                {
                    t = objects[i];
                    objects[i] = objects[j];
                    objects[j] = t;
                }
            }
        }
        for (int i = 0; i < objects.Count; i++)
        {
            if (objects[i].name == obj)
            {
                l = i;
                break;
            }
        }
        for (int i = l; i > 0; i--)
        {
            t = objects[i];
            objects[i] = objects[i - 1];
            objects[i - 1] = t;
        }
        for (int i = 0; i < objects.Count; i++)
        {
            if (objects[i].name == "Rulebook")
            {
                objects[i].GetComponent<Rulebook>().layer = i + 1;
            }
            else if (objects[i].name == "Map")
            {
                objects[i].GetComponent<Map>().layer = i + 1;
            }
            else if (objects[i].name == "Passport")
            {
                objects[i].GetComponent<Passport>().layer = i + 1;
            }
            else if (objects[i].name == "IDcard")
            {
                objects[i].GetComponent<IDcard>().layer = i + 1;
            }
            objects[i].transform.position = new Vector3(objects[i].transform.position.x, objects[i].transform.position.y, i + 1);
        }
    }

    public void resetZ()
    {
        /*GameObject t;
        List<GameObject> objects = new List<GameObject>();
        objects.Add(GameObject.Find("Map"));
        objects.Add(GameObject.Find("Rulebook"));
        if (GameObject.Find("Passport"))
        {
            objects.Add(GameObject.Find("Passport"));
        }
        if (GameObject.Find("IDcard"))
        {
            objects.Add(GameObject.Find("IDcard"));
        }
        bool intersects;
        BoxCollider2D collider1 = null;
        BoxCollider2D collider2 = null;
        foreach (GameObject object1 in objects)
        {
            object1.transform.position = new Vector3(object1.transform.position.x, object1.transform.position.y, 0);
        }
        foreach (GameObject object1 in objects)
        {
            intersects = false;
            foreach (GameObject object2 in objects)
            {
                if (object1.name == "Rulebook")
                {
                    collider1 = object1.GetComponent<Rulebook>().ColliderBig;
                }
                else if (object1.name == "Map")
                {
                    collider1 = object1.GetComponent<Map>().ColliderBig;
                }
                else if (object1.name == "Passport")
                {
                    collider1 = object1.GetComponent<Passport>().ColliderBig;
                }
                else if (object1.name == "IDcard")
                {
                    collider1 = object1.GetComponent<IDcard>().ColliderBig;
                }

                if (object2.name == "Rulebook")
                {
                    collider2 = object2.GetComponent<Rulebook>().ColliderBig;
                }
                else if (object2.name == "Map")
                {
                    collider2 = object2.GetComponent<Map>().ColliderBig;
                }
                else if (object2.name == "Passport")
                {
                    collider2 = object2.GetComponent<Passport>().ColliderBig;
                }
                else if (object2.name == "IDcard")
                {
                    collider2 = object2.GetComponent<IDcard>().ColliderBig;
                }

                Debug.Log(object1.name + " " + object2.name);
                Debug.Log(object1.GetComponent<BoxCollider2D>().bounds.Intersects(object2.GetComponent<BoxCollider2D>().bounds));

                if (collider1.bounds.Intersects(collider2.bounds) && object1 != object2)
                {
                    intersects = true;
                }
            }
            if (!intersects)
            {
                if (object1.name == "Rulebook")
                {
                    object1.GetComponent<Rulebook>().layer = object1.GetComponent<Rulebook>().layer - 1;
                }
                else if (object1.name == "Map")
                {
                    object1.GetComponent<Map>().layer = object1.GetComponent<Map>().layer - 1;
                }
                else if (object1.name == "Passport")
                {
                    object1.GetComponent<Passport>().layer -= 1;
                }
                else if (object1.name == "IDcard")
                {
                    object1.GetComponent<IDcard>().layer -= 1;
                }
            }
            for (int i = 0; i < objects.Count; i++)
            {
                for (int j = 0; j < objects.Count; j++)
                {
                    if (Int32.Parse(objects[i].GetComponent<SpriteRenderer>().sortingLayerName[0].ToString()) < Int32.Parse(objects[j].GetComponent<SpriteRenderer>().sortingLayerName[0].ToString()))
                    {
                        t = objects[i];
                        objects[i] = objects[j];
                        objects[j] = t;
                    }
                }
            }
            for (int i = 0; i < objects.Count; i++)
            {
                if (objects[i].name == "Rulebook")
                {
                    objects[i].GetComponent<Rulebook>().layer = i + 1;
                }
                else if (objects[i].name == "Map")
                {
                    objects[i].GetComponent<Map>().layer = i + 1;
                }
                else if (objects[i].name == "Passport")
                {
                    objects[i].GetComponent<Passport>().layer = i + 1;
                }
                else if (objects[i].name == "IDcard")
                {
                    objects[i].GetComponent<IDcard>().layer = i + 1;
                }
                objects[i].transform.position = new Vector3(objects[i].transform.position.x, objects[i].transform.position.y, i + 1);
            }
        }*/
    }
}