Shader "FX/Mirror Reflection" { 
Properties {
    _MainTex ("Base (RGB) Transparency (A)", 2D) = "white" {}
    _ReflectionTex ("Reflection", 2D) = "white" { TexGen ObjectLinear }
}

// two texture cards: full thing
Subshader { 
    Pass {
    		AlphaTest Greater 0.4
        SetTexture[_MainTex] { combine texture }
        SetTexture[_ReflectionTex] { matrix [_ProjMatrix] combine texture * previous }
    }

	Pass {
		// Dont write to the depth buffer
		ZWrite off
		// Don't write pixels we have already written.
		ZTest Less
		// Only render pixels less or equal to the value
		AlphaTest LEqual 0.4

		// Set up alpha blending
		Blend SrcAlpha OneMinusSrcAlpha

		SetTexture [_MainTex] { combine texture * primary, texture}
	}
}

// fallback: just main texture
Subshader {
    Pass {
        SetTexture [_MainTex] { combine texture }
    }
}

}
