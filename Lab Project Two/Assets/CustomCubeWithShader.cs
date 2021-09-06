using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomCubeWithShader : MonoBehaviour
{
    // Declaring Material to be recognized in the Inspector
    [SerializeField]
    public Material cubeMaterial;

    // Declaring and initializing values for our mesh
    float width = 1.0f;
    float height = 1.0f;
    float thick = 1.0f;

    // Start is called before the first frame update
    void Start()
    {
        Mesh mesh = new Mesh();
        var vertices = new Vector3[8];

        // First Layer of 4-Vertices Quad
        vertices[0] = new Vector3(-width, -height, thick);
        vertices[1] = new Vector3(-width, height, thick);
        vertices[2] = new Vector3(width, height, thick);
        vertices[3] = new Vector3(width, -height, thick);

        // Second Layer of 4-Vertices Quad
        vertices[4] = new Vector3(-width, -height, -thick);
        vertices[5] = new Vector3(-width, height, -thick);
        vertices[6] = new Vector3(width, height, -thick);
        vertices[7] = new Vector3(width, -height, -thick);

        mesh.vertices = vertices;

        // Declaring colors as much as vertices
        var colors = new Color32[vertices.Length];

        colors[0] = new Color32(255, 0, 0, 255);
        colors[1] = new Color32(0, 255, 0, 255);
        colors[2] = new Color32(0, 0, 255, 255);
        colors[3] = new Color32(255, 0, 255, 255);
        colors[4] = new Color32(255, 0, 0, 255);
        colors[5] = new Color32(0, 255, 0, 255);
        colors[6] = new Color32(0, 0, 255, 255);
        colors[7] = new Color32(255, 0, 255, 255);

        // Assign mesh colors to modified colors variable
        mesh.colors32 = colors;

        mesh.triangles = new int[]
        {
            2, 1, 0,
            3, 2, 0, // First Face
            3, 0, 4,
            4, 7, 3, // Second Face
            3, 6, 2,
            3, 7, 6, // Third Face
            6, 5, 2,
            5, 1, 2, // Fourth Face
            5, 6, 4,
            6, 7, 4, // Fifth Face
            1, 5, 4,
            4, 0, 1  // Sixth Face
        };

        GetComponent<MeshFilter>().mesh = mesh;

        GetComponent<MeshRenderer>().material = cubeMaterial;
    }

    // FixedUpdate is for physics update called per frame
    void FixedUpdate()
    {
        float cubeTime = Time.fixedTime;

        if (cubeTime % 2.0f == 0)
        {
            var mesh = GetComponent<MeshFilter>().mesh;
            var length = mesh.vertices.Length;
            Color32[] colors = new Color32[length];

            for (int i = 0; i < length; i++)
            {
                byte valueR = (byte)(Random.Range(0.0f, 1.0f) * 255);
                byte valueG = (byte)(Random.Range(0.0f, 1.0f) * 255);
                byte valueB = (byte)(Random.Range(0.0f, 1.0f) * 255);
                colors[i] = new Color32(valueR, valueG, valueB, 255);
            }

            mesh.colors32 = colors;
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
