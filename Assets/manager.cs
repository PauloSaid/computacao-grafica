using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class manager : MonoBehaviour {

    public GameObject tetrahedron; // prefab da camrera
    public GameObject[] vetGameObj = new GameObject[24];
    GameObject pai;
    Vector3 m_Center;

    public float rotationSpeed = 120f; 
    public KeyCode rotationBasePivot = KeyCode.F1;
    public KeyCode rotationMeioPivot = KeyCode.F2;
    public KeyCode rotationTopoPivot = KeyCode.F3;
    public KeyCode rotationSolo0Pivot = KeyCode.F4;
    public KeyCode rotationSolo2Pivot = KeyCode.F5;
    public KeyCode rotationSolo7Pivot = KeyCode.F6;

    private GameObject basePivot;
    private GameObject meioPivot;
    private GameObject topoPivot;
    private GameObject solo0Pivot;
    private GameObject solo2Pivot;
    private GameObject solo7Pivot;

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

        // *************** Rotação do meio ***************
        GameObject meioPivot = new GameObject("RotaçãoMeio");
        meioPivot.transform.position = new Vector3(1.5f,1.08125f, 0.8663f);

        // *************** Rotacao Topo ***************
        GameObject topoPivot = new GameObject("RotaçãoTopo");
        topoPivot.transform.position = new Vector3(1.5f, 1.94625f, 0.86675f);


        //Rotações solos serão child das rotações pai para não perder a referencia?


        // *************** Rotacao Diagonal Solo ***************
        GameObject solo0Pivot = new GameObject("RotaçãoDiagonalSolo0");
        solo0Pivot.transform.localPosition = new Vector3(0.5f, 0.21625f, 0.2885f);
        solo0Pivot.transform.SetParent(basePivot.transform);
        
        // *************** Rotacao Diagonal Solo 2 ***************
        GameObject solo2Pivot = new GameObject("RotaçãoDiagonalSolo2");
        solo2Pivot.transform.localPosition = new Vector3(2.5f, 0.21625f, 0.2885f);
        solo2Pivot.transform.SetParent(basePivot.transform);
        
        // *************** Rotacao Diagonal Solo 7 ***************
        GameObject solo7Pivot = new GameObject("RotaçãoDiagonalSolo7");
        solo7Pivot.transform.localPosition = new Vector3(1.5f, 0.21625f, 2.0495f);
        solo7Pivot.transform.SetParent(basePivot.transform);
    }


    //////////////////////////// Rotate ou RotateAround ?????????

	
	// Update is called once per frame
	void Update () {
        if (basePivot == null) basePivot = GameObject.Find("RotaçãoBase");
        if (meioPivot == null) meioPivot = GameObject.Find("RotaçãoMeio");
        if (topoPivot == null) topoPivot = GameObject.Find("RotaçãoTopo");
        if (solo0Pivot == null) solo0Pivot = GameObject.Find("RotaçãoDiagonalSolo0");
        if (solo2Pivot == null) solo2Pivot = GameObject.Find("RotaçãoDiagonalSolo2");
        if (solo7Pivot == null) solo7Pivot = GameObject.Find("RotaçãoDiagonalSolo7");

        if (Input.GetKeyDown(rotationBasePivot))
        {
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

            basePivot.transform.RotateAround(basePivot.transform.position, Vector3.up, 120);

            RemoveParentsFromObjects(new int[] { 0, 1, 2, 13, 14, 10, 11, 12, 9, 16, 17, 6, 7, 19, 20 });
        }
        if (Input.GetKeyDown(rotationMeioPivot))
        {
            // =============== Parede Rosa ===============
            vetGameObj[3].transform.SetParent(meioPivot.transform);
            vetGameObj[4].transform.SetParent(meioPivot.transform);
            vetGameObj[15].transform.SetParent(meioPivot.transform);

            // =============== Parede Vermelha ===============
            vetGameObj[18].transform.SetParent(meioPivot.transform);

            // =============== Parede Amarela ===============
            vetGameObj[8].transform.SetParent(meioPivot.transform);
            vetGameObj[21].transform.SetParent(meioPivot.transform);

            meioPivot.transform.RotateAround(meioPivot.transform.position, Vector3.up, 120);

            RemoveParentsFromObjects(new int[] { 3, 4, 15, 18, 8, 21});
        }
        if (Input.GetKeyDown(rotationTopoPivot))
        {
            // =============== Parede Rosa ===============
            vetGameObj[5].transform.SetParent(topoPivot.transform);

            topoPivot.transform.RotateAround(topoPivot.transform.position, Vector3.up, 120);

            RemoveParentsFromObjects(new int[] { 5 });
        }

        if (Input.GetKeyDown(rotationSolo0Pivot))
        {
            // =============== Parede Rosa ===============
            vetGameObj[0].transform.SetParent(solo0Pivot.transform);

            solo0Pivot.transform.RotateAround(solo0Pivot.transform.position, new Vector3(-0.811f, -0.351f, -0.468f), 120);

            RemoveParentsFromObjects(new int[] { 0 });
        }

        if (Input.GetKey(rotationSolo2Pivot))
        {
            // =============== Parede Rosa ===============
            vetGameObj[2].transform.SetParent(solo2Pivot.transform);

            solo2Pivot.transform.Rotate(new Vector3(0.811f, -0.351f, -0.468f), rotationSpeed * Time.deltaTime);

            RemoveParentsFromObjects(new int[] { 2 });
        }

        if (Input.GetKeyDown(rotationSolo7Pivot))
        {
            // =============== Parede Rosa ===============
            vetGameObj[7].transform.SetParent(solo7Pivot.transform);

            solo7Pivot.transform.RotateAround(solo7Pivot.transform.position, new Vector3(0f, -0.351f, 0.936f), 120);

            RemoveParentsFromObjects(new int[] { 7 });
        }
    }

    void RemoveParentsFromObjects(int[] indices)
    {
        foreach (int index in indices)
        {
            vetGameObj[index].transform.SetParent(null);
        }
    }
}
