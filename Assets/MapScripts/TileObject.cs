using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileObject 
{
    public Color MyColor;
    List<Vector3> verticies = new List<Vector3>();
    List<Color> colors = new List<Color>();
    List<int> triangles = new List<int>();
    Vector3 position = Vector3.zero;
    enum directions { N,NE,E,SE,S,SW,W,NW}
    TileObject[] neighbours = new TileObject[8];
    int startIndex = 0;
    public TileObject(Vector3 _position, Color c)
    {
        position = _position;
        MyColor = c;
    }
   public void GenerateMesh(int index)
   {
        GenerateAllVerticies();
        startIndex = index;
        GenerateAllTriangles();
    }

    public List<Vector3> GetVerticies()
    {

        return verticies;
    }
    public List<int> GetTriangles()
    {
        return triangles;
    }
    public void GenerateAllVerticies()
    {
        AddVertex(0, 0, 0);        //0
        AddVertex(-.5f, 0, -.5f);  //1
        AddVertex(-.25f, 0, -.5f); //2
        AddVertex(.25f, 0, -.5f);  //3
        AddVertex(.5f, 0, -.5f);   //4

        AddVertex(-.5f, 0, -.25f); //5
        AddVertex(-.25f, 0, -.25f);//6
        AddVertex(.25f, 0, -.25f); //7
        AddVertex(.5f, 0, -.25f);  //8
        
        AddVertex(-.5f, 0, +.25f); //9
        AddVertex(-.25f, 0, +.25f);//10
        AddVertex(.25f, 0, +.25f); //11
        AddVertex(.5f, 0, +.25f);  //12

        AddVertex(-.5f, 0, +.5f);  //13
        AddVertex(-.25f, 0, +.5f); //14
        AddVertex(.25f, 0, +.5f);  //15
        AddVertex(.5f, 0, +.5f);   //16
    }
    void GenerateAllTriangles()
    {
        //Center
        AddTriangle(0, 7, 6);
        AddTriangle(0, 6, 10);
        AddTriangle(0, 10, 11);
        AddTriangle(0, 11, 7);

        //TopLeft
        AddTriangle(1, 6, 2);
        AddTriangle(1,5,6);

        //Top Right
        AddTriangle(4,3,7);
        AddTriangle(4,7,8);

        //Bot Left
        AddTriangle(13,10,9);
        AddTriangle(13,14,10);

        //Bot Right
        AddTriangle(16,12,11);
        AddTriangle(16,11,15);

        //Top
        AddTriangle(2,6,3);
        AddTriangle(3,6,7);

        //Right
        AddTriangle(8,7,12);
        AddTriangle(7,11,12);

        //Bot
        AddTriangle(14,11,10);
        AddTriangle(14,15,11);

        //Left
        AddTriangle(5,10,6);
        AddTriangle(5,9,10);




    }
    public void AddVertex(float x, float y, float z)
    {
        verticies.Add(position + new Vector3(x, y, z));
    }
    public void AddTriangle(int a, int b, int c)
    {
        triangles.Add(startIndex+a);
        triangles.Add(startIndex+b);
        triangles.Add(startIndex + c);

    }
    public void AddQuad()
    {

    }
        
        
}
