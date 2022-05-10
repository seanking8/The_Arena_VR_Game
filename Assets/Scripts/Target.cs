using UnityEngine;

public class Target : MonoBehaviour, IArrowHittable
{
    public AudioSource sound;
    public AudioSource hitSound;
    public int bullsEyeScore;
    public int InnerRingScore;
    public int OuterRingScore;

    void Awake()
    {
        sound = GetComponent<AudioSource>();
    }

    public void Hit(Arrow arrow)
    {

        sound.Play();

        if (gameObject.name == "Bullseye")
        {
            hitSound.Play();
            Goal.score += bullsEyeScore;
        }
        else if (gameObject.name == "InnerRing")
        {
            hitSound.Play();
            Goal.score += InnerRingScore;
        }
        else if (gameObject.name == "OuterRing")
        {
            Goal.score += OuterRingScore;
        }
    }
}
