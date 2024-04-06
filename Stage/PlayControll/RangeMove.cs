using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class RangeMove : MonoBehaviour
{
    public Vector3 point;
    public Transform StopT;
    public GameObject middle;
    public GameObject left;
    public GameObject right;
    public CapsuleCollider magicball;
    public SkinnedMeshRenderer skinnedMeshRenderer;
    public GameObject explode;
    Skill skill;

    public int road;
    //투사체스킬을 움직이고 Enemy와의 충돌을 확인함
    private void Start()
    {
        middle = GameObject.Find("Spawner");
        left = GameObject.Find("TurnL");
        right = GameObject.Find("TurnR");
        skill = GameObject.Find("Skill").GetComponent<Skill>();
        if (road == 0)
            point = middle.transform.position;
        else if (road == 1)
            point = left.transform.position;
        else if (road == 2)
            point = right.transform.position;
    }


    private void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, point, 0.5f*Time.timeScale);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Turn") || other.gameObject.name == "Spawner")
        {
            Destroy(gameObject, 0.05f);
        }
        else if (other.CompareTag("Enemy") && (gameObject.CompareTag("MagicMissile") || gameObject.CompareTag("RMagicMissile")))
        {
            point = gameObject.transform.position;
            skill.explodeT = gameObject.transform;
            StartCoroutine(skill.Wait());
            
            magicball.enabled = false;
            skinnedMeshRenderer.enabled = false;
            
        }
    }
}
