using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PieChart : MonoBehaviour
{
    public Image[] imagesPieChart;
    public float[] values;
    public Image[] imagesPieChart2;
    public float[] values2;

    public InputField cevap1Text;
    public InputField cevap2Text;
    public InputField cevap3Text;
    public InputField cevap4Text;

    [Header("Cevap")]
    public int dogru;
    public int yanlis;

    private string cevap1;
    private string cevap2;
    private string cevap3;
    private string cevap4;

    public int soruSayisi;

    public Text dogruText;
    public Text yanlisText;
    public Text oyunSonuDogruText;
    public Text oyunSonuYanlisText;

    public Text uyariText;

    public GameObject oyunSonu;

    void Start()
    {
        oyunSonu.SetActive(false);
        uyariText.gameObject.SetActive(false);
    }

    void Update()
    {
        dogruText.text = dogru.ToString();
        yanlisText.text = yanlis.ToString();
        oyunSonuDogruText.text = dogru.ToString();
        oyunSonuYanlisText.text = yanlis.ToString();

        switch (soruSayisi)
        {
            case 1:
                values[0] = 50;
                values[1] = 30;
                values[2] = 40;
                values[3] = 25;
                values[4] = 70;
                values[5] = 24;

                values2[0] = 25;
                values2[1] = 41;
                values2[2] = 35;
                values2[3] = 18;
                values2[4] = 60;
                values2[5] = 47;

                cevap1 = "Komedi";
                cevap2 = "Bilimkurgu";
                cevap3 = "Aksiyon";
                cevap4 = "Dram";
                break;
            case 2:
                values[0] = 40;
                values[1] = 56;
                values[2] = 30;
                values[3] = 45;
                values[4] = 20;
                values[5] = 14;

                values2[0] = 55;
                values2[1] = 31;
                values2[2] = 15;
                values2[3] = 28;
                values2[4] = 50;
                values2[5] = 37;

                cevap1 = "Dram";
                cevap2 = "Korku";
                cevap3 = "Animasyon";
                cevap4 = "Bilimkurgu";
                break;
            case 3:
                values[0] = 25;
                values[1] = 33;
                values[2] = 60;
                values[3] = 34;
                values[4] = 46;
                values[5] = 20;

                values2[0] = 35;
                values2[1] = 30;
                values2[2] = 34;
                values2[3] = 50;
                values2[4] = 35;
                values2[5] = 10;

                cevap1 = "Animasyon";
                cevap2 = "Aksiyon";
                cevap3 = "Bilimkurgu";
                cevap4 = "Komedi";
                break;
        }

        SetValues(values);
        SetValues2(values2);

        if (soruSayisi >= 4)
        {
            Time.timeScale = 0f;
            oyunSonu.SetActive(true);
        }
    }

    public void SetValues(float[] valuesToSet)
    {
        float totalValues = 0;
        for(int i = 0; i < imagesPieChart.Length; i++)
        {
            totalValues += FindPercentage(valuesToSet, i);
            imagesPieChart[i].fillAmount = totalValues;
        }
    }

    public void SetValues2(float[] valuesToSet)
    {
        float totalValues = 0;
        for (int i = 0; i < imagesPieChart2.Length; i++)
        {
            totalValues += FindPercentage(valuesToSet, i);
            imagesPieChart2[i].fillAmount = totalValues;
        }
    }

    private float FindPercentage(float[] valueToSet, int index)
    {
        float totalAmount = 0;
        for (int i = 0; i < valueToSet.Length; i++)
        {
            totalAmount += valueToSet[i];
        }

        return valueToSet[index] / totalAmount;
    }

    public void SonrakiSoru()
    {
        if (cevap1Text.text != "" && cevap2Text.text != null && cevap3Text.text != null && cevap4Text.text != null)
        {
            if(cevap1Text.text == cevap1)
            {
                dogru += 1;
            }
            else
            {
                yanlis += 1;
            }

            if (cevap2Text.text == cevap2)
            {
                dogru += 1;
            }
            else
            {
                yanlis += 1;
            }

            if (cevap3Text.text == cevap3)
            {
                dogru += 1;
            }
            else
            {
                yanlis += 1;
            }

            if (cevap4Text.text == cevap4)
            {
                dogru += 1;
            }
            else
            {
                yanlis += 1;
            }

            cevap1Text.text = "";
            cevap2Text.text = "";
            cevap3Text.text = "";
            cevap4Text.text = "";

            soruSayisi += 1;

            uyariText.gameObject.SetActive(false);
        }
        else
        {
            uyariText.gameObject.SetActive(true);
        }
    }

    public void TekrarButton()
    {
        SceneManager.LoadScene("Game");
        Time.timeScale = 1f;
    }

    public void KapatButton()
    {
        Application.Quit();
    }
}
