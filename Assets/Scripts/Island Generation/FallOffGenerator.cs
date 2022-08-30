using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallOffGenerator
{
    public static float[,] GeneratorFallOffMap(int height, int width)
    {
        float[,] map = new float[height, width];

        for(int i =0; i < height; i++)
        {
            for(int j =0; j < width; j++)
            {
                float x = i / (float)height * 2 - 1;
                float y = j / (float)width * 2 - 1;

                float value = Mathf.Max(Mathf.Abs(x), Mathf.Abs(y));
                map[i,j] = value;
            }
        }
        return map;
    }
}
