using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Clip { Clear };

public class AudioManager : MonoBehaviour
{
	public static AudioManager instance;

	private AudioSource[] sfx;

	// Use this for initialization
	void Start()
	{
		instance = GetComponent<AudioManager>();
		sfx = GetComponents<AudioSource>();
	}

	public void PlaySFX(Clip audioClip)
	{
		sfx[(int)audioClip + 1].Play();
	}
}
