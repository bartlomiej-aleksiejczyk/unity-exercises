using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zad1EnemyController : MonoBehaviour
{
    public Transform a;
    public Transform b;

    public float speed = 2f;
    public float reactionSphere = 6f;

    private Transform target;
    private bool destinationA = true;
    private Animator animator;

    private void Start()
    {
        target = a;
    }

    private void Update()
    {
        MoveEnemy();
        CheckForPlayer();
    }
    private void MoveEnemy()
    {
        transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);

        if (Vector2.Distance(transform.position, target.position) < 0.1f)
        {
            animator.SetBool("IsIdling", false);
            target = (target == a) ? b : a;
        }
        else
        {
            animator.SetBool("IsIdling", true);
        }
    }
    private void CheckForPlayer()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player != null && Vector2.Distance(transform.position, player.transform.position) <= reactionSphere)
        {
            Debug.Log("Jest gracz");
            target = player.transform;
        }
        else if (target == player.transform)
        {
            target = destinationA ? a : b;
        }
    }
}
