using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test_daw : MonoBehaviour {

    public GameObject look_draw;

    public float angle;

    public float distance;

    public Material color_material;

	// Use this for initialization
	void Start () {
        look_draw = DrawSectorSolid(transform, transform.position, angle, distance);
        look_draw.transform.parent = this.gameObject.transform;
        look_draw.GetComponent<Renderer>().material = color_material;
        //look_draw.transform.position = Vector3.zero;
    }
	

     //绘制实心扇形  
    public static GameObject DrawSectorSolid(Transform t, Vector3 center, float angle, float radius)
    {
        int pointAmount = 100;//点的数目，值越大曲线越平滑  
        float eachAngle = angle / pointAmount;
        Vector3 forward = t.forward;

        List<Vector3> vertices = new List<Vector3>();
        vertices.Add(center);

        for (int i = 1; i < pointAmount - 1; i++)
        {
            Vector3 pos = Quaternion.Euler(0f, -angle / 2 + eachAngle * (i - 1), 0f) * forward * radius + center;
            vertices.Add(pos);
        }

       return CreateMesh(vertices);
    }


    public static GameObject go;
    public static MeshFilter mf;
    public static MeshRenderer mr;
    public static Shader shader;
    private static GameObject CreateMesh(List<Vector3> vertices)
    {
        int[] triangles;
        Mesh mesh = new Mesh();

        int triangleAmount = vertices.Count - 2;
        triangles = new int[3 * triangleAmount];

        //根据三角形的个数，来计算绘制三角形的顶点顺序（索引）    
        //顺序必须为顺时针或者逆时针    
        for (int i = 0; i < triangleAmount; i++)
        {
            triangles[3 * i] = 0;//固定第一个点    
            triangles[3 * i + 1] = i + 1;
            triangles[3 * i + 2] = i + 2;
        }

        if (go == null)
        {
            go = new GameObject("mesh");
            mf = go.AddComponent<MeshFilter>();
            mr = go.AddComponent<MeshRenderer>();
            shader = Shader.Find("Unlit/Color");
        }

        mesh.vertices = vertices.ToArray();
        mesh.triangles = triangles;

        mf.mesh = mesh;
        mr.material.shader = shader;
        mr.material.color = Color.red;

        return go;
    }
}
