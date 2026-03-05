using System;
using UnityEngine;

public class LanderVisuals : MonoBehaviour
{
    [SerializeField] private ParticleSystem leftThusterParticleSystem;
    [SerializeField] private ParticleSystem middleThusterParticleSystem;
    [SerializeField] private ParticleSystem rightThusterParticleSystem;

    private Lander lander;
    private void Awake()
    {
       lander = GetComponent<Lander>();
        lander.OnUpForce += Lander_OnUpForce;
        lander.OnRightForce += Lander_OnRightForce;
        lander.OnLeftForce += Lander_OnLeftForce;
        lander.OnBeforeForce += Lander_OnBeforeForce;           
        SetEnableThrusterParticleSystem(leftThusterParticleSystem, false);
        SetEnableThrusterParticleSystem(middleThusterParticleSystem, false);
        SetEnableThrusterParticleSystem(rightThusterParticleSystem, false);
    }

    private void Lander_OnBeforeForce(object sender, EventArgs e)
    {
        SetEnableThrusterParticleSystem(leftThusterParticleSystem, false);
        SetEnableThrusterParticleSystem(middleThusterParticleSystem, false);
        SetEnableThrusterParticleSystem(rightThusterParticleSystem, false);
    }

    private void Lander_OnLeftForce(object sender, EventArgs e)
    {
        
        SetEnableThrusterParticleSystem(rightThusterParticleSystem, true);
    }

    private void Lander_OnRightForce(object sender, EventArgs e)
    {
        SetEnableThrusterParticleSystem(leftThusterParticleSystem, true);
       
    }

    private void Lander_OnUpForce(object sender, EventArgs e)
    {
        SetEnableThrusterParticleSystem(leftThusterParticleSystem, true);
        SetEnableThrusterParticleSystem(middleThusterParticleSystem, true);
        SetEnableThrusterParticleSystem(rightThusterParticleSystem, true);  

    }

    private void SetEnableThrusterParticleSystem(ParticleSystem particleSystem, bool enabled)
    {
        ParticleSystem.EmissionModule emissionModule = particleSystem.emission;
        emissionModule.enabled = enabled;
    }



}
