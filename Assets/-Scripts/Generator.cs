

using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class Generator : MonoBehaviour
{
    private Object[] mHead;
    private Object[] fHead;
    private Object[] mHair;
    private Object[] fHairLight;
    private Object[] fHairBlond;
    private Object[] fHairDark;
    private Object[] fHairBackLight;
    private Object[] fHairBackBlond;
    private Object[] fHairBackDark;
    private Object[] fHairNoBack;
    private Object[] brows;
    private Object[] mEyes;
    private Object[] fEyes;
    private Object[] nose;
    private Object[] mLips;
    private Object[] fLips;
    private Object[] mBody;
    private Object[] fBody;
    private Object[] bodySpecial;
    private Object[] logo;
    private Object[] detail;

    private List<Object> list;

    public TextAsset MNamesBiH;
    public TextAsset FNamesBiH;
    public TextAsset MNamesHr;
    public TextAsset FNamesHr;
    public TextAsset MNamesSrb;
    public TextAsset FNamesSrb;
    public TextAsset MNamesMNE;
    public TextAsset FNamesMNE;
    public TextAsset MNamesSlo;
    public TextAsset FNamesSlo;
    public TextAsset MNamesMk;
    public TextAsset FNamesMk;

    public TextAsset surnamesBiH;
    public TextAsset surnamesHr;
    public TextAsset surnamesSrb;
    public TextAsset surnamesMNE;
    public TextAsset surnamesSlo;
    public TextAsset surnamesMk;
    void Start()
    {
        ///Person

        mHead = Resources.LoadAll("Person/head", typeof(Sprite));

        fHead = Resources.LoadAll("Person/head", typeof(Sprite));
        list = fHead.ToList();
        list.RemoveRange(0, 3);
        fHead = list.ToArray();

        mHair = Resources.LoadAll("Person/mHair", typeof(Sprite));
        fHairLight = Resources.LoadAll("Person/fHairLight", typeof(Sprite));
        fHairBlond = Resources.LoadAll("Person/fHairBlond", typeof(Sprite));
        fHairDark = Resources.LoadAll("Person/fHairDark", typeof(Sprite));
        fHairBackLight = Resources.LoadAll("Person/fHairBackLight", typeof(Sprite));
        fHairBackBlond = Resources.LoadAll("Person/fHairBackBlond", typeof(Sprite));
        fHairBackDark = Resources.LoadAll("Person/fHairBackDark", typeof(Sprite));
        fHairNoBack = Resources.LoadAll("Person/fHairNoBack", typeof(Sprite));
        brows = Resources.LoadAll("Person/brows", typeof(Sprite));

        mEyes = Resources.LoadAll("Person/eyes", typeof(Sprite));
        list = mEyes.ToList();
        list.RemoveRange(4, 2);
        mEyes = list.ToArray();

        fEyes = Resources.LoadAll("Person/eyes", typeof(Sprite));
        nose = Resources.LoadAll("Person/nose", typeof(Sprite));

        mLips = Resources.LoadAll("Person/lips", typeof(Sprite));
        list = mLips.ToList();
        list.RemoveRange(2, 2);
        mLips = list.ToArray();

        fLips = Resources.LoadAll("Person/lips", typeof(Sprite));
        mBody = Resources.LoadAll("Person/body", typeof(Sprite));

        fBody = Resources.LoadAll("Person/body", typeof(Sprite));
        list = fBody.ToList();
        list.RemoveRange(21, 7);
        fBody = list.ToArray();

        bodySpecial = Resources.LoadAll("Person/bodySpecial", typeof(Sprite));
        logo = Resources.LoadAll("Person/logo", typeof(Sprite));
        detail = Resources.LoadAll("Person/detail", typeof(Sprite));

        //Names
        MNamesBiH = Resources.Load("Names/Imena_BIH_Muska") as TextAsset;
        FNamesBiH = Resources.Load("Names/Imena_BIH_Zenska") as TextAsset;
        MNamesHr = Resources.Load("Names/Imena_Hr_Muska") as TextAsset;
        FNamesHr = Resources.Load("Names/Imena_Hr_Zenska") as TextAsset;
        MNamesSrb = Resources.Load("Names/Imena_Srb_Muska") as TextAsset;
        FNamesSrb = Resources.Load("Names/Imena_Srb_Zenska") as TextAsset;
        MNamesMNE = Resources.Load("Names/Imena_MNE_Muska") as TextAsset;
        FNamesMNE = Resources.Load("Names/Imena_MNE_Zenska") as TextAsset;
        MNamesSlo = Resources.Load("Names/Imena_Slo_Muska") as TextAsset;
        FNamesSlo = Resources.Load("Names/Imena_Slo_Zenska") as TextAsset;
        MNamesMk = Resources.Load("Names/Imena_Mk_Muska") as TextAsset;
        FNamesMk = Resources.Load("Names/Imena_Mk_Zenska") as TextAsset;

        surnamesBiH = Resources.Load("Names/Prezimena_BIH") as TextAsset;
        surnamesHr = Resources.Load("Names/Prezimena_Hr") as TextAsset;
        surnamesSrb = Resources.Load("Names/Prezimena_Srb") as TextAsset;
        surnamesMNE = Resources.Load("Names/Prezimena_MNE") as TextAsset;
        surnamesSlo = Resources.Load("Names/Prezimena_Slo") as TextAsset;
        surnamesMk = Resources.Load("Names/Prezimena_Mk") as TextAsset;

    }
    public void generateRealPassport(
        Transform passport,
        string gender,
        string country
    )
    {
        TextAsset MNames = getMNames(country), FNames = getFNames(country), surnames = getSurnames(country);
        string[] cities = getCities(country);

        Instantiate(passport, new Vector2(Random.Range(-7.5f, -5.5f), Random.Range(-2.5f, -1f)), Quaternion.identity).name = "Passport";
        int d = Data.day;
        int m = Data.month;
        int y = Data.year;

        //DOB
        int month = Random.Range(1, 13);
        int day = randomDateDay(month);
        int year = Random.Range(y - 50, y - 19);
        GameObject.Find("DOB").GetComponent<TextMesh>().text = dateToString(day, month, year);

        //Exp
        if (d == 31 && m == 12)
        {
            year = Random.Range(y + 1, y + 5);
        }
        else
        {
            year = Random.Range(y, y + 5);
        }
        if (year == y)
        {
            if (Random.Range(0, 2) == 0)
            {
                month = m;
                int days = 31;
                if (
                    month == 1 &&
                    month == 3 &&
                    month == 5 &&
                    month == 7 &&
                    month == 8 &&
                    month == 10 &&
                    month == 12
                )
                {
                    days = 32;
                }
                else if (month == 2)
                {
                    days = 29;
                }

                if (d == days)
                {
                    month = m + 1;
                    day = randomDateDay(month);
                    GameObject.Find("Exp").GetComponent<TextMesh>().text = dateToString(day, month, year);
                }
                else
                {
                    day = Random.Range(d + 1, days);
                    GameObject.Find("Exp").GetComponent<TextMesh>().text = dateToString(day, month, year);
                }
            }
            else
            {
                month = Random.Range(m + 1, 13);
                day = randomDateDay(month);
                GameObject.Find("Exp").GetComponent<TextMesh>().text = dateToString(day, month, year);
            }
        }
        else
        {
            month = Random.Range(1, 13);
            day = randomDateDay(month);
            GameObject.Find("Exp").GetComponent<TextMesh>().text = dateToString(day, month, year);
        }

        //ISS
        GameObject.Find("ISS").GetComponent<TextMesh>().text =
            cities[Random.Range(0, cities.Length)];

        //Name
        string namesString;
        if (gender == "M")
        {
            namesString = MNames.text;
        }
        else
        {
            namesString = FNames.text;
        }
        List<string> namesList = new List<string>();
        namesList.AddRange(namesString.Split("\n"[0]));

        string surnamesString = surnames.text;
        List<string> surnamesList = new List<string>();
        surnamesList.AddRange(surnamesString.Split("\n"[0]));

        GameObject.Find("Sex").GetComponent<TextMesh>().text = gender;
        GameObject.Find("Name").GetComponent<TextMesh>().text = namesList[Random.Range(0, namesList.Count)] + " " + surnamesList[Random.Range(0, surnamesList.Count)];

        //SerialNum
        GameObject.Find("SerialNum").GetComponent<TextMesh>().text =
            ((char)('A' + Random.Range(0, 16))).ToString() +
            Random.Range(1000000, 9999999).ToString();

        //Image
        GameObject.Find("HeadImg").GetComponent<SpriteRenderer>().sprite =
            GameObject.Find("Head").GetComponent<SpriteRenderer>().sprite;
        GameObject.Find("HairImg").GetComponent<SpriteRenderer>().sprite =
            GameObject.Find("Hair").GetComponent<SpriteRenderer>().sprite;
        GameObject.Find("LipsImg").GetComponent<SpriteRenderer>().sprite =
            GameObject.Find("Lips").GetComponent<SpriteRenderer>().sprite;
        GameObject.Find("EyesImg").GetComponent<SpriteRenderer>().sprite =
            GameObject.Find("Eyes").GetComponent<SpriteRenderer>().sprite;
        GameObject.Find("HairBackImg").GetComponent<SpriteRenderer>().sprite =
            GameObject.Find("HairBack").GetComponent<SpriteRenderer>().sprite;
        GameObject.Find("BrowsImg").GetComponent<SpriteRenderer>().sprite =
            GameObject.Find("Brows").GetComponent<SpriteRenderer>().sprite;
        GameObject.Find("NoseImg").GetComponent<SpriteRenderer>().sprite =
            GameObject.Find("Nose").GetComponent<SpriteRenderer>().sprite;
    }

    public void generateFakePassport(
        Transform passport,
        string[] fakeCities,
        string gender,
        string country
    )
    {
        TextAsset MNames = getMNames(country), FNames = getFNames(country), surnames = getSurnames(country);
        string[] cities = getCities(country);

        int d = Data.day;
        int m = Data.month;
        int y = Data.year;
        Instantiate(passport, new Vector2(Random.Range(-7.5f, -5.5f), Random.Range(-2.5f, -1f)), Quaternion.identity).name = "Passport";
        int r = Random.Range(0, 4);
        GameObject.Find("Passport").GetComponent<Passport>().greska = r;

        //DOB
        int month = Random.Range(1, 13);
        int day = randomDateDay(month);
        int year = Random.Range(y - 50, y - 19);
        GameObject.Find("DOB").GetComponent<TextMesh>().text = dateToString(day, month, year);

        //ISS
        if (r == 0)
        {
            GameObject.Find("ISS").GetComponent<TextMesh>().text = fakeCity(country);
        }
        else
        {
            GameObject.Find("ISS").GetComponent<TextMesh>().text = fakeCity(country);
        }

        //Name
        string namesString;
        if (gender == "M")
        {
            namesString = MNames.text;
        }
        else
        {
            namesString = FNames.text;
        }
        List<string> namesList = new List<string>();
        namesList.AddRange(namesString.Split("\n"[0]));

        string surnamesString = surnames.text;
        List<string> surnamesList = new List<string>();
        surnamesList.AddRange(surnamesString.Split("\n"[0]));

        GameObject.Find("Sex").GetComponent<TextMesh>().text = gender;
        GameObject.Find("Name").GetComponent<TextMesh>().text = namesList[Random.Range(0, namesList.Count)] + " " + surnamesList[Random.Range(0, surnamesList.Count)];

        //Sex
        if (r == 1)
        {
            if (gender == "M")
            {
                GameObject.Find("Sex").GetComponent<TextMesh>().text = "F";
            }
            else
            {
                GameObject.Find("Sex").GetComponent<TextMesh>().text = "M";
            }
        }
        else
        {
            GameObject.Find("Sex").GetComponent<TextMesh>().text = gender;
        }

        //Image
        if (r == 2)
        {
            GameObject.Find("HeadImg").GetComponent<SpriteRenderer>().sprite =
                GameObject.Find("FakePixHead").GetComponent<SpriteRenderer>().sprite;
            GameObject.Find("HairImg").GetComponent<SpriteRenderer>().sprite =
                GameObject.Find("FakePixHair").GetComponent<SpriteRenderer>().sprite;
            GameObject.Find("LipsImg").GetComponent<SpriteRenderer>().sprite =
                GameObject.Find("FakePixLips").GetComponent<SpriteRenderer>().sprite;
            GameObject.Find("EyesImg").GetComponent<SpriteRenderer>().sprite =
                GameObject.Find("FakePixEyes").GetComponent<SpriteRenderer>().sprite;
            GameObject.Find("HairBackImg").GetComponent<SpriteRenderer>().sprite =
                GameObject.Find("FakePixHairBack").GetComponent<SpriteRenderer>().sprite;
            GameObject.Find("BrowsImg").GetComponent<SpriteRenderer>().sprite =
                GameObject.Find("FakePixBrows").GetComponent<SpriteRenderer>().sprite;
            GameObject.Find("NoseImg").GetComponent<SpriteRenderer>().sprite =
                GameObject.Find("FakePixNose").GetComponent<SpriteRenderer>().sprite;
        }
        else
        {
            GameObject.Find("HeadImg").GetComponent<SpriteRenderer>().sprite =
                GameObject.Find("Head").GetComponent<SpriteRenderer>().sprite;
            GameObject.Find("HairImg").GetComponent<SpriteRenderer>().sprite =
                GameObject.Find("Hair").GetComponent<SpriteRenderer>().sprite;
            GameObject.Find("LipsImg").GetComponent<SpriteRenderer>().sprite =
                GameObject.Find("Lips").GetComponent<SpriteRenderer>().sprite;
            GameObject.Find("EyesImg").GetComponent<SpriteRenderer>().sprite =
                GameObject.Find("Eyes").GetComponent<SpriteRenderer>().sprite;
            GameObject.Find("HairBackImg").GetComponent<SpriteRenderer>().sprite =
                GameObject.Find("HairBack").GetComponent<SpriteRenderer>().sprite;
            GameObject.Find("BrowsImg").GetComponent<SpriteRenderer>().sprite =
                GameObject.Find("Brows").GetComponent<SpriteRenderer>().sprite;
            GameObject.Find("NoseImg").GetComponent<SpriteRenderer>().sprite =
                GameObject.Find("Nose").GetComponent<SpriteRenderer>().sprite;
        }

        //Exp
        if (r == 3)
        {
            if (Random.Range(0, 2) == 0)
            {
                if (d == 1 && m == 1)
                {
                    year = y - 1;
                    month = Random.Range(1, 13);
                    day = randomDateDay(month);
                }
                else if (m == 1)
                {
                    year = y;
                    month = 1;
                    day = Random.Range(1, d);
                }
                else
                {
                    year = y;
                    month = Random.Range(1, m);
                    day = randomDateDay(month);
                }
            }
            else
            {
                year = Random.Range(y - 3, y - 1);
                month = Random.Range(1, 13);
                day = randomDateDay(month);
            }
            GameObject.Find("Exp").GetComponent<TextMesh>().text = dateToString(day, month, year);
        }
        else
        {
            if (d == 31 && m == 12)
            {
                year = Random.Range(y + 1, y + 5);
            }
            else
            {
                year = Random.Range(y, y + 5);
            }
            if (year == y)
            {
                if (Random.Range(0, 2) == 0)
                {
                    month = m;
                    int days = 31;
                    if (
                        month == 1 &&
                        month == 3 &&
                        month == 5 &&
                        month == 7 &&
                        month == 8 &&
                        month == 10 &&
                        month == 12
                    )
                    {
                        days = 32;
                    }
                    else if (month == 2)
                    {
                        days = 29;
                    }

                    if (d == days)
                    {
                        month = m + 1;
                        day = randomDateDay(month);
                        GameObject.Find("Exp").GetComponent<TextMesh>().text = dateToString(day, month, year);
                    }
                    else
                    {
                        day = Random.Range(d + 1, days);
                        GameObject.Find("Exp").GetComponent<TextMesh>().text = dateToString(day, month, year);
                    }
                }
                else
                {
                    month = Random.Range(m + 1, 13);
                    day = randomDateDay(month);
                    GameObject.Find("Exp").GetComponent<TextMesh>().text =
                        formatDate(day) +
                        "." +
                        formatDate(month) +
                        "." +
                        year.ToString() +
                        ".";
                }
            }
            else
            {
                month = Random.Range(1, 13);
                day = randomDateDay(month);
                GameObject.Find("Exp").GetComponent<TextMesh>().text = dateToString(day, month, year);
            }
        }

        //SerialNum
        GameObject.Find("SerialNum").GetComponent<TextMesh>().text =
            ((char)('A' + Random.Range(0, 16))).ToString() +
            Random.Range(1000000, 9999999).ToString();
    }

    public string radnomPerson(
        Transform person
    )
    {
        string gender = "F";
        if (Random.Range(0, 2) == 0)
        {
            gender = "M";
        }
        int rand;
        Instantiate(person, new Vector2(-12f, Random.Range(-1f, 0f)), Quaternion.identity)
            .name = "Person";

        //Person
        int body = Random.Range(0, 10);
        if (gender == "M")
        {
            GameObject.Find("Head").GetComponent<SpriteRenderer>().sprite =
                (Sprite)mHead[Random.Range(0, mHead.Length)];
            GameObject.Find("Eyes").GetComponent<SpriteRenderer>().sprite =
                (Sprite)mEyes[Random.Range(0, mEyes.Length)];
            GameObject.Find("Lips").GetComponent<SpriteRenderer>().sprite =
                (Sprite)mLips[Random.Range(0, mLips.Length)];
            GameObject.Find("Hair").GetComponent<SpriteRenderer>().sprite =
                (Sprite)mHair[Random.Range(0, mHair.Length)];
            if (body != 0)
            {
                GameObject.Find("Body").GetComponent<SpriteRenderer>().sprite =
                    (Sprite)mBody[Random.Range(0, mBody.Length)];

            }
        }
        else
        {
            GameObject.Find("Head").GetComponent<SpriteRenderer>().sprite =
                (Sprite)fHead[Random.Range(0, fHead.Length)];
            GameObject.Find("Eyes").GetComponent<SpriteRenderer>().sprite =
                (Sprite)fEyes[Random.Range(0, fEyes.Length)];
            GameObject.Find("Lips").GetComponent<SpriteRenderer>().sprite =
                (Sprite)fLips[Random.Range(0, fLips.Length)];
            rand =
                Random
                    .Range(0,
                    fHairLight.Length +
                    fHairBlond.Length +
                    fHairDark.Length +
                    fHairNoBack.Length);
            if (rand < fHairLight.Length)
            {
                GameObject.Find("Hair").GetComponent<SpriteRenderer>().sprite =
                    (Sprite)fHairLight[rand];
                rand = Random.Range(0, fHairBackLight.Length);
                GameObject
                    .Find("HairBack")
                    .GetComponent<SpriteRenderer>()
                    .sprite = (Sprite)fHairBackLight[rand];
            }
            else if (rand < fHairBlond.Length + fHairLight.Length)
            {
                GameObject.Find("Hair").GetComponent<SpriteRenderer>().sprite =
                    (Sprite)fHairBlond[rand - fHairLight.Length];
                rand = Random.Range(0, fHairBackBlond.Length);
                GameObject
                    .Find("HairBack")
                    .GetComponent<SpriteRenderer>()
                    .sprite = (Sprite)fHairBackBlond[rand];
            }
            else if (
                rand < fHairDark.Length + fHairLight.Length + fHairBlond.Length
            )
            {
                GameObject.Find("Hair").GetComponent<SpriteRenderer>().sprite =
                    (Sprite)fHairDark[rand - fHairLight.Length - fHairBlond.Length];
                rand = Random.Range(0, fHairBackDark.Length);
                GameObject
                    .Find("HairBack")
                    .GetComponent<SpriteRenderer>()
                    .sprite = (Sprite)fHairBackDark[rand];
            }
            else
            {
                GameObject.Find("Hair").GetComponent<SpriteRenderer>().sprite =
                    (Sprite)fHairNoBack[rand -
                    fHairLight.Length -
                    fHairBlond.Length -
                    fHairDark.Length];
            }
            if (body != 0)
            {
                GameObject.Find("Body").GetComponent<SpriteRenderer>().sprite =
                    (Sprite)fBody[Random.Range(0, fBody.Length)];

            }
        }
        GameObject.Find("Nose").GetComponent<SpriteRenderer>().sprite =
            (Sprite)nose[Random.Range(0, nose.Length)];
        GameObject.Find("Brows").GetComponent<SpriteRenderer>().sprite =
            (Sprite)brows[Random.Range(0, brows.Length)];
        if (body == 0)
        {
            GameObject.Find("Body").GetComponent<SpriteRenderer>().sprite =
                (Sprite)bodySpecial[Random.Range(0, bodySpecial.Length)];
        }
        else
        {
            if (Random.Range(0, 2) == 0)
            {
                GameObject.Find("Logo").GetComponent<SpriteRenderer>().sprite =
                    (Sprite)logo[Random.Range(0, logo.Length)];
            }
            if (Random.Range(0, 8) == 0)
            {
                GameObject.Find("Body detail").GetComponent<SpriteRenderer>().sprite =
                    (Sprite)detail[Random.Range(0, detail.Length)];
            }
        }

        //FakePixPerson
        if (gender == "M")
        {
            GameObject.Find("FakePixHead").GetComponent<SpriteRenderer>().sprite =
                (Sprite)mHead[Random.Range(0, mHead.Length)];
            GameObject.Find("FakePixEyes").GetComponent<SpriteRenderer>().sprite =
                (Sprite)mEyes[Random.Range(0, mEyes.Length)];
            GameObject.Find("FakePixLips").GetComponent<SpriteRenderer>().sprite =
                (Sprite)mLips[Random.Range(0, mLips.Length)];
            GameObject.Find("FakePixHair").GetComponent<SpriteRenderer>().sprite =
                (Sprite)mHair[Random.Range(0, mHair.Length)];
        }
        else
        {
            GameObject.Find("FakePixHead").GetComponent<SpriteRenderer>().sprite =
                (Sprite)fHead[Random.Range(0, fHead.Length)];
            GameObject.Find("FakePixEyes").GetComponent<SpriteRenderer>().sprite =
                (Sprite)fEyes[Random.Range(0, fEyes.Length)];
            GameObject.Find("FakePixLips").GetComponent<SpriteRenderer>().sprite =
                (Sprite)fLips[Random.Range(0, fLips.Length)];
            rand =
                Random
                    .Range(0,
                    fHairLight.Length +
                    fHairBlond.Length +
                    fHairDark.Length +
                    fHairNoBack.Length);
            if (rand < fHairLight.Length)
            {
                GameObject.Find("FakePixHair").GetComponent<SpriteRenderer>().sprite =
                    (Sprite)fHairLight[rand];
                rand = Random.Range(0, fHairBackLight.Length);
                GameObject
                    .Find("FakePixHairBack")
                    .GetComponent<SpriteRenderer>()
                    .sprite = (Sprite)fHairBackLight[rand];
            }
            else if (rand < fHairBlond.Length + fHairLight.Length)
            {
                GameObject.Find("FakePixHair").GetComponent<SpriteRenderer>().sprite =
                    (Sprite)fHairBlond[rand - fHairLight.Length];
                rand = Random.Range(0, fHairBackBlond.Length);
                GameObject
                    .Find("FakePixHairBack")
                    .GetComponent<SpriteRenderer>()
                    .sprite = (Sprite)fHairBackBlond[rand];
            }
            else if (
                rand < fHairDark.Length + fHairLight.Length + fHairBlond.Length
            )
            {
                GameObject.Find("FakePixHair").GetComponent<SpriteRenderer>().sprite =
                    (Sprite)fHairDark[rand - fHairLight.Length - fHairBlond.Length];
                rand = Random.Range(0, fHairBackDark.Length);
                GameObject
                    .Find("FakePixHairBack")
                    .GetComponent<SpriteRenderer>()
                    .sprite = (Sprite)fHairBackDark[rand];
            }
            else
            {
                GameObject.Find("FakePixHair").GetComponent<SpriteRenderer>().sprite =
                    (Sprite)fHairNoBack[rand -
                    fHairLight.Length -
                    fHairBlond.Length -
                    fHairDark.Length];
            }
        }
        GameObject.Find("FakePixNose").GetComponent<SpriteRenderer>().sprite =
            (Sprite)nose[Random.Range(0, nose.Length)];
        GameObject.Find("FakePixBrows").GetComponent<SpriteRenderer>().sprite =
            (Sprite)brows[Random.Range(0, brows.Length)];

        return gender;
    }

    public void generateRealIDcard()
    {

    }

    public void generateFakeIDcard()
    {

    }

    public int randomDateDay(int month)
    {
        int day = Random.Range(1, 31);
        if (
            month == 1 &&
            month == 3 &&
            month == 5 &&
            month == 7 &&
            month == 8 &&
            month == 10 &&
            month == 12
        )
        {
            day = Random.Range(1, 32);
        }
        else if (month == 2)
        {
            day = Random.Range(1, 29);
        }
        return day;
    }

    public string formatDate(int date)
    {
        if (date < 10)
        {
            return "0" + date.ToString();
        }
        else
        {
            return date.ToString();
        }
    }

    public string dateToString(int day, int month, int year)
    {
        return formatDate(day) + "." + formatDate(month) + "." + year.ToString() + ".";
    }

    public TextAsset getMNames(string country)
    {
        if (country == "BiH")
        {
            return MNamesBiH;
        }
        else if (country == "Hr")
        {
            return MNamesHr;
        }
        else if (country == "Srb")
        {
            return MNamesSrb;
        }
        else if (country == "MNE")
        {
            return MNamesMNE;
        }
        else if (country == "Slo")
        {
            return MNamesSlo;
        }
        else if (country == "Mk")
        {
            return MNamesMk;
        }
        return null;
    }
    public TextAsset getFNames(string country)
    {
        if (country == "BiH")
        {
            return FNamesBiH;
        }
        else if (country == "Hr")
        {
            return FNamesHr;
        }
        else if (country == "Srb")
        {
            return FNamesSrb;
        }
        else if (country == "MNE")
        {
            return FNamesMNE;
        }
        else if (country == "Slo")
        {
            return FNamesSlo;
        }
        else if (country == "Mk")
        {
            return FNamesMk;
        }
        return null;
    }
    public TextAsset getSurnames(string country)
    {
        if (country == "BiH")
        {
            return surnamesBiH;
        }
        else if (country == "Hr")
        {
            return surnamesHr;
        }
        else if (country == "Srb")
        {
            return surnamesSrb;
        }
        else if (country == "MNE")
        {
            return surnamesMNE;
        }
        else if (country == "Slo")
        {
            return surnamesSlo;
        }
        else if (country == "Mk")
        {
            return surnamesMk;
        }
        return null;
    }
    public string[] getCities(string country)
    {
        if (country == "BiH")
        {
            return Data.gradoviBiH;
        }
        else if (country == "Hr")
        {
            return Data.gradoviHr;
        }
        else if (country == "Srb")
        {
            return Data.gradoviSrb;
        }
        else if (country == "MNE")
        {
            return Data.gradoviMNE;
        }
        else if (country == "Slo")
        {
            return Data.gradoviSlo;
        }
        else if (country == "Mk")
        {
            return Data.gradoviMk;
        }
        return null;
    }
    public string fakeCity(string country)
    {
        if (Random.Range(0, 2) == 0)
        {
            string[] temp = null;
            if (country == "BiH")
            {
                temp = Data.gradoviHr.Concat(Data.gradoviMk).Concat(Data.gradoviMNE).Concat(Data.gradoviSlo).Concat(Data.gradoviSrb).ToArray();
            }
            else if (country == "Hr")
            {
                temp = Data.gradoviBiH.Concat(Data.gradoviMk).Concat(Data.gradoviMNE).Concat(Data.gradoviSlo).Concat(Data.gradoviSrb).ToArray();
            }
            else if (country == "Srb")
            {
                temp = Data.gradoviHr.Concat(Data.gradoviMk).Concat(Data.gradoviMNE).Concat(Data.gradoviSlo).Concat(Data.gradoviBiH).ToArray();
            }
            else if (country == "MNE")
            {
                temp = Data.gradoviHr.Concat(Data.gradoviMk).Concat(Data.gradoviBiH).Concat(Data.gradoviSlo).Concat(Data.gradoviSrb).ToArray();
            }
            else if (country == "Slo")
            {
                temp = Data.gradoviHr.Concat(Data.gradoviMk).Concat(Data.gradoviMNE).Concat(Data.gradoviBiH).Concat(Data.gradoviSrb).ToArray();
            }
            else if (country == "Mk")
            {
                temp = Data.gradoviHr.Concat(Data.gradoviBiH).Concat(Data.gradoviMNE).Concat(Data.gradoviSlo).Concat(Data.gradoviSrb).ToArray();
            }
            return temp[Random.Range(0, temp.Length)];
        }
        else
        {
            List<char> vocals = new List<char> { 'a', 'e', 'i', 'o', 'u' };
            string city = getCities(country)[Random.Range(0, getCities(country).Length)];

            int letterIndex = Random.Range(0, city.Length);
            char letter = char.ToLower(city[letterIndex]);
            while (letter == ' ')
            {
                letterIndex = Random.Range(0, city.Length);
                letter = char.ToLower(city[letterIndex]);
            }

            char newLetter = letter;
            if (vocals.Contains(letter))
            {
                while (newLetter == letter)
                {
                    newLetter = vocals[Random.Range(0, 5)];
                }
            }
            else
            {
                while (newLetter == letter || vocals.Contains(newLetter) || newLetter == 'q' || newLetter == 'w' || newLetter == 'x' || newLetter == 'y')
                {
                    newLetter = getKeysAround(letter)[Random.Range(0, getKeysAround(letter).Count)];
                }
            }
            StringBuilder sb = new StringBuilder(city);
            if (letterIndex == 0 || city[letterIndex - 1] == ' ') sb[letterIndex] = char.ToUpper(newLetter);
            else sb[letterIndex] = newLetter;
            city = sb.ToString();

            return city;
        }
    }
    static List<char> getKeysAround(char key)
    {
        string[] lines = { "qwertyuiop", "asdfghjkl", "zxcvbnm" };
        var (lineIndex, index) = (0, 0);

        foreach (var (i, line) in lines.Select((l, i) => (i, l)))
        {
            var keyIndex = line.IndexOf(key);
            if (keyIndex != -1)
            {
                lineIndex = i;
                index = keyIndex;
                break;
            }
        }

        var selectedLines = lineIndex > 0
            ? lines.Skip(lineIndex - 1).Take(3)
            : lines.Take(2);

        var result = new List<char>();
        foreach (var line in selectedLines)
        {
            foreach (var i in new[] { -1, 0, 1 })
            {
                if (index + i >= 0 && index + i < line.Length && line[index + i] != key)
                {
                    result.Add(line[index + i]);
                }
            }
        }

        return result;
    }
}