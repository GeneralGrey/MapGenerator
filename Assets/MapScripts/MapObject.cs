using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapObject : MonoBehaviour
{
    public GameObject ChunkPrefab;
    List<ChunkObject> Chunks = new List<ChunkObject>();
    // Start is called before the first frame update
    void Start()
    {
        ChunkObject chunk = GameObject.Instantiate(ChunkPrefab).GetComponent<ChunkObject>();
        chunk.GenerateMesh();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
