using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Control : MonoBehaviour {
	private GameObject Wing;
	private GameObject Wings;


	public GameObject IN;
	public GameObject Menus;
	public GameObject btn;
	public GameObject As,Qs;


	string []Ques = new string[]{
		"为什么你讲话这么大声且古怪呢?",
		"你为什么会一遍又一遍的问相同的问题呢？",
		"为什么你会不断的重复某个动作？",
		"为什么你的四肢摆动起来如此笨拙？"
	};
	string []Ans = new string[]{
		"当我怪声怪气的时候，其实我并非故意，当然，我必须承认。有时候，我会觉得自己的声音能安慰自己。",
		"因为我会很快忘掉刚刚听到的东西，对我的大脑来说，我刚刚接收到信息，跟很久很久之前就接到信息，两者之间并没有太大区别。",
		"我的大脑经常会指挥我做一些小任务，不论我想做与否，而如果不按照做的话，我就必须要与恐惧感做斗争。",
		"我认为，许多自闭儿都会借助别人的手去拿某个物体，他们无法分辨双臂需要伸展，多长才能够到物品，他们也不知道怎样才能实实在在的抓住物品，因为我们在预计和测量距离方面仍有困难。"
	};


	float t = 50f;
	float s = 1.0f;
	bool leftw = true;
	bool isshow = false;
	int timer = 1000;
	int i=3;

	// Use this for initialization
	void Start () {
		Wings = GameObject.FindGameObjectWithTag ("Wings");
		Menus.SetActive (isshow);
		As.GetComponent<Text> ().text = " ";
		Qs.GetComponent<Text> ().text = " ";
	}
	void FixedUpdate(){

		//while (--timer != 0) {
			//i = i - 1;
			if (i>=0) {

				Qs.GetComponent<Text> ().text = Ques [i];
			    As.GetComponent<Text> ().text = Ans [i];
				print (i);
				//int temp = 3;
				//while (--temp == 0) {
					//As.GetComponent<Text> ().text = Ans [i];
				//}	
				i--;
			} else
				i = 3;

		//}
		//timer = 1000;
	}
	// Update is called once per frame
	void Update () {


		if (leftw) {
			Wing = GameObject.FindGameObjectWithTag ("Left");
		} else {
			Wing = GameObject.FindGameObjectWithTag ("Right");
		}
		if (Input.GetKeyDown (KeyCode.Escape)) {
			Application.Quit();
		}

	}
	public void Capture(){
		ScreenCapture.CaptureScreenshot ("Cap.png");
	}
	public void Left(){
		Wing.transform.position = Wing.transform.position - new Vector3(t,0,0);
	}
	public void Right(){
		Wing.transform.position = Wing.transform.position + new Vector3(t,0,0);
	}
	public void Up(){
		Wing.transform.position = Wing.transform.position + new Vector3(0,0,t);
	}
	public void Down(){
		Wing.transform.position = Wing.transform.position - new Vector3(0,0,t);
	}
	public void Far(){
		Wing.transform.position = Wing.transform.position - new Vector3(0,t,0);
	}
	public void Near(){
		Wing.transform.position = Wing.transform.position + new Vector3(0,t,0);
	}
	public void Choice(){
		leftw = !leftw;
	}
	public void Scalecontrol(){
		string textValuie = IN.GetComponent<InputField> ().text;
		s = float.Parse(textValuie);
		Wings.transform.localScale  = new Vector3(s,s,s);
	}
	public void zuoyou(){
		isshow = !isshow;
		Menus.SetActive (isshow);
	}

}
