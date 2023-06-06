using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CallPieChart : MonoBehaviour
{
    public void SonrakiSoru()
    {
        GetComponent<PieChart>().soruSayisi += 1;
    }

    public void GenerateRandomPieChart()
    {
        float[] values = new float[6];

        for(int i = 0; i < values.Length; i++)
        {
            values[i] = Random.Range(10.0f, 100.0f);
        }

        GetComponent<PieChart>().SetValues(values);
    }
}
