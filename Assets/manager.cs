using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class manager : MonoBehaviour {


    //Paulo e Lugon: Tentativa para encaixar os de cabeca para baixo: criar um game object no meio ou na ponta que tenha sentido do triangulo e usar ele para rotaacionar o trinagulo

    public GameObject tetrahedron; // prefab da camrera
    public GameObject[] vetGameObj = new GameObject[24];
    GameObject pai;
    Vector3 m_Center;


    //O q isso que isso faz? Código do Saulo
    //public Transform verticeSuperior;
    //public Transform verticeA, verticeB, verticeC;
    //public Transform tetraedro1, tetraedro2, tetraedro3;

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


        // =============== Parede Rosa ===============
        vetGameObj[0].transform.position = new Vector3(0f, 0f, 0f);
        vetGameObj[1].transform.position = new Vector3(1f, 0f, 0f);
        vetGameObj[2].transform.position = new Vector3(2f, 0f, 0f);
        vetGameObj[3].transform.position = new Vector3(0.5f, 0.865f, 0.289f);
        vetGameObj[4].transform.position = new Vector3(1.5f, 0.865f, 0.289f);
        vetGameObj[5].transform.position = new Vector3(1f, 1.73f, 0.578f);
        vetGameObj[13].transform.position = new Vector3(1.5f, 0.865f, 0.289f);
        vetGameObj[13].transform.Rotate(37f, 0f, 180f);
        vetGameObj[14].transform.position = new Vector3(2.5f, 0.865f, 0.289f);
        vetGameObj[14].transform.Rotate(37f, 0f, 180f);
        vetGameObj[15].transform.position = new Vector3(2f, 1.73f, 0.578f);
        vetGameObj[15].transform.Rotate(37f, 0f, 180f);

        // =============== Parede Amarela ===============
        vetGameObj[6].transform.position = new Vector3(1.5f, 0f, 0.865f);
        vetGameObj[7].transform.position = new Vector3(1f, 0f, 1.732f);
        vetGameObj[8].transform.position = new Vector3(1f, 0.865f, 1.155f);
        vetGameObj[19].transform.position = new Vector3(1.658f, 0.35f, 0.364f);
        vetGameObj[19].transform.Rotate(-162.396f, -55.452f, -32.63599f);
        vetGameObj[20].transform.position = new Vector3(1.161f, 0.35f, 1.236f);
        vetGameObj[20].transform.Rotate(-162.396f, -55.452f, -32.63599f);
        vetGameObj[21].transform.position = new Vector3(1.147f, 1.22f, 0.651f);
        vetGameObj[21].transform.Rotate(-162.396f, -55.452f, -32.63599f);

        // =============== Parede Vermelha ===============
        vetGameObj[9].transform.position = new Vector3(0.5f, 0f, 0.865f);
        vetGameObj[16].transform.position = new Vector3(0.5f, 0.865f, 0.289f);
        vetGameObj[16].transform.Rotate(40f, -38f, -45f);
        vetGameObj[17].transform.position = new Vector3(1f, 0.865f, 1.154f);
        vetGameObj[17].transform.Rotate(40f, -38f, -45f);
        vetGameObj[18].transform.position = new Vector3(1f, 1.73f, 0.578f);
        vetGameObj[18].transform.Rotate(40f, -38f, -45f);

        // =============== Face Azul ===============
        vetGameObj[10].transform.position = new Vector3(0.5f, 0f, 0.865f);
        vetGameObj[10].transform.Rotate(0f, 60f, 0f);
        vetGameObj[11].transform.position = new Vector3(1.5f, 0f, 0.865f);
        vetGameObj[11].transform.Rotate(0f, 60f, 0f);
        vetGameObj[12].transform.position = new Vector3(1f, 0f, 1.732f);
        vetGameObj[12].transform.Rotate(0f, 60f, 0f);


        // *************** Rotação da base ***************
        GameObject basePivot = new GameObject("RotaçãoBase");
        basePivot.transform.position = new Vector3(1.5f, 0f, 0.87561f);

        // =============== Parede Rosa ===============
        vetGameObj[0].transform.SetParent(basePivot.transform);
        vetGameObj[1].transform.SetParent(basePivot.transform);
        vetGameObj[2].transform.SetParent(basePivot.transform);
        vetGameObj[13].transform.SetParent(basePivot.transform);
        vetGameObj[14].transform.SetParent(basePivot.transform);

        // =============== Face Azul ===============
        vetGameObj[10].transform.SetParent(basePivot.transform);
        vetGameObj[11].transform.SetParent(basePivot.transform);
        vetGameObj[12].transform.SetParent(basePivot.transform);

        // =============== Parede Vermelha ===============
        vetGameObj[9].transform.SetParent(basePivot.transform);
        vetGameObj[16].transform.SetParent(basePivot.transform);
        vetGameObj[17].transform.SetParent(basePivot.transform);

        // =============== Parede Amarela ===============
        vetGameObj[6].transform.SetParent(basePivot.transform);
        vetGameObj[7].transform.SetParent(basePivot.transform);
        vetGameObj[19].transform.SetParent(basePivot.transform);
        vetGameObj[20].transform.SetParent(basePivot.transform);

        // *************** Rotação do meio ***************
        GameObject meioPivot = new GameObject("RotaçãoMeio");
        meioPivot.transform.position = new Vector3(1.5f,1.08125f, 0.8663f);

        // =============== Parede Rosa ===============
        vetGameObj[3].transform.SetParent(meioPivot.transform);
        vetGameObj[4].transform.SetParent(meioPivot.transform);
        vetGameObj[15].transform.SetParent(meioPivot.transform);

        // =============== Parede Vermelha ===============
        vetGameObj[18].transform.SetParent(meioPivot.transform);

        // =============== Parede Amarela ===============
        vetGameObj[8].transform.SetParent(meioPivot.transform);
        vetGameObj[21].transform.SetParent(meioPivot.transform);

        // *************** Rotacao Topo ***************
        GameObject topoPivot = new GameObject("RotaçãoTopo");
        topoPivot.transform.position = new Vector3(1.5f, 1.94625f, 0.86675f);

        // =============== Parede Rosa ===============
        vetGameObj[5].transform.SetParent(topoPivot.transform);


        //O q isso que isso faz? Código do Saulo
        //Vector3 eixoVertical = (verticeSuperior.position - ((verticeA.position + verticeB.position + verticeC.position) / 3f)).normalized;

        //basePivot.transform.Rotate(eixoVertical, 120f, Space.World);




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
