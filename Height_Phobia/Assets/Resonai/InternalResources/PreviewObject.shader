Shader "Resonai/Preview Object" {
   Properties {
      _MainTex ("Texture Image", 2D) = "white" {}
   }
   SubShader {
      Tags {"Queue"="Transparent" "IgnoreProjector"="True" "RenderType"="Transparent" "DisableBatching"="True"}

      Lighting Off
      Blend SrcAlpha OneMinusSrcAlpha

      Pass {   
         CGPROGRAM
 
         #pragma vertex vert  
         #pragma fragment frag

         #include "UnityCG.cginc"

         uniform sampler2D _MainTex;

         float4 _MainTex_ST;

         struct vertexInput {
            float4 vertex : POSITION;
            float4 tex : TEXCOORD0;
            float4 color : COLOR;
         };
         struct vertexOutput {
            float4 pos : SV_POSITION;
            float2 tex : TEXCOORD0;
            float4 color : COLOR;
         };

		 // a,b should be normalized vectors
        float angle_in_deg(float3 a, float3 b)
        {
            return round(degrees(acos(dot(a,b))));
        }

         vertexOutput vert(vertexInput input) 
         {
            vertexOutput output;

            float4 params     = round(input.color * 100.0);
            float rows        = params.b;
            float columns     = params.a;
            float this_ring   = params.r;
            float this_column = params.g;
            

            float3 from_camera =  - ObjSpaceViewDir(float4(0,0,0,1));
            int theta        = angle_in_deg(normalize(from_camera), float3(0,-1,0)); // angle of camera-view-dir to Y axis down
            float3 camera_on_ground = normalize(float3(from_camera.x,0,from_camera.z));
            float y_angle    = angle_in_deg(camera_on_ground, float3(0,0,1)); // angle of camera-view-dir around Y axis, in the XZ plane

            if (camera_on_ground.x < 0.0 )
            {
               y_angle = 360-y_angle;
            }

            float k = 180.0/(rows-1); 
            float cur_ring = (rows-1) - floor(theta/k + 0.5);

            float c = 360.0/(columns); 
            float cur_column = floor(y_angle/c+0.5);
            if (cur_column >= columns) cur_column -=columns;

            output.tex = input.tex;
            output.pos = UnityObjectToClipPos(input.vertex);
            output.color = float4(0,0,0,0);
            if(cur_ring == this_ring && cur_column == this_column)
            {
              output.color.a = 1.0;
            }
            else
            {
              output.color.a = 0.0;
            }

            return output;
         }
 
         float4 frag(vertexOutput input) : SV_Target
         {
            fixed4 col = input.color;
         	  if (input.color.a > 0.0)
         	  {
         		  col = tex2D(_MainTex, input.tex); 
         	  }
            clip(col.a - 0.5);
            return col;
         }
 
         ENDCG
      }
   }
}
