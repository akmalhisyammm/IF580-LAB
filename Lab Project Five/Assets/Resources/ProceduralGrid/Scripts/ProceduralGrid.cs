using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshFilter), typeof(MeshRenderer))]
public class ProceduralGrid : MonoBehaviour
{
    public int xSize, ySize;
    public Material material;
    private Vector3[] vertices;
    private Mesh mesh;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Generate());
        material = GetComponent<MeshRenderer>().material;
        material = Resources.Load<Material>("ProceduralGrid/Materials/UV");
        material.shader = Shader.Find("Unlit/Texture");
        material.mainTexture = Resources.Load<Texture>("ProceduralGrid/Textures/UV");
    }

    // IEnumerator interface to produce vertices one by one in Scene View
    private IEnumerator Generate()
    {
        // Create delay for simulation process
        WaitForSeconds wait = new WaitForSeconds(0.3f);
        GetComponent<MeshFilter>().mesh = mesh = new Mesh();
        mesh.name = "Procedural Grid";

        // Define the number of vertices
        vertices = new Vector3[(xSize + 1) * (ySize + 1)];

        // Declare UVs vector and tangent vector
        Vector2[] uv = new Vector2[vertices.Length];

        // Declare Tangent Vector
        Vector4[] tangents = new Vector4[vertices.Length];

        // Define Tangent Direction
        Vector4 tangent = new Vector4(1f, 1f, 0f, -1f);

        // Generating vertices in 2D planar
        for (int i = 0, y = 0; y <= ySize; y++)
        {
            for (int x = 0; x <= xSize; x++, i++)
            {
                // Defining vertices by procedural approach
                vertices[i] = new Vector3(x, y);
                // Defining UVs vectors by procedural approach
                uv[i] = new Vector2((float)x / xSize, (float)y / ySize);
                // Defining tangents by procedural approach
                tangents[i] = tangent;
                // Wait for given time to simulate
                yield return wait;
            }
        }

        mesh.vertices = vertices;
        mesh.uv = uv;

        // Procedurally generated triangles
        int[] triangles = new int[xSize * ySize * 6];
        for (int ti = 0, vi = 0, y = 0; y < ySize; y++, vi++)
        {
            for (int x = 0; x < xSize; x++, ti += 6, vi++)
            {
                triangles[ti] = vi;
                triangles[ti + 3] = triangles[ti + 2] = vi + 1;
                triangles[ti + 4] = triangles[ti + 1] = vi + xSize + 1;
                triangles[ti + 5] = vi + xSize + 2;
                mesh.triangles = triangles;
                yield return wait;
            }
        }

        // Assigning Normals and Tangents
        mesh.tangents = tangents;
        mesh.RecalculateNormals();
    }

    // OnDrawGizmoz function to make visual cues in Scene View
    private void OnDrawGizmos()
    {
        if (vertices != null)
        {
            Gizmos.color = Color.black;
            for (int i = 0; i < vertices.Length; i++)
            {
                Gizmos.DrawSphere(vertices[i], 0.1f);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
