using UnityEngine;
using System.Collections;
using Parse;

public class TestParse : MonoBehaviour {

    void Start() {
        ParseObject testObject = new ParseObject("TestObject");
		testObject["foo"] = "bar";
		testObject.SaveAsync();
    }

}
