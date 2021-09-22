using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshFilter), typeof(MeshRenderer))]
public class ProceduralCube : MonoBehaviour
{
    public int xSize, ySize, zSize;
    public Material material;
    private Vector3[] vertices;
    private Mesh mesh;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Generate());
        material = GetComponent<MeshRenderer>().material;
        material = Resources.Load<Material>("ProceduralCube/Materials/cubetiles");
        material.shader = Shader.Find("Unlit/Texture");
        material.mainTexture = Resources.Load<Texture>("ProceduralCube/Textures/cubetiles");
        GetComponent<MeshRenderer>().material = material;
    }

    // IEnumerator interface to produce vertices one by one in Scene View
    private IEnumerator Generate()
    {
        // Create delay for simulation process
        WaitForSeconds wait = new WaitForSeconds(0.05f);
        GetComponent<MeshFilter>().mesh = mesh = new Mesh();
        mesh.name = "Procedural Cube";

        int cornerVertices = 8;
        int edgeVertices = (xSize + ySize + zSize - 3) * 4;
        int faceVertices = ((xSize - 1) * (ySize - 1) + (xSize - 1) * (zSize - 1) + (ySize - 1) * (zSize - 1)) * 2;

        // Define the number of vertices
        vertices = new Vector3[cornerVertices + edgeVertices + faceVertices];

        // Generate vertices
        int v = 0;
        for (int y = 0; y <= ySize; y++)
        {
            for (int x = 0; x <= xSize; x++)
            {
                vertices[v++] = new Vector3(x, y, 0);
                yield return wait;
            }
            for (int z = 1; z <= zSize; z++)
            {
                vertices[v++] = new Vector3(xSize, y, z);
                yield return wait;
            }
            for (int x = xSize - 1; x >= 0; x--)
            {
                vertices[v++] = new Vector3(x, y, zSize);
                yield return wait;
            }
            for (int z = zSize - 1; z > 0; z--)
            {
                vertices[v++] = new Vector3(0, y, z);
                yield return wait;
            }
        }
        for (int z = 1; z < zSize; z++)
        {
            for (int x = 1; x < xSize; x++)
            {
                vertices[v++] = new Vector3(x, ySize, z);
                yield return wait;
            }
        }
        for (int z = 1; z < zSize; z++)
        {
            for (int x = 1; x < xSize; x++)
            {
                vertices[v++] = new Vector3(x, 0, z);
                yield return wait;
            }
        }

        mesh.vertices = vertices;

        // Create Triangles
        int quads = (xSize * ySize + xSize * zSize + ySize * zSize) * 2;
        int[] triangles = new int[quads * 6];
        int ring = (xSize + zSize) * 2;
        int t = 0;
        v = 0;
        for (int y = 0; y < ySize; y++, v++)
        {
            for (int q = 0; q < ring - 1; q++, v++)
            {
                t = SetQuad(triangles, t, v, v + 1, v + ring, v + ring + 1);
                mesh.triangles = triangles;
                yield return wait;
            }
            t = SetQuad(triangles, t, v, v - ring + 1, v + ring, v + 1);
            mesh.triangles = triangles;
            yield return wait;
        }

        // Create Top Face
        v = ring * ySize;
        for (int x = 0; x < xSize - 1; x++, v++)
        {
            t = SetQuad(triangles, t, v, v + 1, v + ring - 1, v + ring);
            mesh.triangles = triangles;
            yield return wait;
        }
        t = SetQuad(triangles, t, v, v + 1, v + ring - 1, v + 2);
        mesh.triangles = triangles;
        yield return wait;

        int vMin = ring * (ySize + 1) - 1;
        int vMid = vMin + 1;
        int vMax = v + 2;
        for (int z = 1; z < zSize - 1; z++, vMin--, vMid++, vMax++)
        {
            t = SetQuad(triangles, t, vMin, vMid, vMin - 1, vMid + xSize - 1);
            mesh.triangles = triangles;
            yield return wait;
            for (int x = 1; x < xSize - 1; x++, vMid++)
            {
                t = SetQuad(triangles, t, vMid, vMid + 1, vMid + xSize - 1, vMid + xSize);
                mesh.triangles = triangles;
                yield return wait;
            }
            t = SetQuad(triangles, t, vMid, vMax, vMid + xSize - 1, vMax + 1);
            mesh.triangles = triangles;
            yield return wait;
        }
        int vTop = vMin - 2;
        t = SetQuad(triangles, t, vMin, vMid, vTop + 1, vTop);
        mesh.triangles = triangles;
        yield return wait;

        for (int x = 1; x < xSize - 1; x++, vTop--, vMid++)
        {
            t = SetQuad(triangles, t, vMid, vMid + 1, vTop, vTop - 1);
            mesh.triangles = triangles;
            yield return wait;
        }
        t = SetQuad(triangles, t, vMid, vTop - 2, vTop, vTop - 1);
        mesh.triangles = triangles;
        yield return wait;

        // Create Bottom Face
        v = 1;
        vMid = vertices.Length - (xSize - 1) * (zSize - 1);
        t = SetQuad(triangles, t, ring - 1, vMid, 0, 1);
        mesh.triangles = triangles;
        yield return wait;

        for (int x = 1; x < xSize - 1; x++, v++, vMid++)
        {
            t = SetQuad(triangles, t, vMid, vMid + 1, v, v + 1);
            mesh.triangles = triangles;
            yield return wait;
        }
        t = SetQuad(triangles, t, vMid, v + 2, v, v + 1);
        mesh.triangles = triangles;
        yield return wait;

        vMin = ring - 2;
        vMid -= xSize - 2;
        vMax = v + 2;
        for (int z = 1; z < zSize - 1; z++, vMin--, vMid++, vMax++)
        {
            t = SetQuad(triangles, t, vMin, vMid + xSize - 1, vMin + 1, vMid);
            mesh.triangles = triangles;
            yield return wait;
            for (int x = 1; x < xSize - 1; x++, vMid++)
            {
                t = SetQuad(triangles, t, vMid + xSize - 1, vMid + xSize, vMid, vMid + 1);
                mesh.triangles = triangles;
                yield return wait;
            }
            t = SetQuad(triangles, t, vMid + xSize - 1, vMax + 1, vMid, vMax);
            mesh.triangles = triangles;
            yield return wait;
        }

        vTop = vMin - 1;
        t = SetQuad(triangles, t, vTop + 1, vTop, vTop + 2, vMid);
        mesh.triangles = triangles;
        yield return wait;
        for (int x = 1; x < xSize - 1; x++, vTop--, vMid++)
        {
            t = SetQuad(triangles, t, vTop, vTop - 1, vMid, vMid + 1);
            mesh.triangles = triangles;
            yield return wait;
        }
        t = SetQuad(triangles, t, vTop, vTop - 1, vMid, vTop - 2);
        mesh.triangles = triangles;
        yield return wait;
    }

    private static int SetQuad(int[] triangles, int i, int v00, int v10, int v01, int v11)
    {
        triangles[i] = v00;
        triangles[i + 1] = triangles[i + 4] = v01;
        triangles[i + 2] = triangles[i + 3] = v10;
        triangles[i + 5] = v11;
        return i + 6;
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
