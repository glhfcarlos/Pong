using System.Collections;
using UnityEngine;

public class BallParticles : MonoBehaviour
{
    public ParticleSystem ballParticles;
    private ParticleSystem.MainModule mainMod;

    public Color fireParticleColor;
    public Color airParticleColor;
    public Color waterParticleColor;
    public Color earthParticleColor;
    public Color defaultParticleColor;

    // Start is called before the first frame update
    void Awake()
    {
        // get the particle system's main module
        mainMod = ballParticles.main;
    }

    void OnCollisionEnter2D (Collision2D other)
    {
        switch (other.gameObject.tag)
        {
            case "Earth":
                // change particle color to brown
                mainMod.startColor = earthParticleColor;
                break;
            case "Water":
                // change particle color to blue
                mainMod.startColor = waterParticleColor;
                break;
            case "Air":
                // change particle color to light blue
                mainMod.startColor = airParticleColor;
                break;
            case "Fire":
                // change particle color to dark red
                mainMod.startColor = fireParticleColor;
                break;
            default:
                // change particle color to white (for walls and goals)
                mainMod.startColor = defaultParticleColor;
                break;
        }

        // FIXME: spew particles
        ballParticles.Play();
    }
}
