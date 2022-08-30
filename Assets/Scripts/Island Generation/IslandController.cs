using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IslandController : MonoBehaviour
{
    public int depth = 20;

    public int width = 256;
    public int height = 256;

    public float Scale = 20f;

    public float offsetX = 100f;
    public float offsetY = 100f;

    float[,] falloffMap;


    public void Awake()
    {
        falloffMap = FallOffGenerator.GeneratorFallOffMap(width, height);

        offsetX = Random.Range(0f, 1000f);
        offsetY = Random.Range(0f, 1000f);

        Terrain terrain = GetComponent<Terrain>();
        terrain.terrainData = GenerateTerrain(terrain.terrainData);
    }

    TerrainData GenerateTerrain(TerrainData terrainData)
    {
        terrainData.heightmapResolution = width;

        terrainData.size = new Vector3(width, depth, height);
        terrainData.SetHeights(0, 0, GenerateHeights());
        return terrainData;
    }

    float[,] GenerateHeights()
    {
        float[,] heights = new float[width, height];
        for(int x = 0; x < width; x++)
        {
            for(int y = 0; y < height; y++)
            {
                heights[x, y] = CalculateHeight(x, y);
                heights[x, y] = Mathf.Clamp01(heights[x, y] - falloffMap[x, y]);
            }
        }

        return heights;
    }

    float CalculateHeight(int x, int y)
    {
        float xCoord = (float)x / width * Scale + offsetX;
        float yCoord = (float)y / height * Scale + offsetY;

        return Mathf.PerlinNoise(xCoord, yCoord);
    }
}
