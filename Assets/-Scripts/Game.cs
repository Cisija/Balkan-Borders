
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Game : MonoBehaviour
{
    public Transform guy;
    public Transform person;

    public Transform passportBiH;
    public Transform passportHr;
    public Transform passportSrb;
    public Transform passportMNE;
    public Transform passportSlo;
    public Transform passportMk;

    private Generator gen;

    private string gender;
    private int r;
    private bool next = false;
    private bool fake = false;
    private float x, y;
    private Transform temp;

    private List<Object> list;

    // Start is called before the first frame update
    void Start()
    {
        gen = GetComponent<Generator>();
        Data.guy = 0;

        Transform guys = GameObject.Find("Guys").GetComponent<Transform>();

        for (int i = 1; i <= 50; i++)
        {
            x = Random.Range(7, 15) / 100f * 3f;
            y = Random.Range(-4, 5) / 100f * 3f;
            temp = Instantiate(guy, new Vector2(GameObject.Find("Guy" + (i - 1).ToString()).transform.position.x + x, 3.015f + y), Quaternion.identity);
            temp.name = "Guy" + i.ToString();
            temp.GetComponent<Guy>().distance = x;
            temp.parent = guys.transform;
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (next && Data.open && Data.arrive)
        {
            Invoke("PassportGen", 0.5f);
            next = false;
        }
    }

    public void Next()
    {
        gender = gen.radnomPerson(person);
        next = true;
    }

    private void PassportGen()
    {
        r = Random.Range(0, 6);
        if (r == 0)
        {
            if (Random.Range(0, 2) == 0)
            {
                gen.generateRealPassport(passportBiH, gender, "BiH");
                fake = false;
            }
            else
            {
                gen.generateFakePassport(passportBiH, Data.gradoviSrb.Concat(Data.gradoviHr).ToArray().Concat(Data.gradoviMNE).ToArray().Concat(Data.gradoviSlo).ToArray().Concat(Data.gradoviMk).ToArray(), gender, "BiH");
                fake = true;
            }
        }
        else if (r == 1)
        {
            if (Random.Range(0, 2) == 0)
            {
                gen.generateRealPassport(passportHr, gender, "Hr");
                fake = false;
            }
            else
            {
                gen.generateFakePassport(passportHr, Data.gradoviBiH.Concat(Data.gradoviSrb).ToArray().Concat(Data.gradoviMNE).ToArray().Concat(Data.gradoviSlo).ToArray().Concat(Data.gradoviMk).ToArray(), gender, "Hr");
                fake = true;
            }
        }
        else if (r == 2)
        {
            if (Random.Range(0, 2) == 0)
            {
                gen.generateRealPassport(passportSrb, gender, "Srb");
                fake = false;
            }
            else
            {
                gen.generateFakePassport(passportSrb, Data.gradoviBiH.Concat(Data.gradoviHr).ToArray().Concat(Data.gradoviMNE).ToArray().Concat(Data.gradoviSlo).ToArray().Concat(Data.gradoviMk).ToArray(), gender, "Srb");
                fake = true;
            }
        }
        else if (r == 3)
        {
            if (Random.Range(0, 2) == 0)
            {
                gen.generateRealPassport(passportMNE, gender, "MNE");
                fake = false;
            }
            else
            {
                gen.generateFakePassport(passportMNE, Data.gradoviBiH.Concat(Data.gradoviSrb).ToArray().Concat(Data.gradoviHr).ToArray().Concat(Data.gradoviSlo).ToArray().Concat(Data.gradoviMk).ToArray(), gender, "MNE");
                fake = true;
            }
        }
        else if (r == 4)
        {
            if (Random.Range(0, 2) == 0)
            {
                gen.generateRealPassport(passportSlo, gender, "Slo");
                fake = false;
            }
            else
            {
                gen.generateFakePassport(passportSlo, Data.gradoviBiH.Concat(Data.gradoviHr).ToArray().Concat(Data.gradoviMNE).ToArray().Concat(Data.gradoviSrb).ToArray().Concat(Data.gradoviMk).ToArray(), gender, "Slo");
                fake = true;
            }
        }
        else if (r == 5)
        {
            if (Random.Range(0, 2) == 0)
            {
                gen.generateRealPassport(passportMk, gender, "Mk");
                fake = false;
            }
            else
            {
                gen.generateFakePassport(passportMk, Data.gradoviBiH.Concat(Data.gradoviHr).ToArray().Concat(Data.gradoviMNE).ToArray().Concat(Data.gradoviSlo).ToArray().Concat(Data.gradoviSrb).ToArray(), gender, "Mk");
                fake = true;
            }
        }
    }

    public void personDeath()
    {
        if ((fake && GameObject.Find("Stamp") == null) || (!fake && GameObject.Find("Stamp") != null))
        {
            Data.correct++;
        }
        else
        {
            Data.incorrect++;
            if (!fake)
            {
                GameObject.Find("Woki Toki").GetComponent<WokiToki>().error(-1);
            }
            else
            {
                GameObject.Find("Woki Toki").GetComponent<WokiToki>().error(GameObject.Find("Passport").GetComponent<Passport>().greska);
            }
        }
        Destroy(GameObject.Find("Person"));
        Data.arrive = false;
        Destroy(GameObject.Find("Passport"));
    }
}