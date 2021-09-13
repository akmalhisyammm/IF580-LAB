using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomCubeWithShader : MonoBehaviour
{
    // Declaring Material to be recognized in the Inspector
    [SerializeField]
    public Material cubeMaterial;

    // Declaring Texture
    public Texture myTexture;

    // Declaring and initializing values for our mesh
    float width = 1.0f;
    float height = 1.0f;
    float thick = 1.0f;

    // Start is called before the first frame update
    void Start()
    {
        // Initialize Mesh, Vertices, and UVs
        Mesh mesh = new Mesh();
        var vertices = new Vector3[24];
        var uvs = new Vector2[vertices.Length];

        // Load Texture
        myTexture = Resources.Load<Texture>("Textures/cubetiles");
        // Set Texture to Material
        cubeMaterial.mainTexture = myTexture;

        // First surface towards X-Positive
        vertices[0] = new Vector3(width, height, thick);
        vertices[1] = new Vector3(width, -height, thick);
        vertices[2] = new Vector3(width, height, -thick);
        vertices[3] = new Vector3(width, -height, -thick);

        // First Tile UVs coordinate in the bottom left corner
        uvs[0] = new Vector2(0.0f, 0.5f);
        uvs[1] = new Vector2(0.25f, 0.5f);
        uvs[2] = new Vector2(0.0f, 0.0f);
        uvs[3] = new Vector2(0.25f, 0.0f);

        // Second surface towards Y-Positive
        vertices[4] = new Vector3(width, height, thick);
        vertices[5] = new Vector3(-width, height, thick);
        vertices[6] = new Vector3(width, height, -thick);
        vertices[7] = new Vector3(-width, height, -thick);

        // Second Tile UVs coordinate in the top left corner
        uvs[4] = new Vector2(0.0f, 1.0f);
        uvs[5] = new Vector2(0.25f, 1.0f);
        uvs[6] = new Vector2(0.0f, 0.5f);
        uvs[7] = new Vector2(0.25f, 0.5f);

        // Third surface towards Z-Positive
        vertices[8] = new Vector3(width, height, thick);
        vertices[9] = new Vector3(-width, height, thick);
        vertices[10] = new Vector3(width, -height, thick);
        vertices[11] = new Vector3(-width, -height, thick);

        // Third Tile UVs coordinate in the center bottom left corner
        uvs[8] = new Vector2(0.25f, 0.5f);
        uvs[9] = new Vector2(0.5f, 0.5f);
        uvs[10] = new Vector2(0.25f, 0.0f);
        uvs[11] = new Vector2(0.5f, 0.0f);

        // Fourth surface towards X-Negative
        vertices[12] = new Vector3(-width, height, thick);
        vertices[13] = new Vector3(-width, -height, thick);
        vertices[14] = new Vector3(-width, height, -thick);
        vertices[15] = new Vector3(-width, -height, -thick);

        // Fourth Tile UVs coordinate in the center top left corner
        uvs[12] = new Vector2(0.25f, 1.0f);
        uvs[13] = new Vector2(0.5f, 1.0f);
        uvs[14] = new Vector2(0.25f, 0.5f);
        uvs[15] = new Vector2(0.5f, 0.5f);

        // Fifth surface towards Y-Negative
        vertices[16] = new Vector3(width, -height, thick);
        vertices[17] = new Vector3(-width, -height, thick);
        vertices[18] = new Vector3(width, -height, -thick);
        vertices[19] = new Vector3(-width, -height, -thick);

        // Fifth Tile UVs coordinate in the center bottom right corner
        uvs[16] = new Vector2(0.5f, 0.5f);
        uvs[17] = new Vector2(0.75f, 0.5f);
        uvs[18] = new Vector2(0.5f, 0.0f);
        uvs[19] = new Vector2(0.75f, 0.0f);

        // Sixth surface towards Z-Negative
        vertices[20] = new Vector3(width, height, -thick);
        vertices[21] = new Vector3(-width, height, -thick);
        vertices[22] = new Vector3(width, -height, -thick);
        vertices[23] = new Vector3(-width, -height, -thick);

        // Sixth Tile UVs coordinate in the center top right corner
        uvs[20] = new Vector2(0.5f, 1.0f);
        uvs[21] = new Vector2(0.75f, 1.0f);
        uvs[22] = new Vector2(0.5f, 0.5f);
        uvs[23] = new Vector2(0.75f, 0.5f);

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
        // Assign mesh UVs
        mesh.uv = uvs;

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
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // Switch the Texture's Filter Mode
            myTexture.filterMode = SwitchFilterModes();

            // Output the current Filter Mode to the console
            Debug.Log("Filter mode : " + myTexture.filterMode);
        }
    }

    FilterMode SwitchFilterModes()
    {
        // Switch the Filter Mode of the Texture when user clicks the Button
        switch (myTexture.filterMode)
        {
            // If the FilterMode is currently Bilinear, switch it to Point
            case FilterMode.Bilinear:
                myTexture.filterMode = FilterMode.Point;
                break;

            // If the FilterMode is currenty Point, switch it to Trilinear
            case FilterMode.Point:
                myTexture.filterMode = FilterMode.Trilinear;
                break;

            // If the FilterMode is currenty Trilinear, switch it to Bilinear
            case FilterMode.Trilinear:
                myTexture.filterMode = FilterMode.Bilinear;
                break;
        }

        // Return the new Texture FilterMode
        return myTexture.filterMode;
    }
}
