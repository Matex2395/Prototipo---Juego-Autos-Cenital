using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    NavMeshAgent m_Agent;
    public Transform[] goals = new Transform[5];
    private int m_NextGoal = 1;
    [SerializeField] private ParticleSystem particleSystem;

    void Start()
    {
        m_Agent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        float distance = Vector3.Distance(m_Agent.transform.position, goals[m_NextGoal].position);
        if (distance < 2.5f)
        {
            m_NextGoal = m_NextGoal != goals.Length - 1 ? m_NextGoal + 1 : 1;
        }
        m_Agent.destination = goals[m_NextGoal].position;
    }

    private void HandleParticles()
    {
        if (m_Agent.velocity.magnitude > 0 && !particleSystem.isPlaying)
        {
            particleSystem.Play();
        }
        else if (m_Agent.velocity.magnitude <= 0 && particleSystem.isPlaying)
        {
            particleSystem.Stop();
        }
    }
}
