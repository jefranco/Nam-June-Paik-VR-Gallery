Shader "Custom/Mask1"
{
   SubShader
   {
     Tags{ "Queue" = "Transparent +1"}

     Pass{
        Blend Zero One
     }
   }
}
