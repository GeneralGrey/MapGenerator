using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//[RequireComponent (typeof = MeshFilter)]
public class ChunkObject : MonoBehaviour
{
    Mesh mesh;
    MeshCollider meshCollider;
    public int Size = 5;
    public TileObject[] Tiles;
    List<Vector3> verticies = new List<Vector3>();
    List<int> triangles = new List<int>();
    private void Awake()
    {

        Tiles = new TileObject[Size * Size];
        for (int y = 0; y < Size; y++)
            for (int x = 0; x < Size; x++)
            {
                Tiles[y * Size + x] = new TileObject(new Vector3(x, 0, y));
            }
        mesh = GetComponent<MeshFilter>().mesh = new Mesh(); ;
        meshCollider = GetComponent<MeshCollider>();
        
    }

    public TileObject GetTile(int x, int y)
    {
        if (y * Size + x > Size * Size)
            return null;
        return Tiles[y * Size + x]; ;
    }
   

    public void GenerateMesh()
    {
        mesh.Clear();
        verticies.Clear();
        triangles.Clear();
        verticies.Clear();
        
        for (int y = 0; y < Size; y++)
            for (int x = 0; x < Size; x++)
            {
                TileObject t = GetTile(x, y);

                t.GenerateMesh(verticies.Count);
                verticies.AddRange(t.GetVerticies());
                triangles.AddRange(t.GetTriangles());
            }

        mesh.vertices = verticies.ToArray();
        mesh.triangles = triangles.ToArray();
        mesh.RecalculateNormals();
        meshCollider.sharedMesh = mesh;
       
    }

}
