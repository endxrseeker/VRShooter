//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class GrassGeneratorScript : MonoBehaviour
//{
//    public int maxGrass;
//    public int minGrass;
//    public int TileSize;
//    int numOfGrass;

//    public GameObject GrassSpawner;
//    public Material GrassMaterial;
//    public Mesh GrassPref;
//    public List<List<Matrix4x4>> Batches = new List<List<Matrix4x4>>();
//    Vector3 Position, Rotation, Scale;


//    public void Start()
//    {
//        numOfGrass = Random.Range(minGrass, maxGrass + 1);

//        GenerateGrass();
//    }
    
//    void GenerateGrass()
//    {
//        for (int i = 0; i < numOfGrass; i++)
//        {
//            int RandX = Random.Range(-TileSize, TileSize + 1);
//            int RandZ = Random.Range(-TileSize, TileSize + 1);

//            Vector3 RandomPos = new Vector3(RandX, 200, RandZ);

//            GameObject spawner = Instantiate(GrassSpawner, RandomPos, GrassSpawner.transform.rotation, this.gameObject.transform);

//            RaycastHit hit;
//            if(Physics.Raycast(spawner.transform.position, -spawner.transform.up, out hit))
//            {
//                if(hit.collider.gameObject.tag == "Terrain")
//                {
//                    Matrix[0] = Matrix4x4.TRS(Position, Quaternion.Euler(Rotation), Scale);


//                    Graphics.DrawMeshInstanced(GrassPref, 0, GrassMaterial, Matrix);
//                }
//                else Destroy(spawner);
//            }
//        }
//    }
//}
