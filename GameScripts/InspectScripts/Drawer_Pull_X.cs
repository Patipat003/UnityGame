using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SojaExiles
{
    public class Drawer_Pull_X : MonoBehaviour
    {
        public Animator pull_01;
        public bool open;
        public Transform Player;
        public ObjectInspection objectInspection; // อ้างอิงไปยัง ObjectInspection

        void Start()
        {
            open = false;
        }

        void OnMouseOver()
        {
            if (Player)
            {
                float dist = Vector3.Distance(Player.position, transform.position);
                if (dist < 5)
                {
                    if (objectInspection != null && objectInspection.IsInspecting)
                    {
                        return; // ถ้าอยู่ในโหมด inspect ไม่ต้องทำอะไร
                    }

                    if (open == false)
                    {
                        if (Input.GetMouseButtonDown(0))
                        {
                            StartCoroutine(opening());
                        }
                    }
                    else
                    {
                        if (open == true)
                        {
                            if (Input.GetMouseButtonDown(0))
                            {
                                StartCoroutine(closing());
                            }
                        }
                    }
                }
            }
        }

        IEnumerator opening()
        {
            pull_01.Play("openpull_01");
            open = true;
            yield return new WaitForSeconds(.5f);
        }

        IEnumerator closing()
        {
            pull_01.Play("closepush_01");
            open = false;
            yield return new WaitForSeconds(.5f);
        }
    }
}
