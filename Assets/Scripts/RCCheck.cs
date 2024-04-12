//this script is responsible for Raycast checking. DON'T CHANGE IT, IT'LL BREAK
//btw brim sucks now because of clove - valorant moment
//RC stands for raycast.

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class RCCheck : MonoBehaviour
{
    private Animation anim;


    // Start is called before the first frame update
    void Start()
    {
       anim = gameObject.GetComponent<Animation>();
       
    }

    RaycastHit hit;
    MySelectable currentSelectable;
    // Update is called once per frame
    void Update()
    {
        Ray ray = new Ray(transform.position, transform.forward);
        Debug.DrawRay(transform.position, transform.forward * 10, Color.red);


        if (Physics.Raycast(ray, out hit))
        {

            MySelectable selectable = hit.collider.gameObject.GetComponent<MySelectable>();
            if (selectable)
            {
                if (currentSelectable && currentSelectable != selectable)
                {
                    currentSelectable.Deselect();
                }
                currentSelectable = selectable;
                selectable.Select();
            }

        //    if(Vector3.Distance(transform.position, selectable.transform.position) <= 2)
        //    {
        //        переход на следующую сцену (TBD)
        //    }

            else if (currentSelectable)
            {
                currentSelectable.Deselect();
                currentSelectable = null;
            }
            else if (currentSelectable)
            {
                currentSelectable.Deselect();
                currentSelectable = null;
            }
            }
    }
}
