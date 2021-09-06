using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChallengeTwoMuhammadAkmalHisyam : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Mesh mesh = new Mesh();
        var vertices = new Vector3[48];

        // Leg (Back Left)
        vertices[0] = new Vector3(0, 0.5f, 0);
        vertices[1] = new Vector3(1, 0.5f, 0);
        vertices[2] = new Vector3(1, 0.5f, 1);
        vertices[3] = new Vector3(0, 0.5f, 1);
        vertices[4] = new Vector3(0, 4, 0);
        vertices[5] = new Vector3(1, 4, 0);
        vertices[6] = new Vector3(1, 4, 1);
        vertices[7] = new Vector3(0, 4, 1);

        // Leg (Back Right)
        vertices[8] = new Vector3(3, 0.5f, 0);
        vertices[9] = new Vector3(4, 0.5f, 0);
        vertices[10] = new Vector3(4, 0.5f, 1);
        vertices[11] = new Vector3(3, 0.5f, 1);
        vertices[12] = new Vector3(3, 4, 0);
        vertices[13] = new Vector3(4, 4, 0);
        vertices[14] = new Vector3(4, 4, 1);
        vertices[15] = new Vector3(3, 4, 1);

        // Leg (Front Left)
        vertices[16] = new Vector3(0, 0.5f, 4);
        vertices[17] = new Vector3(1, 0.5f, 4);
        vertices[18] = new Vector3(1, 0.5f, 5);
        vertices[19] = new Vector3(0, 0.5f, 5);
        vertices[20] = new Vector3(0, 4, 4);
        vertices[21] = new Vector3(1, 4, 4);
        vertices[22] = new Vector3(1, 4, 5);
        vertices[23] = new Vector3(0, 4, 5);

        // Leg (Front Right)
        vertices[24] = new Vector3(3, 0.5f, 4);
        vertices[25] = new Vector3(4, 0.5f, 4);
        vertices[26] = new Vector3(4, 0.5f, 5);
        vertices[27] = new Vector3(3, 0.5f, 5);
        vertices[28] = new Vector3(3, 4, 4);
        vertices[29] = new Vector3(4, 4, 4);
        vertices[30] = new Vector3(4, 4, 5);
        vertices[31] = new Vector3(3, 4, 5);

        // Seat
        vertices[32] = new Vector3(0, 5, 0);
        vertices[33] = new Vector3(4, 5, 0);
        vertices[34] = new Vector3(4, 5, 5);
        vertices[35] = new Vector3(0, 5, 5);
        vertices[42] = new Vector3(0, 4, 0);
        vertices[43] = new Vector3(4, 4, 0);
        vertices[44] = new Vector3(4, 4, 5);
        vertices[45] = new Vector3(0, 4, 5);

        // Backrest
        vertices[36] = new Vector3(4, 5, 4);
        vertices[37] = new Vector3(0, 5, 4);
        vertices[38] = new Vector3(0, 11, 5);
        vertices[39] = new Vector3(4, 11, 5);
        vertices[40] = new Vector3(0, 11, 4);
        vertices[41] = new Vector3(4, 11, 4);
        vertices[46] = new Vector3(0, 5, 5);
        vertices[47] = new Vector3(4, 5, 5);

        mesh.vertices = vertices;

        mesh.triangles = new int[]
        {
            // Leg (Back Left)
            1, 2, 3,
            1, 3, 0,
            0, 4, 5,
            0, 5, 1,
            1, 5, 6,
            1, 6, 2,
            2, 6, 7,
            2, 7, 3,
            3, 7, 4,
            3, 4, 0,
            7, 6, 5,
            7, 5, 4,

            // Leg (Back Right)
            9, 10, 11,
            9, 11, 8,
            8, 12, 13,
            8, 13, 9,
            9, 13, 14,
            9, 14, 10,
            10, 14, 15,
            10, 15, 11,
            11, 15, 12,
            11, 12, 8,
            15, 14, 13,
            15, 13, 12,

            // Leg (Front Left)
            17, 18, 19,
            17, 19, 16,
            16, 20, 21,
            16, 21, 17,
            17, 21, 22,
            17, 22, 18,
            18, 22, 23,
            18, 23, 19,
            19, 23, 20,
            19, 20, 16,
            23, 22, 21,
            23, 21, 20,

            // Leg (Front Right)
            25, 26, 27,
            25, 27, 24,
            24, 28, 29,
            24, 29, 25,
            25, 29, 30,
            25, 30, 26,
            26, 30, 31,
            26, 31, 27,
            27, 31, 28,
            27, 28, 24,
            31, 30, 29,
            31, 29, 28,

            // Seat
            43, 44, 45,
            43, 45, 42,
            44, 34, 35,
            44, 35, 45,
            45, 35, 32,
            45, 32, 42,
            42, 32, 33,
            42, 33, 43,
            43, 33, 34,
            43, 34, 44,
            33, 32, 35,
            33, 35, 34,

            // Backrest
            36, 40, 41,
            36, 37, 40,
            36, 47, 46,
            36, 46, 37,
            37, 38, 40,
            37, 46, 38,
            46, 39, 38,
            46, 47, 39,
            47, 41, 39,
            47, 36, 41,
            39, 40, 38,
            39, 41, 40,
        };

        GetComponent<MeshFilter>().mesh = mesh;

        var colors = new Color32[vertices.Length];

        // Leg (Back Left)
        for (int i = 0; i <= 7; i++)
            colors[i] = new Color32(213, 113, 73, 255);

        // Leg (Back Right)
        for (int i = 8; i <= 15; i++)
            colors[i] = new Color32(213, 113, 73, 255);

        // Leg (Front Left)
        for (int i = 16; i <= 23; i++)
            colors[i] = new Color32(213, 113, 73, 255);

        // Leg (Front Right)
        for (int i = 24; i <= 31; i++)
            colors[i] = new Color32(213, 113, 73, 255);

        // Seat
        for (int i = 32; i <= 35; i++)
            colors[i] = new Color32(170, 74, 48, 255);
        for (int i = 42; i <= 45; i++)
            colors[i] = new Color32(170, 74, 48, 255);

        // Backrest
        for (int i = 36; i <= 41; i++)
            colors[i] = new Color32(232, 159, 113, 255);
        for (int i = 46; i <= 47; i++)
            colors[i] = new Color32(232, 159, 113, 255);

        mesh.colors32 = colors;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
