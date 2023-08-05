using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class atomcollector : MonoBehaviour
{
    //Creates a list for atom order, comparelist, atom list this will allow me to randomly create the atomorder and than compare that to the user collection
    public List<string> atomorder = new List<string>();
    private List<string> comparelist = new List<string>();
    private List<string> atomlist = new List<string>();
    private int listsize;
    private int atomchooser;
    public string currentatom;
    private int count = 1;
    // Start is called before the first frame update
    void Start()
    {
        //adding the atoms to the list  to than randomly pick and add into atomorder
        atomlist.Add("greenatom");
        atomlist.Add("purpleatom");
        atomlist.Add("yellowatom");
        listsize = Random.Range(1,10);
        while(listsize >= 0)
        {
            atomchooser = Random.Range(0, 3);
            if (atomchooser == 0){
                atomorder.Add(atomlist[0]);
                listsize -= 1;
            }
            else if (atomchooser == 1){
                atomorder.Add(atomlist[1]);
                listsize -= 1;
            }
            else if (atomchooser == 2){
                atomorder.Add(atomlist[2]);
                listsize -= 1;
            }
        }
        currentatom = atomorder[0];
    }

    // Update is called once per frame
    void Update()
    {
        //compares the atom to see if it was right
        if (comparelist.Count == atomorder.Count){
            for (int i = 0; i < atomorder.Count; i++)
            {
                if (comparelist[i] != atomorder[i])
                {
                    Debug.Log("wrongorder");
                }
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //detects collison than sends back what the current atom is
        if (collision.gameObject.CompareTag("greenatom"))
        {
            comparelist.Add("greenatom");
            Destroy(collision.gameObject);
        }

        if (collision.gameObject.CompareTag("purpleatom"))
        {
            comparelist.Add("purpleatom");
            Destroy(collision.gameObject);
        }

        if (collision.gameObject.CompareTag("yellowatom"))
        {
            comparelist.Add("yellowatom");
            Destroy(collision.gameObject);
        }
        if (count < atomorder.Count)
        {
            currentatom = atomorder[count];
            count += 1;
        }
    }
}
