using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Data
{
    public static int correct=0;
    public static int incorrect=0;
    public static bool pause=false;
    public static float h=0,m=0;
    public static int day,month,year;
    public static string[] gradoviBiH = { "Sarajevo", "Banja Luka", "Tuzla", "Mostar", "Zenica"};
    public static string[] gradoviHr = { "Zagreb", "Split", "Osijek", "Rijeka", "Dubrovnik"};
    public static string[] gradoviSrb = { "Beograd", "Nis", "Novi Sad", "Subotica", "Kragujevac"};
    public static string[] gradoviMNE = { "Podgorica", "Niksic", "Bijelo Polje", "Herceg Novi", "Bar"};
    public static string[] gradoviSlo = { "Ljubljana", "Celje", "Koper", "Novo Mesto", "Maribor"};
    public static string[] gradoviMk = { "Skopje", "Bitola", "Tetovo", "Shtip", "Gostivar"};
    public static int radio=0;
    public static int track=0;
    public static float radioVolume=0.5f;
    public static float musicVolume=0.5f;
    public static float window=0f;
    public static bool open=false;
    public static bool start=false;
    public static bool arrive=false;
    public static bool mapCollidersActive=false;
    public static int guy=0;
}
