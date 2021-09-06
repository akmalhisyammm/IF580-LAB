using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/***
 * ICOSAHEDRON
 * Number of Faces      : 20
 * Number of Vertices   : 12
 * Number of Edges      : 30
***/

public class ChallengeOneMuhammadAkmalHisyam : MonoBehaviour
{
    float firstAxisPoint = 0.000000f;
    float secondAxisPoint = 1.314325f;
    float thirdAxisPoint = 2.126625f;

    // Start is called before the first frame update
    void Start()
    {
        Mesh mesh = new Mesh();
        Vector3[] vertices = new Vector3[12];

        vertices[0] = new Vector3(-secondAxisPoint, firstAxisPoint, thirdAxisPoint);
        vertices[1] = new Vector3(secondAxisPoint, firstAxisPoint, thirdAxisPoint);
        vertices[2] = new Vector3(-secondAxisPoint, firstAxisPoint, -thirdAxisPoint);
        vertices[3] = new Vector3(secondAxisPoint, firstAxisPoint, -thirdAxisPoint);
        vertices[4] = new Vector3(firstAxisPoint, thirdAxisPoint, secondAxisPoint);
        vertices[5] = new Vector3(firstAxisPoint, thirdAxisPoint, -secondAxisPoint);
        vertices[6] = new Vector3(firstAxisPoint, -thirdAxisPoint, secondAxisPoint);
        vertices[7] = new Vector3(firstAxisPoint, -thirdAxisPoint, -secondAxisPoint);
        vertices[8] = new Vector3(thirdAxisPoint, secondAxisPoint, firstAxisPoint);
        vertices[9] = new Vector3(-thirdAxisPoint, secondAxisPoint, firstAxisPoint);
        vertices[10] = new Vector3(thirdAxisPoint, -secondAxisPoint, firstAxisPoint);
        vertices[11] = new Vector3(-thirdAxisPoint, -secondAxisPoint, firstAxisPoint);

        mesh.vertices = vertices;
        mesh.triangles = new int[]
        {
            0, 6, 1,
            1, 6, 0, // 1st Face
            
            0, 11, 6,        
            6, 11, 0, // 2nd Face

            1, 4, 0,
            0, 4, 1, // 3rd Face

            1, 8, 4,
            4, 8, 1, // 4th Face

            1, 10, 8,
            8, 10, 1, // 5th Face

            2, 5, 3,
            3, 5, 2, // 6th Face

            2, 9, 5,
            5, 9, 2, // 7th Face

            2, 11, 9,
            9, 11, 2, // 8th Face

            3, 7, 2,
            2, 7, 3, // 9th Face

            3, 10, 7, 
            7, 10, 3, // 10th Face

            4, 8, 5,
            5, 8, 4, // 11th Face

            4, 9, 0,
            0, 9, 4, // 12th Face

            5, 8, 3,
            3, 8, 5, // 13th Face

            5, 9, 4,
            4, 9, 5, // 14th Face

            6, 10, 1,
            1, 10, 6, // 15th Face

            6, 11, 7,
            7, 11, 6, // 16th Face

            7, 10, 6,
            6, 10, 7, // 17th Face

            7, 11, 2,
            2, 11, 7, // 18th Face

            8, 10, 3,
            3, 10, 8, // 19th Face

            9, 11, 0,
            0, 11, 9, // 20th Face
        };

        GetComponent<MeshFilter>().mesh = mesh;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
