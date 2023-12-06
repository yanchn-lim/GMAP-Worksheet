// Uncomment this whole file.

//using Mono.Cecil.Cil;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransformMesh : MonoBehaviour
{

    //declaring all the variables
    [HideInInspector]
    public Vector3[] vertices { get; private set; }

    private HMatrix2D transformMatrix = new HMatrix2D();
    HMatrix2D toOriginMatrix = new HMatrix2D();
    HMatrix2D fromOriginMatrix = new HMatrix2D();
    HMatrix2D rotateMatrix = new HMatrix2D();

    private MeshManager meshManager;
    HVector2D pos = new HVector2D();

    void Start()
    {
        //get the mesh manager component
        meshManager = GetComponent<MeshManager>();

        //getting the vector from unity and turn it into our vector class
        pos = new HVector2D(gameObject.transform.position.x, gameObject.transform.position.y);


        //declare desired transformation here...
        Rotate(45);
    }

    
    void Translate(float x, float y)
    {
        //set the identity matrix first
        transformMatrix.SetIdentity();
        //then we set the translation matrix
        transformMatrix.SetTranslationMat(x,y);

        //call Transform() to apply our translation
        Transform();

        //update our position vector with the transformed position of our mesh
        pos = transformMatrix * pos;
    }

    void Rotate(float angle)
    {
        //set the translation matrix of going to the origin
        toOriginMatrix.SetTranslationMat(-pos.x,-pos.y);
        //set the translation matrix of going back to the original position
        fromOriginMatrix.SetTranslationMat(pos.x, pos.y);
       
        //set the rotation matrix according to the desired angle
        rotateMatrix.SetRotationMat(angle);

        //set the transform matrix's identity
        transformMatrix.SetIdentity();

        //set the sequence of multiplication from
        // translate to origin -> rotate -> translate back to original position
        transformMatrix = toOriginMatrix * rotateMatrix * fromOriginMatrix;

        //apply transformation
        Transform();
    }

    private void Transform()
    {
        //get the mesh's vertices
        vertices = meshManager.clonedMesh.vertices;

        //loop through the vertices
        for (int i = 0; i < vertices.Length; i++)
        {
            //convert from unity's vector to our vector
            HVector2D vert = new HVector2D(vertices[i].x, vertices[i].y);

            //apply the transformation to the vertex
            vert = transformMatrix * vert;

            //apply our vertex into unity's vertex
            vertices[i].x = vert.x;
            vertices[i].y = vert.y;
        }

        //replace the mesh's vertices with our vertices
        meshManager.clonedMesh.vertices = vertices;
    }
}
