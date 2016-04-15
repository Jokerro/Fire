precision mediump float;
varying vec2 v_uvPos;
uniform sampler2D u_tex;
uniform sampler2D u_tex_mask;
uniform sampler2D u_tex_disp;
uniform float u_time;
uniform float u_ampFactor;

void main()
{
	vec2 disp = texture2D(u_tex_disp, vec2(v_uvPos.x, mod((v_uvPos.y + u_time),1.0))).rg;
	vec2 offset = (2.0 * disp - 1.0)*u_ampFactor;

	vec2 new_uv = v_uvPos + offset;
	vec4 alpha = texture2D(u_tex_mask, v_uvPos);

	gl_FragColor =  vec4(texture2D(u_tex,new_uv).rgb, alpha.r);
}
