using UnityEngine;
using System.Collections;
using Holoville.HOTween;
using Holoville.HOTween.Plugins;

public class CameraScript : MonoBehaviour {
	
	public Transform target;
	private Vector3 vel = Vector3.zero;
	public tk2dSprite fade;
	// Update is called once per frame
	void Update () {
		Vector3 offset = target.position - transform.position;		
		Vector3 dest = transform.position + offset;
		dest.y += 4;
		dest.z = transform.position.z;
		transform.position = Vector3.SmoothDamp(transform.position, dest, ref vel, 0.2f);
		
	}
	
	public void Warp() {
		transform.position = new Vector3(target.position.x,	target.position.y, transform.position.z);
	}
	
	public IEnumerator Fade(Color end, float duration) {
		Tweener twn = HOTween.To (fade, duration, new TweenParms().Prop("color", end));
		while(!twn.isComplete){
			yield return null;
		}
	}
	
	public IEnumerator Fade(Color start, Color end, float duration) {
		fade.color = start;
		Tweener twn = HOTween.To (fade, duration, new TweenParms().Prop("color", end));
		while(!twn.isComplete){
			yield return null;
		}
	}
	
	public IEnumerator CutsceneOff() {
		tk2dCamera camera = GetComponent<tk2dCamera>();
		Tweener twn = HOTween.To (camera, 1.0f, new TweenParms().Prop("ZoomFactor", 1.0f));
		while(!twn.isComplete){
			yield return null;
		}
	}
	
	public IEnumerator CutsceneOn() {
		tk2dCamera camera = GetComponent<tk2dCamera>();
		Tweener twn = HOTween.To (camera, 1.0f, new TweenParms().Prop("ZoomFactor", 2.5f));
		while(!twn.isComplete){
			yield return null;
		}
	}
}