using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomCubeWithShader : MonoBehaviour
{
    // Declaring Material to be recognized in the Inspector
    [SerializeField]
    public Material cubeMaterial;

    // Declaring Spin Speed and Rotation Amount
    public int spinSpeed;
    public Vector3 RotateAmount;

    // Declaring and initializing values for our mesh
    float width = 1.0f;
    float height = 1.0f;
    float thick = 1.0f;

    // Start is called before the first frame update
    void Start()
    {
        // Gives initial value for speed and rotation amount
        spinSpeed = 4;
        RotateAmount = new Vector3(0.0f, 50.0f, 0.0f);

        Mesh mesh = new Mesh();
        var vertices = new Vector3[24];

        // First surface towards X-Positive
        vertices[0] = new Vector3(width, height, thick);
        vertices[1] = new Vector3(width, -height, thick);
        vertices[2] = new Vector3(width, height, -thick);
        vertices[3] = new Vector3(width, -height, -thick);

        // Second surface towards Y-Positive
        vertices[4] = new Vector3(width, height, thick);
        vertices[5] = new Vector3(-width, height, thick);
        vertices[6] = new Vector3(width, height, -thick);
        vertices[7] = new Vector3(-width, height, -thick);

        // Third surface towards Z-Positive
        vertices[8] = new Vector3(width, height, thick);
        vertices[9] = new Vector3(-width, height, thick);
        vertices[10] = new Vector3(width, -height, thick);
        vertices[11] = new Vector3(-width, -height, thick);

        // Fourth surface towards X-Negative
        vertices[12] = new Vector3(-width, height, thick);
        vertices[13] = new Vector3(-width, -height, thick);
        vertices[14] = new Vector3(-width, height, -thick);
        vertices[15] = new Vector3(-width, -height, -thick);

        // Fifth surface towards Y-Negative
        vertices[16] = new Vector3(width, -height, thick);
        vertices[17] = new Vector3(-width, -height, thick);
        vertices[18] = new Vector3(width, -height, -thick);
        vertices[19] = new Vector3(-width, -height, -thick);

        // Sixth surface towards Z-Negative
        vertices[20] = new Vector3(width, height, -thick);
        vertices[21] = new Vector3(-width, height, -thick);
        vertices[22] = new Vector3(width, -height, -thick);
        vertices[23] = new Vector3(-width, -height, -thick);

        mesh.vertices = vertices;

        // Declaring colors as much as vertices
        var colors = new Color32[vertices.Length];

        // Color for surface towards X-Positive
        colors[0] = new Color32(128, 128, 128, 255);
        colors[1] = new Color32(128, 128, 128, 255);
        colors[2] = new Color32(128, 128, 128, 255);
        colors[3] = new Color32(128, 128, 128, 255);

        // Color for surface towards Y-Positive
        colors[4] = new Color32(128, 128, 128, 255);
        colors[5] = new Color32(128, 128, 128, 255);
        colors[6] = new Color32(128, 128, 128, 255);
        colors[7] = new Color32(128, 128, 128, 255);

        // Color for surface towards Z-Positive
        colors[8] = new Color32(128, 128, 128, 255);
        colors[9] = new Color32(128, 128, 128, 255);
        colors[10] = new Color32(128, 128, 128, 255);
        colors[11] = new Color32(128, 128, 128, 255);

        // Color for surface towards X-Negative
        colors[12] = new Color32(128, 128, 128, 255);
        colors[13] = new Color32(128, 128, 128, 255);
        colors[14] = new Color32(128, 128, 128, 255);
        colors[15] = new Color32(128, 128, 128, 255);

        // Color for surface towards Y-Negative
        colors[16] = new Color32(128, 128, 128, 255);
        colors[17] = new Color32(128, 128, 128, 255);
        colors[18] = new Color32(128, 128, 128, 255);
        colors[19] = new Color32(128, 128, 128, 255);

        // Color for surface towards Z-Negative
        colors[20] = new Color32(128, 128, 128, 255);
        colors[21] = new Color32(128, 128, 128, 255);
        colors[22] = new Color32(128, 128, 128, 255);
        colors[23] = new Color32(128, 128, 128, 255);

        // Assign mesh colors to modified colors variable
        mesh.colors32 = colors;

        mesh.triangles = new int[]
        {
            2, 0, 1,
            2, 1, 3, // First Surface towards X Positive
            6, 7, 5,
            4, 6, 5, // Second Surface towards Y Positive
            8, 9, 11,
            8, 11, 10, // Third Surface towards Z Positive
            12, 14, 13,
            14, 15, 13, // Fourth Surface towards X Negative
            19, 18, 17,
            18, 16, 17, // Fifth Surface towards Y Negative
            21, 20, 23,
            20, 22, 23, // Sixth Surface towards Z Negative
        };

        mesh.RecalculateNormals();

        GetComponent<MeshFilter>().mesh = mesh;

        GetComponent<MeshRenderer>().material = cubeMaterial;
    }

    // Update is called once per frame
    void Update()
    {
        // Spin the Cube
        transform.Rotate(RotateAmount * Time.deltaTime / spinSpeed);

        foreach (Vector3 normal in GetComponent<MeshFilter>().mesh.normals)
        {
            Debug.Log(normal.x + " " + normal.y + " " + normal.z);
        }
    }
}
