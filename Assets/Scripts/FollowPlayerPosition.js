var deltaY = 0.0;
var deltaX = 0.0;
function Start () {
	var pref = GameObject.Find("PlayerRef").transform.position;
	transform.position.x = pref.x + deltaX;
	transform.position.y = pref.y + deltaY;
}
function Update () {
	var pref = GameObject.Find("PlayerRef").transform.position;
	transform.position.x = pref.x + deltaX;
	transform.position.y = pref.y + deltaY;
}