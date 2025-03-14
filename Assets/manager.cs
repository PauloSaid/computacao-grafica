using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class manager : MonoBehaviour {

    public GameObject tetrahedron; // prefab da camrera
    public GameObject[] vetGameObj = new GameObject[24];
    GameObject pai;
    Vector3 m_Center;
	// Use this for initialization
	void Start () {
		for(int i=0; i < 24; i++)
        {
            if(i == 0)
            {
                vetGameObj[i] = Instantiate(tetrahedron, new Vector3(0, 0, 0), Quaternion.identity); // tetraedro base
            }
            else
                vetGameObj[i]= Instantiate(tetrahedron, new Vector3(vetGameObj[i-1].transform.position.x + 1, 0, 0), vetGameObj[i - 1].transform.rotation);
            //i-1 posicao anterior
        }
        
        //Parede Rosa
        vetGameObj[3].transform.position = new Vector3(0.5f, 0.86603f, 0.28868f);
        vetGameObj[4].transform.position = new Vector3(1.5f, 0.86603f, 0.28868f);
        vetGameObj[5].transform.position = new Vector3(1.0f, 1.73206f, 0.57736f);
        vetGameObj[6].transform.position = new Vector3(2.5f, 0.86565f, 0.2836585f);
        vetGameObj[6].transform.Rotate(36.396f, 0f, -180f);
        vetGameObj[7].transform.position = new Vector3(1.5f, 0.86565f, 0.2836585f);
        vetGameObj[7].transform.Rotate(36.396f, 0f, -180f);
        vetGameObj[8].transform.position = new Vector3(2f, 1.738f, 0.59f);
        vetGameObj[8].transform.Rotate(37.293f, 0f, -180f);
        
        // Parede Amarela
        vetGameObj[9].transform.position = new Vector3(1.496f, 0f, 0.862f);
        vetGameObj[10].transform.position = new Vector3(1f, 0f, 1.725f);
        vetGameObj[11].transform.position = new Vector3(0.994f, 0.866f, 1.15f);

        //Parede Vermelha
        vetGameObj[12].transform.position = new Vector3(0.503f, 0f, 0.866f);
        vetGameObj[16].transform.position = new Vector3(0.5f,0.861f, 0.287f);
        vetGameObj[16].transform.Rotate(38.5f, -38.364f, -45.658f);

        //Parede Azul
        vetGameObj[13].transform.position = new Vector3(2.5f, 0f, 0.866f);
        vetGameObj[13].transform.Rotate(0f, 180f, 0f);
        vetGameObj[14].transform.position = new Vector3(1.5f, 0f, 0.866f);
        vetGameObj[14].transform.Rotate(0f, 180f, 0f);
        vetGameObj[15].transform.position = new Vector3(2f, 0f, 1.725f);
        vetGameObj[15].transform.Rotate(0f, 180f, 0f);




        //vetGameObj[3].transform.Rotate(110f,0f,0); // 90f
        // vetGameObj[3].transform.RotateAround(transform.position, Vector3.forward, 5f);

        pai = new GameObject();
        //pai.transform.position = new Vector3(0,1,0); //pivo
        //vetGameObj[3].transform.parent = pai.transform;
        //vetGameObj[3].transform.bounds
    }

	
	// Update is called once per frame
	void Update () {
		//vetGameObj[3].transform.RotateAround(transform.position, Vector3.forward, 5f);
        //cria um gameobject: Pai. Tem eixo de rotacao
        //por o objeto como filho deste gameobject
        //rotaciona o gameObjet(pai): consequencia o filho rotaciona
        //Instantiate(Object original, Vector3 position, Quaternion rotation, Transform parent);
        //pai.transform.Rotate(Vector3.right * 5);
        //vetGameObj[4].transform.Rotate((Vector3.right + Vector3.up) * 5);
	}
}
