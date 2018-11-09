using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This script simulate the flower behavior so that they move while the player run through it
//It also make particle appear during a certain amount of time if the flower was touched first.
//The particle system is stop in order to optimize the performance
public class LongFlowerBehaviour : MonoBehaviour {

   public Animator anim;

   public bool touched; //If a flower is touched. This bool is link to the animation of the flower
   public bool sendParticle;//If the particle system is active or not
   public AudioSource source;
   public AudioClip clip;

   public ParticleSystem particle;

   public float TimeParticle = 400;//The specified amount of time the particle system is running


	// Use this for initialization
	void Start () {
		particle = gameObject.GetComponentInParent<ParticleSystem>();
		source = gameObject.GetComponentInParent<AudioSource>();
		particle.Pause();
	}
	
	// Update is called once per frame
	void Update ()
	{
		anim.SetBool ("touch", touched);
		if (sendParticle) {
			TimeParticle -= 1f;
		}
		if (TimeParticle <= 0) {
			sendParticle = false;

			TimeParticle = 400;
		}
		if (!sendParticle) {
			particle.Stop();
		}
	}

	void OnTriggerEnter2D (Collider2D col)
	{
		if (col.tag.Equals ("Player")) {
			touched = true;
			sendParticle = true;
			if(!source.isPlaying)
			source.PlayOneShot (clip);
			Particle();
		}
	}
	void OnTriggerStay2D (Collider2D col)
	{
		if (col.tag.Equals ("Player")) {
			touched = true;
			sendParticle = true;
		}
	}

	void OnTriggerExit2D (Collider2D col)
	{
		if (col.tag.Equals ("Player")) {
			touched = false;
		}
	}

	public void Particle ()
	{
		particle.Play();
	}
}
